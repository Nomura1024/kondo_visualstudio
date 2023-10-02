namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.idNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.posNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.freeButton = new System.Windows.Forms.Button();
            this.normalButton = new System.Windows.Forms.Button();
            this.setPosButton = new System.Windows.Forms.Button();
            this.getPosButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.idNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 1500000;
            this.serialPort1.PortName = "COM3";
            this.serialPort1.ReadTimeout = 500;
            // 
            // idNumericUpDown
            // 
            this.idNumericUpDown.Location = new System.Drawing.Point(12, 37);
            this.idNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.idNumericUpDown.Name = "idNumericUpDown";
            this.idNumericUpDown.Size = new System.Drawing.Size(75, 19);
            this.idNumericUpDown.TabIndex = 0;
            this.idNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // posNumericUpDown
            // 
            this.posNumericUpDown.Location = new System.Drawing.Point(174, 37);
            this.posNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.posNumericUpDown.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.posNumericUpDown.Name = "posNumericUpDown";
            this.posNumericUpDown.Size = new System.Drawing.Size(77, 19);
            this.posNumericUpDown.TabIndex = 1;
            this.posNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Position";
            // 
            // freeButton
            // 
            this.freeButton.Location = new System.Drawing.Point(12, 62);
            this.freeButton.Name = "freeButton";
            this.freeButton.Size = new System.Drawing.Size(75, 45);
            this.freeButton.TabIndex = 4;
            this.freeButton.Text = "Free";
            this.freeButton.UseVisualStyleBackColor = true;
            this.freeButton.Click += new System.EventHandler(this.freeButton_Click);
            // 
            // normalButton
            // 
            this.normalButton.Location = new System.Drawing.Point(93, 62);
            this.normalButton.Name = "normalButton";
            this.normalButton.Size = new System.Drawing.Size(75, 45);
            this.normalButton.TabIndex = 5;
            this.normalButton.Text = "Normal";
            this.normalButton.UseVisualStyleBackColor = true;
            this.normalButton.Click += new System.EventHandler(this.normalButton_Click);
            // 
            // setPosButton
            // 
            this.setPosButton.Location = new System.Drawing.Point(174, 62);
            this.setPosButton.Name = "setPosButton";
            this.setPosButton.Size = new System.Drawing.Size(75, 45);
            this.setPosButton.TabIndex = 6;
            this.setPosButton.Text = "SetPos";
            this.setPosButton.UseVisualStyleBackColor = true;
            this.setPosButton.Click += new System.EventHandler(this.setPosButton_Click);
            // 
            // getPosButton
            // 
            this.getPosButton.Location = new System.Drawing.Point(255, 62);
            this.getPosButton.Name = "getPosButton";
            this.getPosButton.Size = new System.Drawing.Size(75, 45);
            this.getPosButton.TabIndex = 7;
            this.getPosButton.Text = "getPos";
            this.getPosButton.UseVisualStyleBackColor = true;
            this.getPosButton.Click += new System.EventHandler(this.getPosButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(366, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 19);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // serialPort2
            // 
            this.serialPort2.BaudRate = 115200;
            this.serialPort2.PortName = "COM4";
            this.serialPort2.ReadTimeout = 1;
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort2_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 121);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.getPosButton);
            this.Controls.Add(this.setPosButton);
            this.Controls.Add(this.normalButton);
            this.Controls.Add(this.freeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.posNumericUpDown);
            this.Controls.Add(this.idNumericUpDown);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.InputLanguageChanging += new System.Windows.Forms.InputLanguageChangingEventHandler(this.Form1_InputLanguageChanging);
            ((System.ComponentModel.ISupportInitialize)(this.idNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.NumericUpDown idNumericUpDown;
        private System.Windows.Forms.NumericUpDown posNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button freeButton;
        private System.Windows.Forms.Button normalButton;
        private System.Windows.Forms.Button setPosButton;
        private System.Windows.Forms.Button getPosButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.IO.Ports.SerialPort serialPort2;
    }
}

