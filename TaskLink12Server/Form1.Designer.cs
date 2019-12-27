namespace TaskLink12Server
{
    partial class FormTLServer
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLocalIP = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxIPLocal = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelLocalIP
            // 
            this.labelLocalIP.AutoSize = true;
            this.labelLocalIP.Location = new System.Drawing.Point(729, 304);
            this.labelLocalIP.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelLocalIP.Name = "labelLocalIP";
            this.labelLocalIP.Size = new System.Drawing.Size(125, 32);
            this.labelLocalIP.TabIndex = 0;
            this.labelLocalIP.Text = "Local IP:";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(617, 415);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(345, 139);
            this.textBoxLog.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.button1.Location = new System.Drawing.Point(272, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(494, 70);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBoxIPLocal
            // 
            this.listBoxIPLocal.FormattingEnabled = true;
            this.listBoxIPLocal.ItemHeight = 31;
            this.listBoxIPLocal.Location = new System.Drawing.Point(227, 294);
            this.listBoxIPLocal.Name = "listBoxIPLocal";
            this.listBoxIPLocal.Size = new System.Drawing.Size(158, 159);
            this.listBoxIPLocal.TabIndex = 3;
            // 
            // FormTLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 697);
            this.Controls.Add(this.listBoxIPLocal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.labelLocalIP);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "FormTLServer";
            this.Text = "Task Link 12 Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLocalIP;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxIPLocal;
    }
}

