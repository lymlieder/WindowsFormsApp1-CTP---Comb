using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public delegate void showWhatRecived_Delegate(string text);
        static string[] portArr, baudRateArray, dataLengthArray, stopBitsArray, parityTypeArray, loginTypeArray;
        static string tempReciveString, connectedMacString;
        static byte[] dataArray, notifyStore, connectedMac;
        static List<byte> tempCommendList;
        static List<periStruct> periList;//;
        static int foundCount, IMax;
        static Double VMax, VMin;
        static bool BLEConnectTip, netGoOn;
        const int addLen = 6;
        const int IMaxD = 130;
        const Double VMaxD = 6.7;
        const Double VMinD = 5.0;
        const int reTestCount = 3;
        static int reTestTip;
        static int reTestType = 0;
        static netLoginReturnStruct1 netCommenRoot = new netLoginReturnStruct1();
        static netCTPInfoStruct2_0 netCTPInfo = new netCTPInfoStruct2_0();
        static netSetIDReturnStruct2 setIDReturn = new netSetIDReturnStruct2();

        struct periStruct
        {
            public UInt16 UUID;
            public int index;
            public byte[] periAddr;
            public UInt16 dataLen;
            public string periData;
            public Int64 periRSSI;
            public bool connectTip;
        }

        class netLoginStruct1//登入<API_ROOT>/UserLogin
        {
            public string AccountNo;
            public string Password;
            public string AppType;
        }

        class netLoginReturnStruct1
        {
            public string StatusCode;
            public string Token;
            public string AccountNo;
            public int AccountType;
            public int AccountPower;
        }

        class netSetIDStruct2//设置ID<API_ROOT>/LockInit
        {
            public string AccountNo;
            public string Token;
            public string LockNo;
            public string BleMac;
        }

        class netSetIDReturnStruct2
        {
            public string StatusCode;
            public netCTPInfoStruct2_0 CTPInfo;
        }

        class netCTPInfoStruct2_0//地锁信息子类
        {
            public string AccountNo;
            public string LockNo;
            public string BleMac;
            public string Time;
            public string KeyId;
            public string Round;
            public string Sign;
        }

        class netBCStruct2_1//状态上报
        {
            public string AccountNo;
            public string Token;
            public string LockNo;
            public string Voltage;
            public string Status;
        }

        class setCTPIDStruct//对CTP设置ID
        {
            public string CMD;
            public string ACCOUNT;
            public string TIME;
            public string LOCK_ID;
            public string BLE_MAC;
            public string KEY_ID;
            public string ROUND;
            public string SIGN;
        }

        class netOpenStruct3//开锁请求<API_ROOT>/OpenLock
        {
            public string AccountNo;
            public string Token;
            public string LockNo;
        }

        class netOpenReturnStruct3
        {
            public string StatusCode;
            public netCTPInfoOCStruct Info;
        }

        class netCloseStruct4//关锁<API_ROOT>/CloseLock
        {
            public string AccountNo;
            public string Token;
            public string LockNo;
        }

        class netCloseReturnStruct4
        {
            public string StatusCode;
            public netCTPInfoOCStruct Info;
        }

        class getLockID//通过MAC地址获取ID
        {
            public string AccountNo;
            public string Token;
            public string BleMac;
        }

        class getLockIDInfo
        {
            public string lockNo;
            public string BleMac;
        }

        class getLockIDReturn//拿到ID
        {
            public string StatusCode;
            public getLockIDInfo LockInfo;
        }

        class setCTPOCStruct//对CTP设置开关
        {
            public string CMD;
            public string ACCOUNT;
            public string TIME;
            public string KEY_ID;
            public string ROUND;
            public string SIGN;
        }

        class netCTPInfoOCStruct//地锁信息|开关公用
        {
            public string AccountNo;
            public string LockNo;
            public string Time;
            public string KeyId;
            public string Round;
            public string Sign;
        }

        class netCommenBCReturnStruct0
        {
            public string StatusCode;
        }

        public async void loginIn()//登入
        {
            //发送请求，当netGoOn为true后读取
            netLoginStruct1 netLogin = new netLoginStruct1();
            netLogin.AccountNo = loginAccount_textBox4.Text;
            string password = loginPassword_textBox5.Text;
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(password));
            netLogin.Password = BitConverter.ToString(output).Replace("-", "").ToLower();
            netLogin.AppType = loginType_comboBox6.SelectedIndex.ToString();
            
            netCommenRoot = await HttpClientDoPost<netLoginReturnStruct1>(netLogin, "UserLogin");
            if (netCommenRoot.AccountNo != netLogin.AccountNo || netCommenRoot.StatusCode != "200")
            {
                loginResult_textBox4.ForeColor = Color.Red;
                loginResult_textBox4.BackColor = Color.LightPink;
                loginResult_textBox4.Text = "登录失败";
                errorShow(netCommenRoot.StatusCode);
                return;
            }
            loginResult_textBox4.ForeColor = Color.DarkOliveGreen;
            loginResult_textBox4.BackColor = Color.LightBlue;
            loginResult_textBox4.Text = "登录成功";
            netGoOn = true;
        }

        private async void IDRecord_Click(object sender, EventArgs e)//录入ID
        {
            //给服务器发送请求，收到数据后发给地锁，设置好后把地锁返回信息发给服务器在下一个函数里
            if (textBox4.TextLength < 4)
            {
                textBox4.ForeColor = Color.Red;
                IDRecordResult_textBox7.ForeColor = Color.Red;
                IDRecordResult_textBox7.Text = "ID尾数不满4位";
                return;
            }

            try
            {
                netSetIDStruct2 setID = new netSetIDStruct2();//给服务器发送请求
                setID.AccountNo = netCommenRoot.AccountNo;
                setID.BleMac = connectedMacString;
                setID.LockNo = textBox6.Text + textBox4.Text;
                setID.Token = netCommenRoot.Token;

                //请求ID数据
                setIDReturn = await HttpClientDoPost<netSetIDReturnStruct2>(setID, "LockInit");

                if (setIDReturn.StatusCode == "200")
                {
                    //收到数据后发给地锁
                    netCTPInfo = setIDReturn.CTPInfo;
                    //给锁设ID
                    setCTPIDStruct setCTP = new setCTPIDStruct();
                    setCTP.CMD = "init";
                    setCTP.ACCOUNT = netCTPInfo.AccountNo;
                    setCTP.TIME = netCTPInfo.Time;
                    setCTP.LOCK_ID = netCTPInfo.LockNo;
                    setCTP.BLE_MAC = netCTPInfo.BleMac;
                    setCTP.KEY_ID = netCTPInfo.KeyId;
                    setCTP.ROUND = netCTPInfo.Round;
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(setCTP.CMD + setCTP.ACCOUNT + setCTP.TIME + setCTP.ROUND + setCTP.KEY_ID));
                    setCTP.SIGN = BitConverter.ToString(output).Replace("-", "");

                    string sendMessage =
                        setCTP.CMD + "," + setCTP.ACCOUNT + ","
                        + setCTP.TIME + "," + setCTP.LOCK_ID + ","
                        + setCTP.BLE_MAC + "," + setCTP.KEY_ID + ","
                        + setCTP.ROUND + "," + setCTP.SIGN;
                    writeDataToPort(Encoding.Default.GetBytes(sendMessage));//等待返回
                                                                            //等待上报
                }
                else
                {
                    IDRecordResult_textBox7.ForeColor = Color.Red;
                    IDRecordResult_textBox7.BackColor = Color.LightPink;
                    IDRecordResult_textBox7.Text = "ID设置失败";
                    errorShow(setIDReturn.StatusCode);
                    return;
                }
            }
            catch(Exception ex)
            {
                IDRecordResult_textBox7.ForeColor = Color.Red;
                IDRecordResult_textBox7.BackColor = Color.LightPink;
                IDRecordResult_textBox7.Text = "ID设置失败";
                netStatus_textBox4.AppendText(DateTime.Now.ToString() + "\r\nID设置失败：" + ex.Message + "\r\n\r\n");
            }
        }

        public async void IDRecordCTPReturn(string returnString)//录入ID时CTP返回
        {
            if (returnString.Length != 14 && returnString.Substring(2, 1) != "," && returnString.Substring(6, 1) != ",")
            {
                netStatus_textBox4.AppendText(DateTime.Now.ToString() + "\r\n收到地锁数据错误：" + returnString + "\r\n\r\n");
                return;
            }
            try
            {
                netBCStruct2_1 BC = new netBCStruct2_1();//解析收到的车锁信息
                BC.AccountNo = netCommenRoot.AccountNo;
                BC.LockNo = netCTPInfo.LockNo;
                BC.Status = setIDReturn.StatusCode;
                BC.Token = netCommenRoot.Token;
                BC.Voltage = returnString.Substring(3, 3);
                BC.Status = returnString.Substring(7, 8);

                netCommenBCReturnStruct0 BCR = new netCommenBCReturnStruct0();//接收
                BCR = await HttpClientDoPost<netCommenBCReturnStruct0>(BC, "LockInitStatusUpload");

                if (BCR.StatusCode == "200")
                {
                    textBox4.ForeColor = Color.Black;
                    IDRecordResult_textBox7.ForeColor = Color.DarkOliveGreen;
                    IDRecordResult_textBox7.BackColor = Color.LightBlue;
                    IDRecordResult_textBox7.Text = "ID设置成功";
                }
                else
                {
                    IDRecordResult_textBox7.ForeColor = Color.Red;
                    IDRecordResult_textBox7.BackColor = Color.LightPink;
                    IDRecordResult_textBox7.Text = "ID设置失败";
                    errorShow(BCR.StatusCode);
                    return;
                }
            }
            catch(Exception ex)
            {
                IDRecordResult_textBox7.ForeColor = Color.Red;
                IDRecordResult_textBox7.BackColor = Color.LightPink;
                IDRecordResult_textBox7.Text = "ID设置失败";
                netStatus_textBox4.AppendText(DateTime.Now.ToString() + "\r\nID设置失败：" + ex.Message + "\r\n\r\n");
            }
        }

        public void errorShow(string errorCode)
        {
            string errorString;
            switch (errorCode)
            {
                case "10001":
                    errorString = "失败";
                    break;
                case "10002":
                    errorString = "未登录";
                    break;
                case "10003":
                    errorString = "用户名或密码错误";
                    break;
                case "10004":
                    errorString = "地锁已经初始化";
                    break;
                case "10005":
                    errorString = "地锁信息未找到";
                    break;
                case "10006":
                    errorString = "地锁ID变更已经收到响应";
                    break;
                case "10007":
                    errorString = "无效的参数";
                    break;
                case "10008":
                    errorString = "无记录或数据";
                    break;
                case "10009":
                    errorString = "程序版本已过期";
                    break;
                case "10010":
                    errorString = "发现重复记录";
                    break;
                default:
                    return;
            }
            netStatus_textBox4.AppendText(DateTime.Now.ToString() + "\r\nID设置失败：" + errorString + "\r\n\r\n");
            return;
        }

        public async void openLock()
        {
            try
            {
                getLockID getID = new getLockID();//根据MAC获取ID
                getID.AccountNo = netCommenRoot.AccountNo;
                getID.Token = netCommenRoot.Token;
                getID.BleMac = connectedMacString;

                getLockIDReturn getIDReturn = new getLockIDReturn();
                getIDReturn = await HttpClientDoPost<getLockIDReturn>(getID, "GetLockNoByBleMac");

                if (getIDReturn.StatusCode != "200")
                {
                    errorShow(getIDReturn.StatusCode);
                    CTPOCStatus_textBox7.ForeColor = Color.Red;
                    CTPOCStatus_textBox7.BackColor = Color.LightPink;
                    CTPOCStatus_textBox7.Text = "失败";
                    return;
                }

                netOpenStruct3 netOpen = new netOpenStruct3();//请求开锁信息
                netOpen.AccountNo = netCommenRoot.AccountNo;
                netOpen.Token = netCommenRoot.Token;
                netOpen.LockNo = getIDReturn.LockInfo.lockNo;

                netOpenReturnStruct3 netOpenR = new netOpenReturnStruct3();
                netOpenR = await HttpClientDoPost<netOpenReturnStruct3>(netOpen, "OpenLock");

                if (netOpenR.StatusCode == "200")
                {
                    netCTPInfoOCStruct netOCInfo = new netCTPInfoOCStruct();
                    netOCInfo = netOpenR.Info;//得到开锁命令
                    setCTPOCStruct CTPOpen = new setCTPOCStruct();
                    CTPOpen.CMD = "open";
                    CTPOpen.ACCOUNT = "13912345678";//netOCInfo.AccountNo;
                    CTPOpen.TIME = "1510132699"; //netOCInfo.Time;
                    CTPOpen.ROUND = "456";// netOCInfo.Round;
                    CTPOpen.KEY_ID = netOCInfo.KeyId;//发送时不用
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(CTPOpen.CMD + CTPOpen.ACCOUNT + CTPOpen.TIME + CTPOpen.ROUND + CTPOpen.KEY_ID));
                    CTPOpen.SIGN = BitConverter.ToString(output).Replace("-", "");

                    string sendMessage =
                     CTPOpen.CMD + "," + CTPOpen.ACCOUNT + ","
                     + CTPOpen.TIME + "," + CTPOpen.ROUND + ","
                     + CTPOpen.SIGN;
                    byte[] tData = Encoding.Default.GetBytes(sendMessage);
                    writeToBLE(tData);
                    //writeDataToPort(tData);//发送开锁命令

                    CTPOCStatus_textBox7.ForeColor = Color.DarkOliveGreen;
                    CTPOCStatus_textBox7.BackColor = Color.LightBlue;
                    CTPOCStatus_textBox7.Text = "开锁发送";
                }
                else
                {
                    errorShow(netOpenR.StatusCode);
                    CTPOCStatus_textBox7.ForeColor = Color.Red;
                    CTPOCStatus_textBox7.BackColor = Color.LightPink;
                    CTPOCStatus_textBox7.Text = "失败";
                }
            }
            catch(Exception ex)
            {
                CTPOCStatus_textBox7.ForeColor = Color.Red;
                CTPOCStatus_textBox7.BackColor = Color.LightPink;
                CTPOCStatus_textBox7.Text = "开锁错误";
                netStatus_textBox4.AppendText(DateTime.Now.ToString() + "\r\n开锁请求返回失败：" + ex.Message + "\r\n\r\n");
            }

        }

        public async void closeLock()
        {
            try
            {
                getLockID getID = new getLockID();//根据MAC获取ID
                getID.AccountNo = netCommenRoot.AccountNo;
                getID.Token = netCommenRoot.Token;
                getID.BleMac = connectedMacString;

                getLockIDReturn getIDReturn = new getLockIDReturn();
                getIDReturn = await HttpClientDoPost<getLockIDReturn>(getID, "GetLockNoByBleMac");

                if (getIDReturn.StatusCode != "200")
                {
                    errorShow(getIDReturn.StatusCode);
                    CTPOCStatus_textBox7.ForeColor = Color.Red;
                    CTPOCStatus_textBox7.BackColor = Color.LightPink;
                    CTPOCStatus_textBox7.Text = "失败";
                    return;
                }

                netCloseStruct4 netClose = new netCloseStruct4();//请求关锁信息
                netClose.AccountNo = netCommenRoot.AccountNo;
                netClose.Token = netCommenRoot.Token;
                netClose.LockNo = getIDReturn.LockInfo.lockNo;

                netCloseReturnStruct4 netCloseR = new netCloseReturnStruct4();
                netCloseR = await HttpClientDoPost<netCloseReturnStruct4>(netClose, "CloseLock");
                if (netCloseR.StatusCode == "200")
                {
                    netCTPInfoOCStruct netOCInfo = new netCTPInfoOCStruct();
                    netOCInfo = netCloseR.Info;//得到关锁命令
                    setCTPOCStruct CTPClose = new setCTPOCStruct();
                    CTPClose.CMD = "close";
                    CTPClose.ACCOUNT = netOCInfo.AccountNo;
                    CTPClose.TIME = netOCInfo.Time;
                    CTPClose.ROUND = netOCInfo.Round;
                    CTPClose.KEY_ID = netOCInfo.KeyId;//发送时不用
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(CTPClose.CMD + CTPClose.ACCOUNT + CTPClose.TIME + CTPClose.ROUND + CTPClose.KEY_ID));
                    CTPClose.SIGN = BitConverter.ToString(output).Replace("-", "");

                    string sendMessage =
                     CTPClose.CMD + "," + CTPClose.ACCOUNT + ","
                     + CTPClose.TIME + "," + CTPClose.ROUND + ","
                     + CTPClose.SIGN;
                    writeToBLE(Encoding.Default.GetBytes(sendMessage));
                    //writeDataToPort(Encoding.Default.GetBytes(sendMessage));//发送开锁命令

                    CTPOCStatus_textBox7.ForeColor = Color.DarkOliveGreen;
                    CTPOCStatus_textBox7.BackColor = Color.LightBlue;
                    CTPOCStatus_textBox7.Text = "关锁发送";
                }
                else
                {
                    errorShow(netCloseR.StatusCode);
                    CTPOCStatus_textBox7.ForeColor = Color.Red;
                    CTPOCStatus_textBox7.BackColor = Color.LightPink;
                    CTPOCStatus_textBox7.Text = "失败";
                }
            }
            catch (Exception ex)
            {
                CTPOCStatus_textBox7.ForeColor = Color.Red;
                CTPOCStatus_textBox7.BackColor = Color.LightPink;
                CTPOCStatus_textBox7.Text = "关锁错误";
                netStatus_textBox4.AppendText(DateTime.Now.ToString() + "\r\n关锁请求返回失败：" + ex.Message + "\r\n\r\n");
            }

        }

        public async Task<T> HttpClientDoPost<T>(Object dataClass, string tURL)
        {
            //检测网络是否连接
            try
            {
                string urlTest = "http://www.baidu.com";
                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(urlTest);
                //System.Net.WebResponse myResponse = myRequest.GetResponse();
            }
            catch (System.Net.WebException)
            {
                netStatus_textBox4.AppendText(DateTime.Now.ToString() + "\r\n未联网，请检查网络连接\r\n\r\n");
                return default(T);
            }

            netGoOn = false;

            string dataJson = JsonConvert.SerializeObject(dataClass);

            string url = "http://101.37.117.100:4020/Parking/" + tURL;
            HttpClientHandler handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None };

            using (HttpClient httpclient = new HttpClient(handler))
            {
                httpclient.BaseAddress = new Uri(url);

                try
                {
                    HttpResponseMessage response = httpclient.PostAsync(url, new StringContent(dataJson, Encoding.UTF8, "application/json")).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        netStatus_textBox4.AppendText(DateTime.Now.ToString() + "\r\n" + tURL + "失败" + "\r\n\r\n");
                    }
                    else
                    {
                        netStatus_textBox4.AppendText(DateTime.Now.ToString() + "\r\n" + tURL + "成功" + "\r\n\r\n");
                        string responseString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(responseString);
                    }
                }
                catch (Exception e)
                {
                    netStatus_textBox4.AppendText(DateTime.Now.ToString() + "\r\n" + tURL + "连接失败：" + e.Message + "\r\n\r\n");
                }
                return default(T);
            }
        }

        public void setEnable(bool open)
        {
            IDRecord.Enabled = open;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            comboBox1.Items.Clear();
            portArr = System.IO.Ports.SerialPort.GetPortNames().Distinct().ToArray();
            baudRateArray = new string[] {"600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "56000", "57600", "115200", "128000"};
            dataLengthArray = new string[] {"5", "6", "7", "8"};
            stopBitsArray = new string[] {"1", "2"};
            parityTypeArray = new string[] {"NONE", "EVEN", "ODD", "ZERO", "ONE"};
            loginTypeArray = new string[] { "工厂模式", "测试模式" };
            comboBox1.Items.AddRange(portArr);
            comboBox2.Items.AddRange(baudRateArray);
            comboBox3.Items.AddRange(dataLengthArray);
            comboBox4.Items.AddRange(stopBitsArray);
            comboBox5.Items.AddRange(parityTypeArray);
            loginType_comboBox6.Items.AddRange(loginTypeArray);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 10;
            comboBox3.SelectedIndex = 3;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            loginType_comboBox6.SelectedIndex = 0;
            foundCount = 0;
            //publicObject = new Object();
            netGoOn = false;
            listViewFreshStyle.Checked = true;
            operationState_checkBox1.Enabled = false;
            operationState_checkBox1.Checked = false;
            tempCommendList = new List<byte>();
            periList = new List<periStruct>();
            //connectedPeriList = new List<periStruct>();
            HexSend_checkBox1.Checked = true;
            freshSerialPort();
            serialPort.ReceivedBytesThreshold = 1;
            serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(readDataFromSerialPort_Event);
            send.Enabled = false;
            //connectHold_checkBox1.Checked = true;
            operationOpen(false);
            openSwitch.Text = "打开串口";
            HexSendBLE_checkBox1.Checked = true;
            BLESwitch(false);
            BLEConnectTip = false;
            notifyStore = new byte[2];
            testModeZone.Visible = false;
            autoConnect_checkBox1.Enabled = true;
            autoConnect();
            search.Enabled = false;
            progressBar2.Visible = false;
            progressBar1.Visible = false;
            paraSet_groupBox8.Visible = false;
            IMax = IMaxD;
            VMax = VMaxD;
            VMin = VMinD;
            IMax_textBox4.Text = IMax.ToString();
            VMax_textBox5.Text = VMax.ToString();
            VMin_textBox6.Text = VMin.ToString();
            netGoOn = false;
            loginIn();
            textBox6.Text = textBox5.Text;
            setEnable(false);
        }

        private void send_textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (send_textBox2.TextLength != 0 && serialPort.IsOpen == true)
                send.Enabled = true;
            else
                send.Enabled = false;
        }

        private void send_Click(object sender, EventArgs e)
        {
            sent();
        }

        private void sent()
        {
            if (send_textBox2.TextLength > 0)
            {
                sent_textBox2.AppendText(DateTime.Now.ToString() + "\r\n");
                if (HexSend_checkBox1.Checked == true)
                {
                    byte[] tempBytes = System.Text.Encoding.Default.GetBytes(send_textBox2.Text.Replace(" ", ""));
                    for (int i = 0; i < tempBytes.Length; i++)//转换数组，减
                    {
                        if (tempBytes[i] > 47 && tempBytes[i] < 58)
                            tempBytes[i] -= 48;
                        else if (tempBytes[i] > 96 && tempBytes[i] < 103)
                            tempBytes[i] -= 87;
                        else if (tempBytes[i] > 64 && tempBytes[i] < 71)
                            tempBytes[i] -= 55;
                        else
                            return;
                    }
                    byte[] newBytes = new byte[(tempBytes.Length + 1) / 2];//两两合并生成new
                    for (int i = 0; i < tempBytes.Length; i++)//合并
                    {
                        newBytes[i / 2] |= (byte)((tempBytes[i] & 0xff) << (4 * (1 - (i % 2))));
                    }
                    try
                    {
                        writeDataToPort(newBytes);
                    }
                    catch (Exception ex)
                    {
                        sent_textBox2.AppendText(ex.Message + "\r\n\r\n");
                    }
                }
                else
                {
                    serialPort.Write(send_textBox2.Text);
                    sent_textBox2.AppendText("  " + send_textBox2.Text + "\r\n\r\n");
                }
                if (clearAfterSend_checkBox1.Checked == true)
                    send_textBox2.Text = "";
            }
        }

        private void writeDataToPort(byte[] tNewBytes)
        {
            serialPort.Write(tNewBytes, 0, tNewBytes.Length);//发送
            sent_textBox2.AppendText("0x ");//再现
            for (int i = 0; i < tNewBytes.Length; i++)
                sent_textBox2.AppendText(tNewBytes[i].ToString("x2") + " ");
            sent_textBox2.AppendText("\r\n\r\n");
        }

        private void operationStateOpen(bool open)
        {
            send_textBox2.Enabled = open;
            HexSend_checkBox1.Enabled = open;
            HexReciveShow_checkBox1.Enabled = open;
            clearAfterSend_checkBox1.Enabled = open;
            clearRecive.Enabled = open;
            pauseRecive_checkBox1.Enabled = open;
            clearSendRecoed.Enabled = open;
            searchHold.Enabled = open;
            returnMacList.Enabled = open;
            connect.Enabled = open;
            search.Enabled = open;
            if (open == true && send_textBox2.TextLength != 0)
                send.Enabled = true;
            else
                send.Enabled = false;
            if (open == false)
            {
                connectPeri.Enabled = open;
                disconnectPeri.Enabled = open;
                test1.Enabled = open;
                test2.Enabled = open;
            }
        }
        private void operationOpen(bool open)
        {
            if (autoConnect_checkBox1.Checked == true || oneButton_checkBox1.Checked == true)
                open = false;

            if (open == true)
                freshSerialPort();

            operationStateOpen(open);
        }

        private void send_textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(HexSend_checkBox1.Checked == true)
                e.Handled = "0123456789ABCDEFabcdef\b\r^A^C^V^X".IndexOf(char.ToUpper(e.KeyChar)) < 0;
        }

        private void freshPort_Click(object sender, EventArgs e)
        {
            portArr = null;
            comboBox1.Items.Clear();
            portArr = System.IO.Ports.SerialPort.GetPortNames().Distinct().ToArray();
            comboBox1.Items.AddRange(portArr);
            comboBox1.SelectedIndex = 0;
        }

        private void HexSend_checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            send_textBox2.Text = "";
            HexReciveShow_checkBox1.Checked = HexSend_checkBox1.Checked;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                portName_textBox2.Text = comboBox1.SelectedItem.ToString();
                serialPort.Close();
                operationOpen(serialPort.IsOpen);
                openSwitch.Text = "打开串口";
            }
            catch
            { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            operationOpen(serialPort.IsOpen);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            operationOpen(serialPort.IsOpen);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            operationOpen(serialPort.IsOpen);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            operationOpen(serialPort.IsOpen);
        }

        private void openSPort_CheckedChanged(object sender, EventArgs e)
        {
            if(openSwitch.Checked == true)
            {
                freshSerialPort();
                operationOpen(serialPort.IsOpen);
                openSwitch.Text = "关闭串口";
            }
            else
            {
                serialPort.Close();
                operationOpen(serialPort.IsOpen);
                openSwitch.Text = "打开串口";
            }
        }

        private void autoConnect_checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            autoConnect();
        }

        private void autoConnect()
        {
            if (autoConnect_checkBox1.Checked == true || oneButton_checkBox1.Checked == true)
            {
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                openSwitch.Enabled = false;
                freshSerialPort();
                operationOpen(true);
                comboBox2.SelectedIndex = 10;
                comboBox3.SelectedIndex = 3;
                comboBox4.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;

                Thread thread2 = new Thread(new ThreadStart(threadLoop));
                thread2.Start();
            }
            else
            {
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                openSwitch.Enabled = true;
                openSwitch.Checked = true;
            }
        }

        private void threadLoop()//自动搜索大循环
        {
            progressBar2.Style = ProgressBarStyle.Marquee;
            bool loopTip = true;
            while((autoConnect_checkBox1.Checked == true || oneButton_checkBox1.Checked == true) && loopTip == true)
            {
                //刷新
                portArr = null;
                comboBox1.Items.Clear();
                portArr = System.IO.Ports.SerialPort.GetPortNames().Distinct().ToArray();
                comboBox1.Items.AddRange(portArr);
                comboBox1.SelectedIndex = 0;

                int arrLength = 0;
                for (int i = 0; i < (arrLength = portArr.Length); i++)
                {
                    if (autoConnect_checkBox1.Checked == false && oneButton_checkBox1.Checked == false)
                        return;
                    comboBox1.SelectedIndex = i;
                    textBox1.Text = "搜索中...\r\n" + comboBox1.SelectedItem.ToString();
                    textBox1.BackColor = Color.PapayaWhip;
                    textBox1.ForeColor = Color.DarkGoldenrod;
                    if (freshSerialPort() == 0)//打开正常
                    {
                        byte[] checkArr = { 0xff,0xaa };
                        try
                        {
                            serialPort.Write(checkArr, 0, 2);
                            System.Threading.Thread.Sleep(300);//延时500毫秒等待接受
                            byte[] reciveArr = { 0xaa, 0xaa, 0x00 };//判断
                            if (dataArray != null && Enumerable.SequenceEqual(dataArray, reciveArr) == true)
                            {
                                search.Enabled = true;
                                textBox1.Text = "连接成功, \r\n串口号为：\r\n" + serialPort.PortName; 
                                textBox1.BackColor = Color.Chartreuse;
                                textBox1.ForeColor = Color.Black;
                                progressBar2.Style = ProgressBarStyle.Continuous;
                                progressBar2.Minimum = 0;
                                progressBar2.Maximum = 100;
                                progressBar2.Value = 100;
                                autoConnect_checkBox1.Checked = false;
                                freshSerialPort();
                                dataArray = null;
                                operationOpen(serialPort.IsOpen);
                                if (oneButton_checkBox1.Checked == true)
                                {
                                    Thread.Sleep(1000);
                                    comboBox1.Enabled = false;
                                    searchPeri();
                                }
                                //搜索
                                recive_textBox3.BackColor = Color.PapayaWhip;
                                recive_textBox3.ForeColor = Color.DarkGoldenrod;
                                disconnectBLE();
                                BLESwitch(false);
                                searchPeri();
                                return;
                            }
                        }
                        catch { };
                    }
                    else
                    {
                        textBox1.Text = "连接出现错误";
                        autoConnect_checkBox1.Checked = false;
                        oneButton_checkBox1.Checked = false;
                    }
                }
            }
        }

        private void clearRecive_Click(object sender, EventArgs e)
        {
            recive_textBox3.Text = "";
            reciveShow.Text = "";
            textBox3.Text = "";
        }

        private void clearSendRecord_Click(object sender, EventArgs e)
        {
            sent_textBox2.Text = "";
        }

        /*private bool sendAndRecive(byte sendType, byte[] sendData, byte reciveType, byte[] reciveData, string resultStringIfSuccess, int sleepingTime)//牛逼收发总函数
        {
            byte[] sendArr = transWordToSend(sendType, sendData);//发送验证信息
            try
            {
                serialPort.Write(sendArr, 0, sendArr.Length);
                sent_textBox2.AppendText(DateTime.Now.ToString() + "\r\n");
                sent_textBox2.AppendText("0x ");//再现
                for (int j = 0; j < sendArr.Length; j++)
                    sent_textBox2.AppendText(sendArr[j].ToString("x2") + " ");
                sent_textBox2.AppendText("\r\n-> " + comboBox1.SelectedItem.ToString() + "\r\n\r\n");
            }
            catch(Exception ex)//如果出错
            {
                operationResult_textBox2.AppendText(ex.Message + "\r\n\r\n");
                return false;
            }

            System.Threading.Thread.Sleep(sleepingTime);//延时800毫秒等待接收

            if (dataArray != null && Enumerable.SequenceEqual(dataArray, sendArr) == false)//如果收到回应
            {
                //判断
                byte[] reciveCheckArray = transWordToRecive(reciveType, reciveData);//接收验证消息
                if (Enumerable.SequenceEqual(dataArray, reciveCheckArray))//0xa5ff0001aaaafa28
                {
                    operationResult_textBox2.AppendText(DateTime.Now.ToString() + "\r\n");

                    //recive_textBox3.AppendText(DateTime.Now.ToString() + ":\r\n");
                    operationResult_textBox2.AppendText("0x ");
                    for (int i = 0; i < dataArray.Length; i++)
                        operationResult_textBox2.AppendText(dataArray[i].ToString("x2") + " ");
                    //operationResult_textBox2.AppendText("\r\n" + comboBox1.SelectedItem.ToString() + " ->\r\n\r\n");
                    operationResult_textBox2.AppendText("\r\n" + resultStringIfSuccess + "\r\n\r\n");//操作窗信息

                    return true;
                }
            }
            return false;
        }
        
        private byte[] transWordToSend(byte commend, byte[] numberArr)
        {
            int byteLength;
            if (numberArr == null)
                byteLength = 0;
            else
                byteLength = numberArr.Length;
            if (byteLength > 0xfe)//超长
                return null;
            byte[] result = new byte[byteLength + 7];
            result[0] = 0xff;
            result[1] = commend;
            result[3] = (byte)byteLength;
            //result[4] = type;
            for(int i = 0; i < byteLength; i++)
            {
                result[i + 5] = numberArr[i];
            }
            UInt16 CRCNumber = comCalCRC16(result, 2, (uint)byteLength + 3);
            result[byteLength + 6] |= (byte)(CRCNumber & 0xff);
            result[byteLength + 5] |= (byte)((CRCNumber >> 8) & 0xff);
            return result;
        }

        private byte[] transWordToRecive(byte type, byte[] numberArr)
        {
            int byteLength = 0;
            if (numberArr == null)
                byteLength = 0;
            else
                byteLength = numberArr.Length;
            if (byteLength > 0xfe)//超长
                return null;
            byte[] result = new byte[byteLength + 7];
            result[0] = 0xa5;
            result[1] = 0xff;
            result[3] = (byte)(byteLength & 0xff);
            result[2] = (byte)((byteLength >> 8) & 0xff);
            result[4] = type;
            for (int i = 0; i < byteLength; i++)
            {
                result[i + 5] = numberArr[i];
            }
            UInt16 CRCNumber = comCalCRC16(result, 0, (uint)byteLength + 5);//验证result从头开始到CRC前位置
            result[byteLength + 6] |= (byte)(CRCNumber & 0xff);
            result[byteLength + 5] |= (byte)((CRCNumber >> 8) & 0xff);
            return result;
        }
        
        private void closeWindow_Click(object sender, EventArgs e)
        {
            byte[] sendArr = { 0x00 };//发送验证信息
            sendAndRecive(0xf0, null, 0xff, sendArr, "蓝牙设置窗口关闭", 2000);
        }*/

        private void clearOperationResult_Click(object sender, EventArgs e)
        {
            operationResult_textBox2.Text = "";
        }

        private void send_textBox2_TextChanged(object sender, EventArgs e)
        {
            if (send_textBox2.TextLength > 1)//回车发送
                if (send_textBox2.Text.Substring(send_textBox2.TextLength - 2, 2) == "\r\n")
                {
                    send_textBox2.Text = send_textBox2.Text.Substring(0, send_textBox2.Text.Length - 2);
                    send_textBox2.SelectionStart = send_textBox2.Text.Length;
                    send_textBox2.Focus();
                    sent();
                }
        }
        /*
        private UInt16 calCrc16(Byte[] buf, UInt32 start, UInt32 len)//CRC校验
        {
            UInt16 crc16 = 0xFFFF;
            UInt32 iLoop;
            UInt32 iLoop1;

            for (iLoop = 0; iLoop < len; iLoop++)
            {
                crc16 ^= buf[start + iLoop];
                for (iLoop1 = 0; iLoop1 < 8; iLoop1++)
                {
                    if ((crc16 & 1) == 1)
                    {
                        crc16 >>= 1;
                        crc16 ^= 0x8408;
                    }
                    else
                    {
                        crc16 >>= 1;
                    }
                }
            }
            crc16 ^= 0xffff;
            return crc16;
        }

        private UInt16 comCalCRC16(byte[] pucBuf,UInt32 start , UInt32 uwLength)////////CRC16校验
        {
            UInt16 uiCRCValue = 0xFFFF;
            UInt32 ucLoop;
            //uint8_t* pu8Buf = (uint8_t *)pucBuf;

            for(int i = 0; i < uwLength; i++)
            {
                uiCRCValue ^= pucBuf[i + start];
                for (ucLoop = 0; ucLoop < 8; ucLoop++)
                {
                    if ((uiCRCValue & 0x0001) != 0)
                    {
                        uiCRCValue >>= 1;
                        uiCRCValue ^= 0x8408;
                    }
                    else
                    {
                        uiCRCValue >>= 1;
                    }
                }
            }
            uiCRCValue ^= 0xFFFF;
            return uiCRCValue;
        } */

        private void readDataFromSerialPort_Event(object sender, EventArgs eventArgs)
        {
            try
            {
                if (pauseRecive_checkBox1.Checked == false)
                {
                    dataArray = null;
                    int dataLength = serialPort.BytesToRead;
                    dataArray = new byte[dataLength];
                    System.Threading.Thread.Sleep(100);//延时100毫秒等待接收
                    serialPort.Read(dataArray, 0, dataLength);
                    tempReciveString = Encoding.Default.GetString(dataArray);
                    dealTheRecivedData();
                    if (autoConnect_checkBox1.Checked == false)
                    {
                        recive_textBox3.AppendText(string.Format("{0:G}", DateTime.Now) + "\r\n");

                        if (HexReciveShow_checkBox1.Checked == true)
                        {
                            recive_textBox3.AppendText("0x ");
                            for (int i = 0; i < dataArray.Length; i++)
                                recive_textBox3.AppendText(dataArray[i].ToString("x2") + " ");
                            recive_textBox3.AppendText("\r\n\r\n");
                        }
                        else
                        {
                            recive_textBox3.AppendText(" " + tempReciveString + "\r\n\r\n");
                        }
                    }
                }
            }
            catch
            { }
        }

        private void searchLoop()
        {

            while (searchHold.Checked == true || oneButton_checkBox1.Checked == true)
            {
                Thread.Sleep(2000);//搜索间隔
                try
                {
                    byte[] newBytes = { 0xff, 0x01 };
                    serialPort.Write(newBytes, 0, 2);//发送
                    sent_textBox2.AppendText("0x ");//再现
                    for (int i = 0; i < newBytes.Length; i++)
                        sent_textBox2.AppendText(newBytes[i].ToString("x2") + " ");
                    sent_textBox2.AppendText("\r\n\r\n");
                    newBytes = null;
                }
                catch (Exception ex)
                {
                    sent_textBox2.AppendText(ex.Message + "\r\n\r\n");
                }
            }
        }

        private void returnMacList_Click(object sender, EventArgs e)
        {
            returnPeriMacList();
        }

        private void returnPeriMacList()
        {
            try
            {
                if (listViewFreshStyle.Checked == true)
                {
                    periList.Clear();
                    listView1.Items.Clear();
                }
                byte[] newBytes = { 0xff, 0x02 };
                serialPort.Write(newBytes, 0, 2);//发送
                sent_textBox2.AppendText("0x ");//再现
                for (int i = 0; i < newBytes.Length; i++)
                    sent_textBox2.AppendText(newBytes[i].ToString("x2") + " ");
                sent_textBox2.AppendText("\r\n\r\n");
                newBytes = null;
            }
            catch (Exception ex)
            {
                sent_textBox2.AppendText(ex.Message + "\r\n\r\n");
            }
        }

        private void dealTheRecivedData()
        {
            int i = 0;
            int numberCount = 0;
            if(tempCommendList.Count > 0)//如果有残渣
            {
                if (tempCommendList.Count < 3)
                    for (; i < Math.Min(3 - tempCommendList.Count + 1, dataArray.Length); i++)
                        tempCommendList.Add(dataArray[i]);
                numberCount = tempCommendList[2];
                int tI = i;
                for (; i < Math.Min(numberCount + tI, dataArray.Length); i++)
                    tempCommendList.Add(dataArray[i]);

                if(numberCount + 3 <= tempCommendList.Count)
                {
                    textBox3.AppendText(BitConverter.ToString(tempCommendList.ToArray(), 0) + "\r\n\r\n");//string.Join(",",tempCommendList.ToArray())
                    dealTheCommend(tempCommendList.ToArray());
                    tempCommendList.Clear();
                }
            }

            while (i < dataArray.Length)
            {
                if (dataArray[i] == 0xaa)
                {
                    if (i + 3 < dataArray.Length && dataArray[i + 2] + i + 3 <= dataArray.Length)
                    {
                        int tI = dataArray[i + 2] + i + 3;//应有长度
                        tempCommendList.Clear();
                        for (; i < tI; i++)
                            tempCommendList.Add(dataArray[i]);
                        textBox3.AppendText(BitConverter.ToString(tempCommendList.ToArray(), 0) + "\r\n\r\n");//string.Join(",",tempCommendList.ToArray())
                        dealTheCommend(tempCommendList.ToArray());
                        tempCommendList.Clear();
                    }
                    else
                    {
                        for (; i < dataArray.Length; i++)
                            tempCommendList.Add(dataArray[i]);
                        return;
                    }
                }
                else
                    i++;
            }
            
        }

        private void search_Click(object sender, EventArgs e)
        {
            recive_textBox3.BackColor = Color.PapayaWhip;
            recive_textBox3.ForeColor = Color.DarkGoldenrod;
            disconnectBLE();
            BLESwitch(false);
            searchPeri();
        }

        private void searchPeri()
        {
            if (searchHold.Checked == true || oneButton_checkBox1.Checked == true)
            {
                Thread thread3 = new Thread(new ThreadStart(searchLoop));
                if (searchHold.Checked == true || oneButton_checkBox1.Checked == true)
                    thread3.Start();
            }
            else
            {
                try
                {
                    byte[] newBytes = { 0xff, 0x06 };
                    serialPort.Write(newBytes, 0, 2);//发送
                    sent_textBox2.AppendText("0x ");//再现
                    for (int i = 0; i < newBytes.Length; i++)
                        sent_textBox2.AppendText(newBytes[i].ToString("x2") + " ");
                    sent_textBox2.AppendText("\r\n\r\n");
                    newBytes = null;
                    periList.Clear();
                }
                catch (Exception ex)
                {
                    sent_textBox2.AppendText(ex.Message + "\r\n\r\n");
                }
            }
        }

        private void oneButton_checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            operationOpen(!oneButton_checkBox1.Checked);
            autoConnect_checkBox1.Enabled = !oneButton_checkBox1.Checked;
            freshPort.Enabled = !oneButton_checkBox1.Checked;
            openSwitch.Enabled = !oneButton_checkBox1.Checked;
            operationState_checkBox1.Enabled = oneButton_checkBox1.Checked;
            autoConnect();
            if (operationState_checkBox1.Checked == false)
                comboBox1.Enabled = true;
        }

        private void operationState_checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            operationStateOpen(operationState_checkBox1.Checked);
            freshPort.Enabled = operationState_checkBox1.Checked;
            autoConnect_checkBox1.Enabled = operationState_checkBox1.Checked;
            openSwitch.Enabled = operationState_checkBox1.Checked;
        }

        private void connectPeri_Click(object sender, EventArgs e)
        {
            connectBLE();
        }

        private void connectBLE()
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int index = listView1.SelectedIndices[0];
                try
                {
                    byte[] newBytes = new byte[8];
                    newBytes[0] = 0xff;
                    newBytes[1] = 0x07;
                    //newBytes[2] = (byte)index;
                    Array.Copy(periList[index].periAddr, 0, newBytes, 2, 6);
                    serialPort.Write(newBytes, 0, newBytes.Length);//发送
                    sent_textBox2.AppendText("0x ");//再现
                    for (int i = 0; i < newBytes.Length; i++)
                        sent_textBox2.AppendText(newBytes[i].ToString("x2") + " ");
                    sent_textBox2.AppendText("\r\n\r\n");
                    periResult_textBox2.AppendText("发起连接: " + BitConverter.ToString(newBytes) + "\r\n\r\n");
                }
                catch (Exception ex)
                {
                    sent_textBox2.AppendText(ex.Message + "\r\n\r\n");
                }
            }
        }

        private void disconnectBLE()
        {
            try
            {
                byte[] newBytes = new byte[2];
                newBytes[0] = 0xff;
                newBytes[1] = 0x08;
                serialPort.Write(newBytes, 0, newBytes.Length);//发送
                sent_textBox2.AppendText("0x ");//再现
                for (int i = 0; i < newBytes.Length; i++)
                    sent_textBox2.AppendText(newBytes[i].ToString("x2") + " ");
                sent_textBox2.AppendText("\r\n\r\n");
                periResult_textBox2.AppendText("断开连接中...\r\n\r\n");
            }
            catch (Exception ex)
            {
                sent_textBox2.AppendText(ex.Message + "\r\n\r\n");
            }
        }
        private void disconnectPeri_Click(object sender, EventArgs e)
        {
            disconnectBLE();
        }

        private void freshRSSI()
        {
            try
            {
                byte[] newBytes = new byte[2];
                newBytes[0] = 0xff;
                newBytes[1] = 0x04;
                serialPort.Write(newBytes, 0, newBytes.Length);//发送
                sent_textBox2.AppendText("0x ");//再现
                for (int i = 0; i < newBytes.Length; i++)
                    sent_textBox2.AppendText(newBytes[i].ToString("x2") + " ");
                sent_textBox2.AppendText("\r\n\r\n");
                periResult_textBox2.AppendText("刷新RSSI\r\n\r\n");
                BLESwitch(false);
            }
            catch (Exception ex)
            {
                sent_textBox2.AppendText(ex.Message + "\r\n\r\n");
            }
        }

        private void freshConnectPeri_Click(object sender, EventArgs e)
        {
            freshRSSI();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //foreach (ListViewItem lv in listView1.Items)
                //lv.Checked = lv.Selected;
            /*if(listView1.FocusedItem != null)
            {
                int index = listView1.FocusedItem.Index;
                foreach (ListViewItem lv in listView1.Items)
                    lv.Checked = false;

                listView1.Items[index].Checked = true;
            }*/
        }

        private void sendBLE_textBox2_TextChanged(object sender, EventArgs e)
        {
            if (sendBLE_textBox2.TextLength > 1)
                if (sendBLE_textBox2.Text.Substring(sendBLE_textBox2.TextLength - 2, 2) == "\r\n")
                {
                    sendBLE_textBox2.Text = sendBLE_textBox2.Text.Substring(0, sendBLE_textBox2.Text.Length - 2);
                    sendBLE_textBox2.SelectionStart = sendBLE_textBox2.Text.Length;
                    sendBLE_textBox2.Focus();
                    sent();
                }
        }

        private void sendBLE_Click(object sender, EventArgs e)
        {
            if (sendBLE_textBox2.TextLength > 0)
            {
                sent_textBox2.AppendText(DateTime.Now.ToString() + "\r\n");
                if (HexSendBLE_checkBox1.Checked == true)
                {
                    byte[] tempBytes = System.Text.Encoding.Default.GetBytes(sendBLE_textBox2.Text.Replace(" ", ""));
                    for (int i = 0; i < tempBytes.Length; i++)//转换数组，减
                    {
                        if (tempBytes[i] > 47 && tempBytes[i] < 58)
                            tempBytes[i] -= 48;
                        else if (tempBytes[i] > 96 && tempBytes[i] < 103)
                            tempBytes[i] -= 87;
                        else if (tempBytes[i] > 64 && tempBytes[i] < 71)
                            tempBytes[i] -= 55;
                        else
                            return;
                    }
                    byte[] newBytes = new byte[(tempBytes.Length + 1) / 2 + 1];//两两合并生成new
                    newBytes[0] = 0xbb;
                    for (int i = 0; i < tempBytes.Length; i++)//合并
                    {
                        newBytes[i / 2 + 1] |= (byte)((tempBytes[i] & 0xff) << (4 * (1 - (i % 2))));
                    }
                    try
                    {
                        writeDataToPort(newBytes);
                    }
                    catch (Exception ex)
                    {
                        sent_textBox2.AppendText(ex.Message + "\r\n\r\n");
                    }
                }
                else
                    sendStringToBLE(sendBLE_textBox2.Text);
                if (clearAfterSend_checkBox1.Checked == true)
                    sendBLE_textBox2.Text = "";
            }
        }

        private void sendStringToBLE(string data)
        {
            try
            {
                byte[] tempArray = Encoding.Default.GetBytes(data);
                byte[] sendArray = new byte[tempArray.Length + 1];
                sendArray[0] = 0xbb;
                Array.Copy(tempArray, 0, sendArray, 1, tempArray.Length);
                serialPort.Write(sendArray, 0, sendArray.Length);
                sent_textBox2.AppendText("  " + BitConverter.ToString(sendArray) + "\r\n\r\n");
            }
            catch
            {

            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in listView1.Items)
            {
                if (lv.Checked)//取消所有已选中的CheckBoxes  
                {
                    lv.Checked = false;
                }
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if(e.Column == 0)
                listView1.Items[e.Column].Checked = true;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem lv in listView1.Items)
                lv.Selected = false;
            listView1.Items[e.Item.Index].Selected = true;
        }

        private void clearReadBleText_Click(object sender, EventArgs e)
        {
            readBLE_textBox2.Text = "";
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            setEnable(false);
            foreach(periStruct peri in periList)
                if(peri.connectTip == true)
                {
                    disconnectBLE();
                    BLEConnectTip = true;
                    return;
                }
            connectBLE();
        }

        private void read_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] newBytes = new byte[2];
                newBytes[0] = 0xff;
                newBytes[1] = 0x0a;
                serialPort.Write(newBytes, 0, newBytes.Length);//发送
                sent_textBox2.AppendText("0x ");//再现
                for (int i = 0; i < newBytes.Length; i++)
                    sent_textBox2.AppendText(newBytes[i].ToString("x2") + " ");
                sent_textBox2.AppendText("\r\n\r\n");
                //periResult_textBox2.AppendText("读取数据\r\n\r\n");
            }
            catch (Exception ex)
            {
                sent_textBox2.AppendText(ex.Message + "\r\n\r\n");
            }
        }

        private bool dealTheCommend(byte[] tempArray)
        {
            byte[] newArray;
            if (tempArray.Length < 4)
                newArray = null;
            else
            {
                newArray = new byte[tempArray.Length - 3];
                Array.Copy(tempArray, 3, newArray, 0, tempArray.Length - 3);
            }
            try
            {
                return dealTheCommendKernel(tempArray[1], newArray);
            }
            catch(Exception e)
            {
                reciveShow.AppendText(string.Format("{0:G}", DateTime.Now) + "\r\n数据错误:" + e.Message + "\r\n\r\n");
                return false;
            }
        }

        private void openN_Click(object sender, EventArgs e)
        {
            byte[] searchCommend = { 0xff, 0x0b };
            writeDataToPort(searchCommend);
        }

        private void testMode_checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            testModeZone.Visible = testMode_checkBox1.Checked;
        }

        private void testModeZone_VisibleChanged(object sender, EventArgs e)
        {
            listViewFreshStyle.Visible = testModeZone.Visible;
        }

        private void test1_Click(object sender, EventArgs e)
        {
            testWithCover();
            reTestTip = reTestCount;
            reTestType = 1;
        }

        private void testWithCover()
        {
            writeToBLE(Encoding.Default.GetBytes("selftest1"));//有遮挡
            testResult.BackColor = Color.AliceBlue;
            testResult.ForeColor = Color.Black;
            testResult.Text = "\r\n\r\n有遮挡测试中...";
            IShow.BackColor = Color.AliceBlue;
            IShow.ForeColor = Color.Black;
            IShow.Text = "测试中";
            VShow.BackColor = Color.AliceBlue;
            VShow.ForeColor = Color.Black;
            VShow.Text = "测试中";
        }

        private void writeToBLE(byte[] tNewBytes)
        {
            byte[] newBytes = new byte[tNewBytes.Length + 1];
            newBytes[0] = 0xbb;
            Array.Copy(tNewBytes, 0, newBytes, 1, tNewBytes.Length);
            writeDataToPort(newBytes);
        }

        private void IMax_textBox4_Leave(object sender, EventArgs e)
        {
            int tData = 0;
            if (IMax_textBox4.TextLength <= 0)
                IMax = IMaxD;
            else if (int.TryParse(IMax_textBox4.Text, out tData) && tData > 0)
                IMax = tData;
            else
                IMax = IMaxD;

            IMax_textBox4.Text = IMax.ToString();
        }

        private void VMax_textBox5_Leave(object sender, EventArgs e)
        {
            Double tData = 0;
            if (VMax_textBox5.TextLength <= 0)
                VMax = VMaxD;
            else if (Double.TryParse(VMax_textBox5.Text, out tData) && tData >= VMin)
                VMax = tData;
            else
                VMax = VMaxD;

            VMax_textBox5.Text = VMax.ToString();
        }

        private void VMin_textBox6_Enter(object sender, EventArgs e)
        {
            Double tData = 0;
            if (VMin_textBox6.TextLength <= 0)
                VMin = VMinD;
            else if (Double.TryParse(VMin_textBox6.Text, out tData) && tData <= VMax)
                VMin = tData;
            else
                VMin = VMinD;

            VMin_textBox6.Text = VMin.ToString();
        }

        private void login_Click(object sender, EventArgs e)
        {
            loginIn();
        }

        private void paraSet_checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            paraSet_groupBox8.Visible = paraSet_checkBox1.Checked;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if(textBox5.TextLength < 6)
            {
                textBox5.Text = "180510";
                netStatus_textBox4.AppendText(DateTime.Now.ToString() + "\r\n输入错误，ID重置为：" + textBox5.Text + "\r\n\r\n");
            }
            else
                textBox6.Text = textBox5.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox5.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginIn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openLock();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            closeLock();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = "0123456789\b\r".IndexOf(char.ToUpper(e.KeyChar)) < 0;
        }

        private void HexSendBLE_checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (HexSendBLE_checkBox1.Checked == true)
            {
                sendBLE_textBox2.ReadOnly = true;
                string text = sendBLE_textBox2.Text;
                sendBLE_textBox2.Text = "";
                byte[] textBytes = Encoding.Default.GetBytes(text);
                for (int i = 0; i < textBytes.Length; i++)
                    sendBLE_textBox2.AppendText(textBytes[i].ToString("x2") + " ");
                sendBLE_textBox2.ReadOnly = false;
            }
            else
            {
                string text0 = sendBLE_textBox2.Text.Replace(" ", "");//把类16进制string转换为byte[]
                string text = text0.Replace("-", "");
                byte[] tBytes = Encoding.Default.GetBytes(text);

                int bytesCount = ((text.Length + 1) / 2) * 2;//奇数上一位偶数不变算法
                byte[] textBytes = new byte[bytesCount];//最终判断数组

                if (text.Length == bytesCount)
                    Array.Copy(tBytes, textBytes, text.Length);
                else if (text.Length == bytesCount - 1)//靠后拷贝
                {
                    textBytes[0] = 0;
                    Array.Copy(tBytes, 0, textBytes, 1, text.Length);
                }
                else//错误处理，一般不会发生
                    return;

                byte[] transBytes = new byte[bytesCount / 2];

                /* for (int i = 0; i < bytesCount; i++)//判断是否有非法字符
                     if (textBytes[i] < 48 || (textBytes[i] > 57 && textBytes[i] < 65) || (textBytes[i] > 70 && textBytes[i] < 97) || textBytes[i] > 102)
                         return;*/
                for (int i = 0; i < bytesCount; i++)//在把每个字符放进新的转义数组时
                {
                    int diff = 0;//string ASCII差值
                    if (47 < textBytes[i] && textBytes[i] < 58)//数字
                        diff = 48;
                    else if (64 < textBytes[i] && textBytes[i] < 71)//大写
                        diff = 55;
                    else if (96 < textBytes[i] && textBytes[i] < 103)
                        diff = 87;
                    else//错误处理，输入错误
                        diff = textBytes[i];

                    if (i % 2 == 0)//偶数位
                    {
                        transBytes[i / 2] = 0;//清零
                        transBytes[i / 2] |= (byte)((textBytes[i] - diff) << 4);//高位
                    }
                    else//奇数位
                        transBytes[i / 2] |= (byte)(textBytes[i] - diff);//低位
                }
                sendBLE_textBox2.Text = "";
                sendBLE_textBox2.AppendText(Encoding.Default.GetString(transBytes));
            }
        }

        private void sendBLE_textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (HexSendBLE_checkBox1.Checked == true)
            {
                string text = sendBLE_textBox2.Text;
                if (text.Length > 0)
                {
                    byte tByte = Encoding.Default.GetBytes(text)[text.Length - 1];
                    if (tByte < 48 || tByte > 57 && tByte < 65 || tByte > 70 && tByte < 97 || tByte > 102)
                    {
                        sendBLE_textBox2.Text = sendBLE_textBox2.Text.Substring(0, sendBLE_textBox2.Text.Length - 1);
                        sendBLE_textBox2.Focus();
                        sendBLE_textBox2.Select(sendBLE_textBox2.TextLength, 0);
                        sendBLE_textBox2.ScrollToCaret();
                    }
                }
            }
        }

        private void test2_Click(object sender, EventArgs e)
        {
            testWithoutCover();
            reTestTip = reTestCount;
            reTestType = 2;
        }

        private void testWithoutCover()
        {
            writeToBLE(Encoding.Default.GetBytes("selftest1"));//无遮挡
            testResult.BackColor = Color.AliceBlue;
            testResult.ForeColor = Color.Black;
            testResult.Text = "\r\n\r\n无遮挡测试中...";
            IShow.BackColor = Color.AliceBlue;
            IShow.ForeColor = Color.Black;
            IShow.Text = "测试中";
            VShow.BackColor = Color.AliceBlue;
            VShow.ForeColor = Color.Black;
            VShow.Text = "测试中";
        }

        private void returnN_Click(object sender, EventArgs e)
        {
            byte[] searchCommend = { 0xff, 0x0c };
            writeDataToPort(searchCommend);
        }

        private void BLESwitch(bool open)
        {
            sendBLE.Enabled = open;
            readBLE.Enabled = open;
            test1.Enabled = open;
            test2.Enabled = open;
            clearAfterSendBLE_checkBox1.Enabled = open;
            clearSendRecoedBLE.Enabled = open;
            HexSendBLE_checkBox1.Enabled = open;
            if (open == false)
            {
                BLEConnectTip = false;
                disconnectPeri.Enabled = false;
            }
            else
            {
                textBox2.Text = "测试权限获取成功。";
                textBox2.BackColor = Color.Chartreuse;
                textBox2.ForeColor = Color.DarkOliveGreen;
            }
        }

        private bool dealTheCommendKernel(byte type, byte[] array)//读取，显示命令
        {
            //string tText = String.Copy(textBox2.Text);
            //textBox2.Text = "";
            string tempString = null;
            switch(type)
            {
                case 0x00:
                    tempString = "detial:";
                    if(array.Length > 3)
                    {
                        periStruct newPeri1 = periList[array[1]];
                        newPeri1.dataLen = (UInt16)(array[0] - 3);
                        newPeri1.index = array[1];
                        newPeri1.UUID = 0;
                        newPeri1.UUID |= (UInt16)(array[2] | (array[3] << 8));
                        byte[] tempData = new byte[newPeri1.dataLen];
                        if(array.Length - 3 >= newPeri1.dataLen)
                            Array.Copy(array, 4, tempData, 0, tempData.Length);
                        newPeri1.periData = Encoding.Default.GetString(tempData);
                        periList[newPeri1.index] = newPeri1;
                        freshListView();
                    }
                    return true;
                case 0x01:
                    tempString = "Intitialzed";
                    break;
                case 0x02:
                    tempString = "Device Found, scanRes: ";
                    foundCount = array[0];
                    periCount_textBox2.Text = foundCount.ToString();
                    if (oneButton_checkBox1.Checked == true || searchHold.Enabled == true)
                    {
                        Thread.Sleep(300);
                        //returnPeriMacList();
                        freshListView();
                    }
                    if(array[0] == 0)
                    {
                        Thread.Sleep(500);
                        byte[] searchCommend = { 0xff, 0x01 };
                        writeDataToPort(searchCommend);
                    }
                    break;
                case 0x03:
                    tempString = "Connected, devAddr: ";
                    periResult_textBox2.AppendText(tempString + BitConverter.ToString(array) + "\r\n设备已连接，连接读写功能中\r\n\r\n");
                    for (int i = 0; i < periList.Count; i++)
                        if (Enumerable.SequenceEqual(periList[i].periAddr, array))//更新ifConnected
                        {
                            periStruct newPeri1 = periList[i];
                            newPeri1.connectTip = true;
                            periList[i] = newPeri1;
                            connectedMac = new byte[newPeri1.periAddr.Length];
                            Array.Copy(newPeri1.periAddr, connectedMac, newPeri1.periAddr.Length);//拷贝
                            Array.Reverse(connectedMac, 0, connectedMac.Length);//反转
                            connectedMacString = BitConverter.ToString(connectedMac).Replace("-", "").ToUpper();
                            setEnable(true);
                            break;
                        }
                    textBox2.Text = "已连接，获取测试权限中...";
                    textBox2.BackColor = Color.PapayaWhip;
                    textBox2.ForeColor = Color.DarkGoldenrod;
                    freshListView();
                    disconnectPeri.Enabled = true;
                    break;
                case 0x04:
                    tempString = "Connect Faild, reason: ";
                    periResult_textBox2.AppendText(tempString + BitConverter.ToString(array) + "\r\n\r\n");
                    break;
                case 0x05:
                    tempString = "Disconnected, reason: ";
                    periResult_textBox2.AppendText(tempString + BitConverter.ToString(array) + "\r\n\r\n");
                    for (int i = 0; i < periList.Count; i++)
                        if (periList[i].connectTip == true)//更新ifConnected
                        {
                            periStruct newPeri2 = periList[i];
                            newPeri2.connectTip = false;
                            periList[i] = newPeri2;
                            //connectedPeriList.Add(newPeri);
                            break;
                        }
                    textBox2.Text = "连接断开";
                    textBox2.BackColor = Color.MistyRose;
                    textBox2.ForeColor = Color.Firebrick;
                    BLESwitch(false);
                    if(BLEConnectTip == true)
                    {
                        connectBLE();
                        BLEConnectTip = false;
                    }
                    freshListView();
                    break;
                case 0x06:
                    tempString = "Param Update, linkUpdate.status: ";
                    periResult_textBox2.AppendText(tempString + BitConverter.ToString(array) + "\r\n\r\n");
                    freshRSSI();//发出一次命令，芯片会不停返回
                    BLESwitch(true);
                    break;
                case 0x07://发现外设，返回外设地址数组
                    bool addItem = true;
                    tempString = "Device, scanIdx + 1 & addr: ";
                    byte[] tempArray = new byte[6];
                    Array.Copy(array, 1, tempArray, 0, 6);
                    foreach (periStruct peri in periList)
                        if (Enumerable.SequenceEqual(peri.periAddr, tempArray))
                        {
                            addItem = false;
                            break;
                        }
                    if(addItem == true)
                    {
                        periStruct peri = new periStruct();
                        peri.index = array[0];
                        peri.periData = "";
                        peri.periAddr = tempArray;
                        peri.connectTip = false;
                        periList.Add(peri);
                    }
                    if (array[0] >= foundCount)
                        freshListView();
                    break;
                case 0x08:
                    tempString = "Discovering";
                    break;
                case 0x09:
                    tempString = "Connecting, Addr: ";
                    periResult_textBox2.AppendText(tempString + BitConverter.ToString(array) + "\r\n\r\n");
                    break;
                case 0x0a:
                    tempString = "disConnecting";
                    periResult_textBox2.AppendText(tempString + "\r\n\r\n");
                    break;
                case 0x0b:
                    tempString = "RSSI Cancelled";
                    break;
                case 0x0c:
                    tempString = "ATT Rsp: ";
                    break;
                case 0x0d:
                    tempString = "Read Error: ";
                    break;
                case 0x0e:
                    tempString = "Read Rsp: ";//收到数据
                    periResult_textBox2.AppendText(tempString + BitConverter.ToString(array) + "\r\n\r\n");
                    readBLE_textBox2.AppendText(tempString + BitConverter.ToString(array) + "\r\n");
                    readBLE_textBox2.AppendText(tempString + Encoding.Default.GetString(array) + "\r\n\r\n");
                    string resultString = Encoding.Default.GetString(array);

                    if (resultString.Length == 14 && resultString.Substring(2, 1) == "," && resultString.Substring(6, 1) == "1")
                        IDRecordCTPReturn(resultString);//设置上报等

                    else if (Encoding.Default.GetString(array).Contains("ret:"))
                    {
                        switch(array[4])
                        {
                            case 48:
                                testResult.Text = "测试成功";
                                testResult.BackColor = Color.LightGreen;
                                break;
                            case 52:
                                testResult.Text = "测试成功";
                                testResult.BackColor = Color.LightGreen;
                                break;
                            case 49:
                                testResult.Text = "电机故障";
                                testResult.BackColor = Color.LightPink;
                                break;
                            case 50:
                                testResult.Text = "红外1故障";
                                testResult.BackColor = Color.LightPink;
                                break;
                            case 51:
                                testResult.Text = "红外2故障";
                                testResult.BackColor = Color.LightPink;
                                break;
                            default:
                                break;
                        }
                        byte[] IBytes = new byte[4];
                        Array.Copy(array, 10, IBytes, 0, 4);
                        IShow.Text = Encoding.Default.GetString(IBytes);
                        if(float.Parse(IShow.Text) > IMax)
                            IShow.BackColor = Color.LightPink;
                        else
                            IShow.BackColor = Color.LightGreen;

                        byte[] VBytes = new byte[3];
                        Array.Copy(array, 6, VBytes, 0, 3);
                        VShow.Text = Encoding.Default.GetString(VBytes).Insert(1, ".");
                        if (float.Parse(VShow.Text) > VMax)
                            VShow.BackColor = Color.LightPink;
                        else if(float.Parse(VShow.Text) < VMin)
                            VShow.BackColor = Color.DeepSkyBlue;
                        else
                            VShow.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        if (reTestTip > 0)
                        {
                            if (reTestType == 1)//有遮挡
                            {
                                testWithCover();
                                reTestTip--;
                            }
                            else if (reTestType == 2)
                            {
                                testWithoutCover();
                                reTestTip--;
                            }
                        }
                        else
                            reTestType = 0;
                    }
                    
                    return true;
                case 0x0f:
                    tempString = "Write Error: ";
                    break;
                case 0x10:
                    tempString = "Write Sent Val Number: ";
                    break;
                case 0x11:
                    tempString = "FC Violated: ";
                    break;
                case 0x12:
                    tempString = "MTU Size: ";
                    break;
                case 0x13:
                    tempString = "RSSI (-dB): ";
                    periStruct newPeri = periList[array[0]];
                    newPeri.periRSSI = 0;
                    for (int i = 1; i < 5; i++)
                        newPeri.periRSSI |= (array[i] << (8 * (4 - i)));
                    periList[array[0]] = newPeri;
                    listView1.Items[array[0]].SubItems[4].Text = newPeri.periRSSI.ToString();
                    //textBox2.Text = tText;
                    break;
                case 0x14:
                    tempString = "Pairing Started";
                    break;
                case 0x15:
                    tempString = "Pairing Success";
                    break;
                case 0x16:
                    tempString = "Pairing Fail: ";
                    break;
                case 0x17:
                    tempString = "Bonding Success";
                    break;
                case 0x18:
                    tempString = "Bonding Save Success";
                    break;
                case 0x19:
                    tempString = "Bonding Save Failed: ";
                    break;
                case 0x1a:
                    tempString = "Passcode: ";
                    break;
                case 0x1b:
                    tempString = "MTU Size: ";
                    break;
                case 0x1c:
                    tempString = "Simple Svc Found: ";
                    break;
                case 0x1d:
                    tempString = "已连接";
                    periResult_textBox2.AppendText(tempString + "\r\n\r\n");
                    break;
                case 0x1e:
                    tempString = "已断开";
                    periResult_textBox2.AppendText(tempString + "\r\n\r\n");
                    break;
                case 0x1f:
                    tempString = "连接状态：";
                    switch(array[0])
                    {
                        case 0x00:
                            tempString += "SUCCESS";
                            break;
                        case 0x01:
                            tempString += "FAILURE";
                            break;
                        case 0x02:
                            tempString += "INVALIDPARAMETER";
                            break;
                        case 0x03:
                            tempString += "INVALID_TASK";
                            break;
                        case 0x04:
                            tempString += "MSG_BUFFER_NOT_AVAIL";
                            break;
                        case 0x05:
                            tempString += "INVALID_MSG_POINTER";
                            break;
                        case 0x06:
                            tempString += "INVALID_EVENT_ID";
                            break;
                        case 0x07:
                            tempString += "INVALID_INTERRUPT_ID";
                            break;
                        case 0x08:
                            tempString += "NO_TIMER_AVAIL";
                            break;
                        case 0x09:
                            tempString += "NV_ITEM_UNINIT";
                            break;
                        case 0x0a:
                            tempString += "NV_OPER_FAILED";
                            break;
                        case 0x0b:
                            tempString += "INVALID_MEM_SIZE";
                            break;
                        case 0x0c:
                            tempString += "NV_BAD_ITEM_LEN";
                            break;
                        default:
                            return false;
                    }
                    reciveShow.AppendText(string.Format("{0:G}", DateTime.Now) + "\r\n" + tempString + "\r\n\r\n");
                    periResult_textBox2.AppendText(string.Format("{0:G}", DateTime.Now) + "\r\n" + tempString + "\r\n\r\n");
                    return true;
                case 0x20:
                    tempString = "连接成功: " + BitConverter.ToString(array);
                    periResult_textBox2.AppendText(tempString + "\r\n\r\n");
                    return true;
                case 0x21:
                    tempString = "正在断开";
                    periResult_textBox2.AppendText(tempString + "\r\n\r\n");
                    return true;
                case 0x22:
                    tempString = "找到待连接设备:";
                    periResult_textBox2.AppendText(tempString + "\r\n\r\n");
                    break;
                case 0x23:
                    tempString = "未找到待连接设备:";
                    periResult_textBox2.AppendText(tempString + "\r\n\r\n");
                    searchPeri();
                    break;
                case 0xaa:
                    tempString = "连接串口";
                    break;
                case 0xfe:
                    tempString = "名称";
                    string tString = Encoding.Default.GetString(array);//BitConverter.ToString(array, 0);
                    reciveShow.AppendText("\r\n" + string.Format("{0:G}", DateTime.Now) + "\r\n" + tempString + tString + "\r\n\r\n");

                    if (array.Length < addLen * 2)
                        break;

                    for (int j = 0; j < periList.Count; j++)
                    {
                        byte[] tAdd = new byte[addLen * 2];
                        for (int k = 0; k < addLen; k++)//把实际地址先反转再转化成对应的ASCII表示，待比较
                        {
                            byte[] tAddress = Encoding.Default.GetBytes(periList[j].periAddr[addLen - k - 1].ToString("X2"));
                            tAdd[k * 2] = tAddress[0];
                            tAdd[k * 2 + 1] = tAddress[tAddress.Length - 1];
                        }

                        for (int i = 0; i < array.Length - addLen * 2; i++)//查找名称中是否含有地址，对应名称
                        {
                            byte[] tArr = new byte[addLen * 2];
                            Array.Copy(array, i, tArr, 0, addLen * 2);

                            if (tArr[0] == tAdd[0] && Enumerable.SequenceEqual(tArr, tAdd))
                            {
                                periStruct tPeri = periList[j];
                                tPeri.periData = tString.Substring(0, i + 2 * addLen);
                                periList[j] = tPeri;

                                i = array.Length - addLen;
                                break;
                            }
                        }
                    }

                    break;

                case 0xff:
                    tempString = "Great Number = ";
                    string ttempString = Encoding.Default.GetString(array);//BitConverter.ToString(array, 0);
                    reciveShow.AppendText("\r\n" + string.Format("{0:G}", DateTime.Now) + "\r\n" + tempString + ttempString + "\r\n\r\n");

                    if (array.Length < 10)
                        return false;

                    bool taddItem = true;
                    UInt16 tDataLen = (UInt16)(array.Length - 10);
                    int scanIndex = array[0];
                    Int64 rssi = array[1];
                    UInt16 uuid = (UInt16)((array[2] << 8) | array[3]);
                    byte[] addArray = new byte[addLen];
                    Array.Copy(array, 4, addArray, 0, addLen);
                    byte[] ttempArray = new byte[tDataLen];
                    Array.Copy(array, 10, ttempArray, 0, tDataLen);

                    foreach (periStruct peri in periList)
                        if (Enumerable.SequenceEqual(peri.periAddr, addArray))
                        {
                            taddItem = false;
                            break;
                        }
                    if (taddItem == true)
                    {
                        periStruct peri = new periStruct();
                        peri.UUID = uuid;
                        peri.index = scanIndex;
                        peri.periAddr = addArray;
                        peri.dataLen = tDataLen;
                        peri.periData = "";
                        peri.periRSSI = rssi;
                        peri.connectTip = false;
                        periList.Add(peri);
                        //freshListView();
                    }

                    return true;
                default:
                    reciveShow.AppendText(string.Format("{0:G}", DateTime.Now) + "\r\n参数错误\r\n\r\n");
                    return false;
            }

            if(array == null)//如果无数据
                reciveShow.AppendText(string.Format("{0:G}", DateTime.Now) + "\r\n" + tempString + "\r\n\r\n");

            else//否则，显示数据
            {
                string ttempString = BitConverter.ToString(array, 0);
                reciveShow.AppendText(string.Format("{0:G}", DateTime.Now) + "\r\n" + tempString + ttempString + "\r\n\r\n");
            }

            return true;
        }

        private void freshListView()
        {
            listView1.Items.Clear();
            listView1.BeginUpdate();
            for (int i = 0; i < periList.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());//periList[i].index
                //item.SubItems.Add((periList[i].index + 1).ToString());//Convert.ToString(i + 1));
                item.SubItems.Add(periList[i].periData);
                byte[] addArray = new byte[6];
                Array.Copy(periList[i].periAddr, addArray, 6);
                Array.Reverse(addArray, 0, 6);//反转显示
                item.SubItems.Add(BitConverter.ToString(addArray, 0));//(periList[i].ToString());
                item.SubItems.Add(BitConverter.ToString(BitConverter.GetBytes(periList[i].UUID)));
                item.SubItems.Add(periList[i].periRSSI.ToString());
                item.SubItems.Add(periList[i].connectTip.ToString());
                if (periList[i].connectTip == true)
                {
                    item.ForeColor = Color.Blue;
                    item.BackColor = Color.AliceBlue;
                }
                listView1.Items.Add(item);
            }
            listView1.EndUpdate();
            connectPeri.Enabled = true;
            recive_textBox3.BackColor = Color.Chartreuse;
            recive_textBox3.ForeColor = Color.Black;
        }

        private byte freshSerialPort()
        {
            serialPort.Close();
            serialPort.PortName = comboBox1.SelectedItem.ToString();
            serialPort.BaudRate = int.Parse(comboBox2.SelectedItem.ToString());
            serialPort.DataBits = int.Parse(comboBox3.SelectedItem.ToString());
            switch(int.Parse(comboBox4.SelectedItem.ToString()))
            {
                case 1:
                    serialPort.StopBits = System.IO.Ports.StopBits.One;
                    break;
                case 2:
                    serialPort.StopBits = System.IO.Ports.StopBits.Two;
                    break;
                default:
                    return 0x01;
            }
            switch(comboBox5.SelectedItem.ToString())
            {
                case "NONE":
                    serialPort.Parity = System.IO.Ports.Parity.None;
                    break;
                case "EVEN":
                    serialPort.Parity = System.IO.Ports.Parity.Even;
                    break;
                case "ODD":
                    serialPort.Parity = System.IO.Ports.Parity.Odd;
                    break;
                case "ZERO":
                    serialPort.Parity = System.IO.Ports.Parity.Space;
                    break;
                case "ONE":
                    serialPort.Parity = System.IO.Ports.Parity.Mark;
                    break;
                default:
                    return 0x02;
            }
            serialPort.Handshake = System.IO.Ports.Handshake.None;
            string portName = comboBox1.SelectedItem.ToString();
            try
            {
                serialPort.Open();//打开串口
            }
            catch (Exception ex)
            {
                portArr = null;
                comboBox1.Items.Clear();
                portArr = System.IO.Ports.SerialPort.GetPortNames().Distinct().ToArray();
                comboBox1.Items.AddRange(portArr);
                comboBox1.SelectedIndex = 0;//刷新
                string errString = ex.Message;
                try
                {
                    operationResult_textBox2.AppendText("串口" + portName + " error:\r\n" + errString + "\r\n\r\n");
                }
                catch
                { }
            }
            return 0x00;//成功
        }
    }
}
