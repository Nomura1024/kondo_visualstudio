using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using Extensions.Collections;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string str;
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// フォームが立ち上がった時に呼ばれるイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();             //COMポートを開く
                serialPort2.Open();
            }
            catch
            {
                MessageBox.Show("COMが開けません！！");
                /// COMが開けない場合は、SerialPortのCOM番号をチェックします
                /// もしくは他のソフトウェアでSerialPortが占有されていないか確認します
                serialPort1.Close();
                this.Close();
            }
        }

        /// <summary>
        /// フォームが閉じらられそうになった時に呼ばれるイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
            serialPort2.Close();
        }

        #region B3Mの動作関数

        /// <summary>
        /// トルクオン、位置制御モード等々一度に設定する
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="servoID"></param>
        /// <returns></returns>
        private bool b3mModeSet(SerialPort serialPort, byte servoID, byte mode)
        {
            ByteList cmd = new ByteList();  //コマンド格納用
            byte[] rx = new byte[5];        //コマンド受信用(Writeコマンドは5byte)

            //コマンドの作成
            //cmd.Bytes = B3MLib.B3MLib.Write(0, B3MLib.B3MLib.SERVO_TORQUE_ON, 1, servoID, new byte[] { mode });
            cmd.Bytes = B3MLib.B3MLib.WriteSingle(0x01, 0x29, servoID, new byte[] { 1 });
            B3MLib.B3MLib.Synchronize(serialPort, cmd.Bytes, ref rx);
            cmd.Bytes = B3MLib.B3MLib.WriteSingle(0, B3MLib.B3MLib.SERVO_TORQUE_ON, servoID, new byte[] { mode });
            //cmd.Bytes = B3MLib.B3MLib.WriteSingle(0, B3MLib.B3MLib.SERVO_TORQUE_ON, servoID, new byte[] { mode });
            
            //option:0
            //address:B3MLib.B3MLib.SERVO_TORQUE_ON (0x28)
            //count:1(データを送るB3Mの数)
            //ID:servoID
            //data:送信するデータ配列

            // コマンドを送信
            return B3MLib.B3MLib.Synchronize(serialPort, cmd.Bytes,ref rx);
        }


        /// <summary>
        /// Nomal、位置制御モードにする
        /// </summary>
        /// <param name="serialPort1">serialport</param>
        /// <param name="servoID">id</param>
        /// <returns></returns>
        private bool b3mNomalPosModeSet(SerialPort serialPort, byte servoID)
        {
            return b3mModeSet(serialPort, servoID, ((byte)B3MLib.B3MLib.Options.ControlPosition | (byte)B3MLib.B3MLib.Options.RunNormal));
        }

        /// <summary>
        /// Free、位置制御モードにする
        /// </summary>
        /// <param name="serialPort1">serialport</param>
        /// <param name="servoID">id</param>
        /// <returns></returns>
        private bool b3mFreePosModeSet(SerialPort serialPort, byte servoID)
        {
            return b3mModeSet(serialPort, servoID, ((byte)B3MLib.B3MLib.Options.ControlPosition | (byte)B3MLib.B3MLib.Options.RunFree));
        }

        /// <summary>
        /// 角度指定をする関数
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="servoID"></param>
        /// <param name="angle"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private bool b3mSetPosition(SerialPort serialPort, byte servoID, int angle, ushort time)
        {
          //  int seu = 5000;
            ByteList cmd = new ByteList();  //コマンド格納用
            byte[] rx = new byte[7];        //コマンド受信用(Writeコマンドは7byte)

            cmd.Bytes = B3MLib.B3MLib.SetPosision(0, servoID, angle, 1000);
            B3MLib.B3MLib.Synchronize(serialPort, cmd.Bytes, ref rx);
            //コマンドの作成
           // while (seu >= -5000)
            //{
             //   seu=seu-10;
               // Thread.Sleep(1);
               // str = serialPort2.ReadLine();
                
                //B3MLib.B3MLib.Synchronize(serialPort, cmd.Bytes, ref rx);
                //this.Invoke(new EventHandler(textBox1_TextChanged));
                //serialPort.ReadTimeout = 1000;
                

            //}
           
            //option:0
            //ID:servoID
            //pos:送信するデータ配列
            //time:軌道生成時の時間

            // コマンドを送信
            return B3MLib.B3MLib.Synchronize(serialPort, cmd.Bytes, ref rx);
        }


        /// <summary>
        /// サーボの現在角度を読み込む
        /// </summary>
        /// <param name="servoID"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        static public bool b3mAngleRead(SerialPort serialPort, byte servoID, ref int angle)
        {
            ByteList cmd = new ByteList();
            byte[] rx = new byte[7];        //コマンド受信用(Readで2byte受け取るコマンドは7byte)

            //コマンドの作成
            cmd.Bytes = B3MLib.B3MLib.Read(0x00, B3MLib.B3MLib.SERVO_CURRENT_POSITION, 2, servoID);
            //option:0
            //address:B3MLib.B3MLib.SERVO_CURRENT_POSITION (0x2C)
            //count:2(受け取るデータの数)
            //ID:servoID


            // コマンドを送信
            if (B3MLib.B3MLib.Synchronize(serialPort, cmd.Bytes, ref rx) == false)
            {
                return false;
            }

            //取得したデータをint(short)型に変換
            angle = (short)Extensions.Converter.ByteConverter.ByteArrayToInt16(rx[4], rx[5]);

            return true;
        }


        #endregion

        #region ボタンの操作

        /// <summary>
        /// フリーボタンがクリックされたとき呼ばれる関数イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void freeButton_Click(object sender, EventArgs e)
        {
            bool flag;

            flag = b3mFreePosModeSet(serialPort1,(byte)idNumericUpDown.Value);

            if (flag == false)
            {
                MessageBox.Show("データの送信に失敗しました");
            }

        }
        /// <summary>
        /// ノーマルボタンがクリックされたときに呼ばれるイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void normalButton_Click(object sender, EventArgs e)
        {
            bool flag;

            flag = b3mNomalPosModeSet(serialPort1, (byte)idNumericUpDown.Value);

            if (flag == false)
            {
                MessageBox.Show("データの送信に失敗しました");
            }
        }

        /// <summary>
        /// setPosボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setPosButton_Click(object sender, EventArgs e)
        {
            bool flag;

            flag = b3mSetPosition(serialPort1, (byte)idNumericUpDown.Value,(int)posNumericUpDown.Value,0);

            if (flag == false)
            {
                MessageBox.Show("データの送信に失敗しました");
            }
        }

        /// <summary>
        /// getPosボタンが押されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getPosButton_Click(object sender, EventArgs e)
        {
            bool flag;

            int angle = new int();

            flag = b3mAngleRead(serialPort1, (byte)idNumericUpDown.Value, ref angle);

            
            if (flag == false)
            {
                MessageBox.Show("データの送信に失敗しました");
                return;
            }

            posNumericUpDown.Value = angle;
        }

        #endregion

        private void Form1_InputLanguageChanging(object sender, InputLanguageChangingEventArgs e)
        {

        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            double i = 0;
            str = serialPort2.ReadLine();
            if(double.TryParse(str,out i))
            {
                i = Convert.ToDouble(str);
            }
            serialPort2.ReadTimeout = 1000;
            if (i >= 1.2) b3mFreePosModeSet(serialPort1, (byte)idNumericUpDown.Value);
            //await Task.Delay(10);
            this.Invoke(new EventHandler(textBox1_TextChanged));

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = str;
            //serialPort2.ReadTimeout = 1;
            //Thread.Sleep(1);


        }
    }
}
