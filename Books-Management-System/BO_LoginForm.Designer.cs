namespace Books_Management_System
{
    partial class loginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Num = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_ID = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.button_Login = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.rbtReader = new System.Windows.Forms.RadioButton();
            this.rbtAD = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBox_Num
            // 
            this.textBox_Num.Location = new System.Drawing.Point(111, 40);
            this.textBox_Num.Name = "textBox_Num";
            this.textBox_Num.Size = new System.Drawing.Size(144, 21);
            this.textBox_Num.TabIndex = 0;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(111, 94);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(144, 21);
            this.textBox_password.TabIndex = 2;
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(59, 43);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(29, 12);
            this.label_ID.TabIndex = 3;
            this.label_ID.Text = "账号";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(59, 97);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(29, 12);
            this.label_password.TabIndex = 4;
            this.label_password.Text = "密码";
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(84, 181);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(62, 23);
            this.button_Login.TabIndex = 5;
            this.button_Login.Text = "登录";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(221, 181);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(62, 23);
            this.button_Exit.TabIndex = 11;
            this.button_Exit.Text = "退出";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // rbtReader
            // 
            this.rbtReader.AutoSize = true;
            this.rbtReader.Location = new System.Drawing.Point(111, 146);
            this.rbtReader.Name = "rbtReader";
            this.rbtReader.Size = new System.Drawing.Size(47, 16);
            this.rbtReader.TabIndex = 12;
            this.rbtReader.TabStop = true;
            this.rbtReader.Text = "读者";
            this.rbtReader.UseVisualStyleBackColor = true;
            // 
            // rbtAD
            // 
            this.rbtAD.AutoSize = true;
            this.rbtAD.Location = new System.Drawing.Point(196, 146);
            this.rbtAD.Name = "rbtAD";
            this.rbtAD.Size = new System.Drawing.Size(59, 16);
            this.rbtAD.TabIndex = 13;
            this.rbtAD.TabStop = true;
            this.rbtAD.Text = "管理员";
            this.rbtAD.UseVisualStyleBackColor = true;
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 224);
            this.Controls.Add(this.rbtAD);
            this.Controls.Add(this.rbtReader);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_Num);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "loginForm";
            this.Text = "WELCOME!";
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Num;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.RadioButton rbtAD;
        private System.Windows.Forms.RadioButton rbtReader;
    }
}

