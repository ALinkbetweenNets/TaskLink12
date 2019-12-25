namespace TaskLink12Client
{
    partial class FormTLClient
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
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonSPSet = new System.Windows.Forms.Button();
            this.buttonSPSave = new System.Windows.Forms.Button();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.buttonIPRefresh = new System.Windows.Forms.Button();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.listBoxIP = new System.Windows.Forms.ListBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonStatusRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxLog.Location = new System.Drawing.Point(541, 12);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(247, 426);
            this.textBoxLog.TabIndex = 0;
            // 
            // buttonSPSet
            // 
            this.buttonSPSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonSPSet.Location = new System.Drawing.Point(40, 12);
            this.buttonSPSet.Name = "buttonSPSet";
            this.buttonSPSet.Size = new System.Drawing.Size(278, 45);
            this.buttonSPSet.TabIndex = 1;
            this.buttonSPSet.Text = "Set Session Password";
            this.buttonSPSet.UseVisualStyleBackColor = true;
            this.buttonSPSet.Click += new System.EventHandler(this.buttonSPSet_Click);
            // 
            // buttonSPSave
            // 
            this.buttonSPSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonSPSave.Location = new System.Drawing.Point(40, 63);
            this.buttonSPSave.Name = "buttonSPSave";
            this.buttonSPSave.Size = new System.Drawing.Size(278, 45);
            this.buttonSPSave.TabIndex = 2;
            this.buttonSPSave.Text = "Save Session Password";
            this.buttonSPSave.UseVisualStyleBackColor = true;
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonStartStop.Location = new System.Drawing.Point(40, 152);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(278, 45);
            this.buttonStartStop.TabIndex = 3;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            // 
            // buttonIPRefresh
            // 
            this.buttonIPRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonIPRefresh.Location = new System.Drawing.Point(403, 162);
            this.buttonIPRefresh.Name = "buttonIPRefresh";
            this.buttonIPRefresh.Size = new System.Drawing.Size(132, 32);
            this.buttonIPRefresh.TabIndex = 4;
            this.buttonIPRefresh.Text = "Refresh IPs";
            this.buttonIPRefresh.UseVisualStyleBackColor = true;
            this.buttonIPRefresh.Click += new System.EventHandler(this.buttonIPRefresh_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxIP.Location = new System.Drawing.Point(120, 114);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.ReadOnly = true;
            this.textBoxIP.Size = new System.Drawing.Size(198, 32);
            this.textBoxIP.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoCheck = false;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBox1.Location = new System.Drawing.Point(12, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(22, 21);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoCheck = false;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBox2.Location = new System.Drawing.Point(12, 121);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(22, 21);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoCheck = false;
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBox3.Location = new System.Drawing.Point(12, 167);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(22, 21);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(40, 122);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(74, 20);
            this.labelIP.TabIndex = 10;
            this.labelIP.Text = "Local IP: ";
            // 
            // listBoxIP
            // 
            this.listBoxIP.FormattingEnabled = true;
            this.listBoxIP.ItemHeight = 20;
            this.listBoxIP.Location = new System.Drawing.Point(325, 12);
            this.listBoxIP.Name = "listBoxIP";
            this.listBoxIP.Size = new System.Drawing.Size(210, 144);
            this.listBoxIP.TabIndex = 11;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(40, 226);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(74, 26);
            this.labelStatus.TabIndex = 12;
            this.labelStatus.Text = "Status";
            // 
            // buttonStatusRefresh
            // 
            this.buttonStatusRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonStatusRefresh.Location = new System.Drawing.Point(45, 255);
            this.buttonStatusRefresh.Name = "buttonStatusRefresh";
            this.buttonStatusRefresh.Size = new System.Drawing.Size(132, 32);
            this.buttonStatusRefresh.TabIndex = 13;
            this.buttonStatusRefresh.Text = "Refresh Status";
            this.buttonStatusRefresh.UseVisualStyleBackColor = true;
            this.buttonStatusRefresh.Click += new System.EventHandler(this.buttonStatusRefresh_Click);
            // 
            // FormTLClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStatusRefresh);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.listBoxIP);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.buttonIPRefresh);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.buttonSPSave);
            this.Controls.Add(this.buttonSPSet);
            this.Controls.Add(this.textBoxLog);
            this.Name = "FormTLClient";
            this.Text = "Task Link 12 Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonSPSet;
        private System.Windows.Forms.Button buttonSPSave;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Button buttonIPRefresh;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.ListBox listBoxIP;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonStatusRefresh;
    }
}

