using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grbl控制上位机程序
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //用于获取现有COM口的类
        Microsoft.VisualBasic.Devices.Computer cmbCOM = new Microsoft.VisualBasic.Devices.Computer();
        //串口设置需要的类
        Parity myParoty = Parity.None;
        StopBits myStopBits = StopBits.One;
        //用于GDI+绘图的位图类
        static Bitmap bmp = new Bitmap(400, 400);
        //用于GDI+绘图的类
        Graphics g = Graphics.FromImage(bmp);
        //用于存储各行从NC文件中读取的G代码的字符串数组
        string[] str = null;
        //G代码需要的各项变量
        double x = 0, y = 0, xt = 0, yt = 0, i = 0, j = 0;
        int GMode = 0;
        //用于存储在读取的NC文件中的G代码的x，y的最大值
        double xMax = 0, yMax = 0;
        //从nc文件的实际坐标到位图坐标的比例尺
        double xRate = 400 / 38;
        double yRate = 400 / 38;
        //储存当前已发送的行数-1
        int countForStr = 0;
        //储存1秒前已发送的行数-1，与countForStr相减可得1秒内发送的行数
        int countOld = 0;
        //是否发送文件标志位
        bool sendCodeFlag = false;
        //发送阶段的当前耗时
        int runTime = 0;
        int watchDog = 0;
        //存储一次接收到的字符串
        StringBuilder reciveString = new StringBuilder(50);
        /// <summary>
        /// 初始化参数，并检查已连接电脑的串口设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨线程访问的检查
            Control.CheckForIllegalCrossThreadCalls = false;
            //串口编码改为DeFault以显示中文
            serialPort.Encoding = Encoding.Default;
            //初始化运行时间及剩余时间的显示
            lblTime.Text = (countForStr - countOld).ToString() + "条/秒" + "      " + SecondsToTime(0);
            lblRunTime.Text = "已运行时间： " + SecondsToTime(runTime);

            //加载窗体后获取已连接的COM口
            foreach(string str in cmbCOM.Ports.SerialPortNames)
            {
                cboCOMSelect.Items.Add(str);
            }

            //串口各项属性选为默认值
            cboStop.SelectedIndex = 0;
            cboDataBit.SelectedIndex = 0;
            cboParity.SelectedIndex = 0;

            //若加载时已有COM口连接电脑，给串口类的com口赋值
            if (cboCOMSelect.Items.Count > 0)
            {
                cboCOMSelect.SelectedIndex = 0;
            }

            //串口各项属性选为默认值
            cboBaudRate.SelectedIndex = 13;
            //进度条分辨率为500
            pbarSend.Maximum = 500;

            //为显示的预览图添加背景色
            g.FillRectangle(Brushes.LightGoldenrodYellow, 0, 0, bmp.Width, bmp.Height);

            picPreview.Image = bmp;
        }
        /// <summary>
        /// 单击串口选择下拉框时，刷新当前已连接电脑的串口设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCOMSelect_Click(object sender, EventArgs e)
        {
            cboCOMSelect.Items.Clear();

            foreach (string str in cmbCOM.Ports.SerialPortNames)
            {
                cboCOMSelect.Items.Add(str);
            }
        }
        /// <summary>
        /// 选择非自定义波特率时，无法更改控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBaudRate.SelectedIndex == 0)
            {
                cboBaudRate.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                cboBaudRate.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        /// <summary>
        /// 打开串口时，串口配置无法更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            if (btnOpenPort.Text == "关闭串口")
            {

                try
                {
                    serialPort.Close();
                }
                catch
                {
                    MessageBox.Show("串口关闭失败");
                    return;
                }

                cboCOMSelect.Enabled = true;
                cboBaudRate.Enabled = true;
                cboDataBit.Enabled = true;
                cboStop.Enabled = true;
                cboParity.Enabled = true;

                btnOpenPort.Text = "打开串口";


            }
            else
            {


                try
                {
                    serialPort.BaudRate = Convert.ToInt32(cboBaudRate.Text);
                }
                catch
                {
                    MessageBox.Show("波特率输入有误");
                    return;
                }
                try
                {
                    serialPort.PortName = cboCOMSelect.Text;
                }
                catch
                {
                    MessageBox.Show("串口号有误");
                    return;
                }

                serialPort.DataBits = Convert.ToInt32(cboDataBit.Text);
                serialPort.Parity = myParoty;
                serialPort.StopBits = myStopBits;
                serialPort.ReadTimeout = 1000;

                try
                {
                    serialPort.Open();
                }
                catch
                {
                    MessageBox.Show("串口打开失败或其他错误\n请选择正确串口或该串口被占用");
                    return;
                }

                cboCOMSelect.Enabled = false;
                cboBaudRate.Enabled = false;
                cboDataBit.Enabled = false;
                cboStop.Enabled = false;
                cboParity.Enabled = false;

                btnOpenPort.Text = "关闭串口";

            }
        }
        /// <summary>
        /// 设置停止位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStop_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cboStop.SelectedItem.ToString())
            {
                case "1": myStopBits = StopBits.One;
                    break;
                case "1.5": myStopBits = StopBits.OnePointFive;
                    break;
                case "2": myStopBits = StopBits.Two;
                    break;
            }
        }
        /// <summary>
        /// 设置校验位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cboParity.SelectedItem.ToString())
            {
                case "无": myParoty = Parity.None;
                    break;
                case "奇校验": myParoty = Parity.Odd;
                    break;
                case "偶校验": myParoty = Parity.Even;
                    break;
            }
        }
        /// <summary>
        /// 收到数据后的操作，将收到的字符串显示到信息文本窗口，若发送文件标志位为true且收到"ok\r\n",发送一行G代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string strRecived = serialPort.ReadExisting();
            txtMsg.AppendText(strRecived);
            SendFile(ref countForStr, strRecived);
            serialPort.DiscardInBuffer();
        }
        /// <summary>
        /// 按下发送按钮后，将发送文本框中的内容发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string str = txtSend.Text + "\r\n";
            byte[] buffer = new byte[str.Length];
            buffer = Encoding.ASCII.GetBytes(str);
            serialPort.Write(buffer, 0, buffer.Length);
        }
        /// <summary>
        /// 打开NC文件，并绘制预览图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                str = File.ReadAllLines(txtPathSave.Text, Encoding.Default);
            }
            catch
            {
                MessageBox.Show("路径有误");
                return;
            }

            g.FillRectangle(Brushes.LightGoldenrodYellow, 0, 0, bmp.Width, bmp.Height);

            xMax = 0;
            yMax = 0;

            foreach (string line in str)
            {
                CodeToNum(line, ref x, ref y, ref i, ref j, ref GMode);
                if (x > xMax)
                {
                    xMax = x;
                }
                if (y > yMax)
                {
                    yMax = y;
                }
                xRate = (bmp.Width-70) / xMax;
                yRate = (bmp.Height-50) / yMax;
            }

            x = 0;
            y = 0;
            i = 0;
            j = 0;

            DrawLineWithoutChange(0, yMax, bmp.Width, yMax, g);
            DrawLineWithoutChange(xMax, 0, xMax, bmp.Height, g);
            g.DrawString(xMax.ToString() + "mm", new System.Drawing.Font("宋体", 10, FontStyle.Regular), Brushes.RosyBrown, new PointF((float)(xMax * xRate), 385));
            g.DrawString(yMax.ToString() + "mm", new System.Drawing.Font("宋体", 10, FontStyle.Regular), Brushes.RosyBrown, new PointF(0, (float)(385-yMax * yRate)));

            foreach (string line in str)
            {
                CodeToNum(line, ref x, ref y, ref i, ref j, ref GMode);
                if (GMode == 1 || GMode == 2 || GMode == 3)  
                {
                    DrawLine(ref xt, ref yt, ref x, ref y, g);
                }
                else
                {
                    xt = x;
                    yt = y;
                }
                picPreview.Image = bmp;
            }

            x = 0;
            y = 0;
            xt = 0;
            yt = 0;
            i = 0;
            j = 0;
            countForStr = 0;
            btnSendFile.Enabled = true;
        }
        /// <summary>
        /// 将G代码转化为变量存储
        /// </summary>
        /// <param name="str">一行G代码</param>
        /// <param name="x">目标点横坐标</param>
        /// <param name="y">目标点纵坐标</param>
        /// <param name="i">圆心相对于当前坐标的横坐标的横向偏移量</param>
        /// <param name="j">圆心相对于当前坐标的纵坐标的纵向偏移量</param>
        /// <param name="g">运动模式</param>
        void CodeToNum(string str, ref double x, ref double y, ref double i, ref double j,ref int g)
        {
            string[] everyValue = str.Split(' ','F');
            if (str.Length == 0)
            {
                return;
            }
            foreach (string oneValue in everyValue)
            {
                char[] codes = oneValue.ToCharArray();
                if (codes.Length == 0)
                {
                    continue;
                }
                switch (codes[0])
                {
                    case 'X':
                        codes = codes.Skip(1).ToArray();
                        string numX = new string(codes);
                        x = Convert.ToDouble(numX);
                        break;
                    case 'Y':
                        codes = codes.Skip(1).ToArray();
                        string numY = new string(codes);
                        y = Convert.ToDouble(numY);
                        break;
                    case 'I':
                        codes = codes.Skip(1).ToArray();
                        string numI = new string(codes);
                        i = Convert.ToDouble(numI);
                        break;
                    case 'J':
                        codes = codes.Skip(1).ToArray();
                        string numJ = new string(codes);
                        j = Convert.ToDouble(numJ);
                        break;
                    case 'G':
                        codes = codes.Skip(1).ToArray();
                        string numG = new string(codes);
                        g = Convert.ToInt32(numG);
                        break;
                }
            }
        }
        /// <summary>
        /// 画直线（用于预览）
        /// </summary>
        /// <param name="xt">当前点的横坐标</param>
        /// <param name="yt">当前点的纵坐标</param>
        /// <param name="x">目标点的横坐标</param>
        /// <param name="y">目标点的纵坐标</param>
        /// <param name="g">用于绘图的Graphics类</param>
        void DrawLine(ref double xt, ref double yt, ref double x, ref double y, Graphics g)
        {
            int xtToInt = (int)(xt * xRate);
            int ytToInt = (int)(yt * yRate);
            int xToInt = (int)(x * xRate);
            int yToInt = (int)(y * yRate);
            //创建画笔对象
            Pen pen = new Pen(Brushes.Blue);
            //创建两个点
            Point p1 = new Point(xtToInt, bmp.Height - ytToInt);
            Point p2 = new Point(xToInt, bmp.Height - yToInt);

            g.DrawLine(pen, p1, p2);

            xt = x;
            yt = y;
//            x = 0;
//            y = 0;
            GMode = -1;
        }
        /// <summary>
        /// 画直线（用于实时观看）
        /// </summary>
        /// <param name="xt">当前点的横坐标</param>
        /// <param name="yt">当前点的纵坐标</param>
        /// <param name="x">目标点的横坐标</param>
        /// <param name="y">目标点的纵坐标</param>
        /// <param name="g">用于绘图的Graphics类</param>
        void DrawLineRed(ref double xt, ref double yt, ref double x, ref double y, Graphics g)
        {
            int xtToInt = (int)(xt * xRate);
            int ytToInt = (int)(yt * yRate);
            int xToInt = (int)(x * xRate);
            int yToInt = (int)(y * yRate);
            //创建画笔对象
            Pen pen = new Pen(Brushes.Green, 3);
            //创建两个点
            Point p1 = new Point(xtToInt, bmp.Height - ytToInt);
            Point p2 = new Point(xToInt, bmp.Height - yToInt);

            g.DrawLine(pen, p1, p2);

            xt = x;
            yt = y;
            //            x = 0;
            //            y = 0;
            GMode = -1;
        }
        /// <summary>
        /// 画直线(画上下左右界限)
        /// </summary>
        /// <param name="xt">当前点的横坐标</param>
        /// <param name="yt">当前点的纵坐标</param>
        /// <param name="x">目标点的横坐标</param>
        /// <param name="y">目标点的纵坐标</param>
        /// <param name="g">用于绘图的Graphics类</param>
        void DrawLineWithoutChange(double xt, double yt, double x, double y, Graphics g)
        {
            int xtToInt = (int)(xt * xRate);
            int ytToInt = (int)(yt * yRate);
            int xToInt = (int)(x * xRate);
            int yToInt = (int)(y * yRate);
            //创建画笔对象
            Pen pen = new Pen(Brushes.RosyBrown);
            //创建两个点
            Point p1 = new Point(xtToInt, bmp.Height - ytToInt);
            Point p2 = new Point(xToInt, bmp.Height - yToInt);

            g.DrawLine(pen, p1, p2);
        }
        void DrawArc(ref double xt, ref double yt, ref double x, ref double y, ref double i, ref double j, Graphics g)
        {
            int xtToInt = (int)(xt * xRate);
            int ytToInt = (int)(yt * yRate);
            int xToInt = (int)(x * xRate);
            int yToInt = (int)(y * yRate);
            int iToInt = (int)(i * xRate);
            int jToInt = (int)(j * yRate);
            double r = Math.Sqrt((double)(iToInt * iToInt + jToInt * jToInt));
            Pen pen = new Pen(Brushes.Red, 2);

            ytToInt = 400 - ytToInt;
            yToInt = 400 - yToInt;

            int xc = xtToInt + iToInt;
            int yc = ytToInt - jToInt;

            double startarc;
            double endarc;
            Rectangle rect = new Rectangle((int)(xc - r), (int)(yc - r), (int)(2 * r), (int)(2 * r));

            startarc = Math.Atan2(ytToInt - yc, xtToInt - xc) / Math.PI * 180;
            endarc = Math.Atan2(yToInt - yc, xToInt - xc) / Math.PI * 180;


            g.DrawArc(pen, rect, (float)startarc, (float)(-(startarc - endarc)));
            //g.DrawArc(pen, rect, (float)(-(startarc - endarc)), (float)startarc);

            xt = x;
            yt = y;
 //           x = 0;
 //           y = 0;
            i = 0;
            j = 0;
            GMode = -1;
        }
        /// <summary>
        /// 获取需要的NC文件路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExploreFlie_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择要打开的NC文件";
            ofd.InitialDirectory = @"C:\Users\SpringRain\Desktop";
            ofd.Multiselect = false;
            ofd.Filter = "路径|*.nc|所有文件|*.*";
            ofd.ShowDialog();

            txtPathSave.Text = ofd.FileName;
        }
        /// <summary>
        /// 将传送文件标志位置1，开一个周期为1秒的定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (sendCodeFlag)
            {
                sendCodeFlag = false;
                btnSendFile.Text = "发送文件";
                tmrV.Stop();
            }
            else
            {
                sendCodeFlag = true;
                btnSendFile.Text = "停止发送";
                //发送"G20\r\n"，诱使下位机发出第一个"ok\r\n"使其能够进入SendFile函数
                serialPort.Write("G30\r\n");
                tmrV.Start();
            }
        }
        /// <summary>
        /// 向下寻找并发送一行非空的G代码，并实时记录到进度条和lblRate（用于显示百分比）
        /// 且绘画用于实时观看的直线
        /// </summary>
        /// <param name="count"></param>
        /// <param name="strRecived"></param>
        void SendFile(ref int count, string strRecived)
        {
            //如果允许发送文件
            if (sendCodeFlag)
            {
                //如果收到的字符串符合要求
                if (strRecived == "ok\r\n")
                {

                    //判断文件是否发送完毕
                    if (count >= str.Length)
                    {
                        txtMsg.AppendText("发送完毕");
                        tmrV.Stop();
                        return;
                    }
                    //跳过空行
                    while (str[count] == "")
                    {
                        count++;
                    }
                    //发送的字符串末尾加上"\r\n",正点原子写的stm32的usart通信协议要求接收到"\r\n"才结束接收
                    string lineToSend = str[count] + "\r\n";
                    byte[] buffer = new byte[lineToSend.Length];
                    buffer = Encoding.ASCII.GetBytes(lineToSend);

                    serialPort.Write(buffer, 0, buffer.Length);
                    txtMsg.AppendText("发送：" + lineToSend);
                    watchDog = 0;
                }

                //画实时进度线
                CodeToNum(str[count], ref x, ref y, ref i, ref j, ref GMode);
                lblNumXc.Text = xt.ToString();
                lblNumYc.Text = yt.ToString();

                DrawLineRed(ref xt, ref yt, ref x, ref y, g);

                //更新进度条以及百分比
                pbarSend.Value = (int)((float)pbarSend.Maximum * count / (str.Length - 1));
                lblRate.Text = (count * 100 / (str.Length - 1)).ToString() + "%";

                //更新图像
                picPreview.Image = bmp;
                //读取下一行G代码
                count++;
            }
        }
        /// <summary>
        /// 定时器中断，用于计算速度、剩余时间，并记录运行时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrV_Tick(object sender, EventArgs e)
        {
            runTime++;
            watchDog++;
            double timeSecond = (((double)str.Length - countForStr) / ((double)countForStr / runTime));
            lblTime.Text = (countForStr - countOld).ToString() + "条/秒" + "      " + SecondsToTime(timeSecond);
            lblRunTime.Text = "已运行时间： " + SecondsToTime(runTime);
            countOld = countForStr-1;

            if (watchDog >= 10)
            {
                //判断文件是否发送完毕
                if (countForStr-1 >= str.Length)
                {
                    txtMsg.AppendText("发送完毕");
                    tmrV.Stop();
                    return;
                }
                //跳过空行
                while (str[countForStr-1] == "")
                {
                    countForStr++;
                }
                string lineToSend = str[countForStr-1] + "\r\n";
                byte[] buffer = new byte[lineToSend.Length];
                buffer = Encoding.ASCII.GetBytes(lineToSend);
                serialPort.Write(buffer, 0, buffer.Length);
                txtMsg.AppendText("重新发送：" + lineToSend);
            }
        }
        /// <summary>
        /// 将秒数化为“小时:分钟:秒钟”的形式
        /// </summary>
        /// <param name="second">传入的秒数</param>
        /// <returns>“小时:分钟:秒钟”的形式的字符串</returns>
        string SecondsToTime(double second)
        {
            int hour = 0, min = 0, sec = 0;

            hour = (int)second / 3600;
            min = ((int)second) / 60 % 60;
            sec = ((int)second) % 60;

            return hour.ToString("D2") + ":" + min.ToString("D2") + ":" + sec.ToString("D2");
        }

        private void cboCOMSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
