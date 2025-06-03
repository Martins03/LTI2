namespace LTI2
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblToken;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblToken = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIP.Location = new System.Drawing.Point(194, 41);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(230, 43);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPort.Location = new System.Drawing.Point(194, 102);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(230, 43);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "";
            // 
            // txtToken
            // 
            this.txtToken.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtToken.Location = new System.Drawing.Point(194, 166);
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(230, 40);
            this.txtToken.TabIndex = 5;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(71, 242);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(353, 70);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Iniciar Sessão";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblIP
            // 
            this.lblIP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIP.Location = new System.Drawing.Point(64, 41);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(128, 43);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "Endereço IP:";
            // 
            // lblPort
            // 
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPort.Location = new System.Drawing.Point(64, 102);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(100, 43);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Porta:";
            // 
            // lblToken
            // 
            this.lblToken.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblToken.Location = new System.Drawing.Point(64, 166);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(96, 47);
            this.lblToken.TabIndex = 4;
            this.lblToken.Text = "Token:";
            this.lblToken.Click += new System.EventHandler(this.lblToken_Click);
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(512, 354);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblToken);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Kubernetes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
