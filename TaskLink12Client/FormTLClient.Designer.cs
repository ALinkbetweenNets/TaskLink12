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
            this.components = new System.ComponentModel.Container();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonSPSet = new System.Windows.Forms.Button();
            this.buttonSPSave = new System.Windows.Forms.Button();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.buttonIPRefresh = new System.Windows.Forms.Button();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.checkBoxSPSet = new System.Windows.Forms.CheckBox();
            this.checkBoxIPSet = new System.Windows.Forms.CheckBox();
            this.checkBoxReceiver = new System.Windows.Forms.CheckBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.listBoxIPLocal = new System.Windows.Forms.ListBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonStatusRefresh = new System.Windows.Forms.Button();
            this.buttonSilent = new System.Windows.Forms.Button();
            this.checkBoxSilent = new System.Windows.Forms.CheckBox();
            this.buttonLogClear = new System.Windows.Forms.Button();
            this.notifyIconSilent = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonSPRemove = new System.Windows.Forms.Button();
            this.checkBoxSPSave = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBoxLog.Location = new System.Drawing.Point(962, 19);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(436, 599);
            this.textBoxLog.TabIndex = 0;
            // 
            // buttonSPSet
            // 
            this.buttonSPSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonSPSet.Location = new System.Drawing.Point(71, 19);
            this.buttonSPSet.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSPSet.Name = "buttonSPSet";
            this.buttonSPSet.Size = new System.Drawing.Size(494, 70);
            this.buttonSPSet.TabIndex = 1;
            this.buttonSPSet.Text = "Set Session Password";
            this.buttonSPSet.UseVisualStyleBackColor = true;
            this.buttonSPSet.Click += new System.EventHandler(this.buttonSPSet_Click);
            // 
            // buttonSPSave
            // 
            this.buttonSPSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonSPSave.Location = new System.Drawing.Point(71, 98);
            this.buttonSPSave.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSPSave.Name = "buttonSPSave";
            this.buttonSPSave.Size = new System.Drawing.Size(494, 70);
            this.buttonSPSave.TabIndex = 2;
            this.buttonSPSave.Text = "Save Session Password";
            this.buttonSPSave.UseVisualStyleBackColor = true;
            this.buttonSPSave.Click += new System.EventHandler(this.buttonSPSave_Click);
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonStartStop.Location = new System.Drawing.Point(73, 294);
            this.buttonStartStop.Margin = new System.Windows.Forms.Padding(5);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(494, 70);
            this.buttonStartStop.TabIndex = 3;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // buttonIPRefresh
            // 
            this.buttonIPRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonIPRefresh.Location = new System.Drawing.Point(716, 313);
            this.buttonIPRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.buttonIPRefresh.Name = "buttonIPRefresh";
            this.buttonIPRefresh.Size = new System.Drawing.Size(235, 50);
            this.buttonIPRefresh.TabIndex = 4;
            this.buttonIPRefresh.Text = "Refresh IPs";
            this.buttonIPRefresh.UseVisualStyleBackColor = true;
            this.buttonIPRefresh.Click += new System.EventHandler(this.buttonIPRefresh_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxIP.Location = new System.Drawing.Point(215, 236);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.ReadOnly = true;
            this.textBoxIP.Size = new System.Drawing.Size(349, 49);
            this.textBoxIP.TabIndex = 5;
            // 
            // checkBoxSPSet
            // 
            this.checkBoxSPSet.AutoCheck = false;
            this.checkBoxSPSet.AutoSize = true;
            this.checkBoxSPSet.Enabled = false;
            this.checkBoxSPSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBoxSPSet.Location = new System.Drawing.Point(21, 39);
            this.checkBoxSPSet.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxSPSet.Name = "checkBoxSPSet";
            this.checkBoxSPSet.Size = new System.Drawing.Size(34, 33);
            this.checkBoxSPSet.TabIndex = 6;
            this.checkBoxSPSet.UseVisualStyleBackColor = true;
            // 
            // checkBoxIPSet
            // 
            this.checkBoxIPSet.AutoCheck = false;
            this.checkBoxIPSet.AutoSize = true;
            this.checkBoxIPSet.Enabled = false;
            this.checkBoxIPSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBoxIPSet.Location = new System.Drawing.Point(23, 246);
            this.checkBoxIPSet.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxIPSet.Name = "checkBoxIPSet";
            this.checkBoxIPSet.Size = new System.Drawing.Size(34, 33);
            this.checkBoxIPSet.TabIndex = 7;
            this.checkBoxIPSet.UseVisualStyleBackColor = true;
            // 
            // checkBoxReceiver
            // 
            this.checkBoxReceiver.AutoCheck = false;
            this.checkBoxReceiver.AutoSize = true;
            this.checkBoxReceiver.Enabled = false;
            this.checkBoxReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBoxReceiver.Location = new System.Drawing.Point(23, 318);
            this.checkBoxReceiver.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxReceiver.Name = "checkBoxReceiver";
            this.checkBoxReceiver.Size = new System.Drawing.Size(34, 33);
            this.checkBoxReceiver.TabIndex = 8;
            this.checkBoxReceiver.UseVisualStyleBackColor = true;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(73, 248);
            this.labelIP.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(132, 32);
            this.labelIP.TabIndex = 10;
            this.labelIP.Text = "Local IP: ";
            // 
            // listBoxIPLocal
            // 
            this.listBoxIPLocal.FormattingEnabled = true;
            this.listBoxIPLocal.ItemHeight = 31;
            this.listBoxIPLocal.Location = new System.Drawing.Point(578, 19);
            this.listBoxIPLocal.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxIPLocal.Name = "listBoxIPLocal";
            this.listBoxIPLocal.Size = new System.Drawing.Size(370, 283);
            this.listBoxIPLocal.TabIndex = 11;
            this.listBoxIPLocal.Click += new System.EventHandler(this.listBoxIP_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(73, 409);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(124, 42);
            this.labelStatus.TabIndex = 12;
            this.labelStatus.Text = "Status";
            // 
            // buttonStatusRefresh
            // 
            this.buttonStatusRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonStatusRefresh.Location = new System.Drawing.Point(82, 454);
            this.buttonStatusRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.buttonStatusRefresh.Name = "buttonStatusRefresh";
            this.buttonStatusRefresh.Size = new System.Drawing.Size(235, 50);
            this.buttonStatusRefresh.TabIndex = 13;
            this.buttonStatusRefresh.Text = "Refresh Status";
            this.buttonStatusRefresh.UseVisualStyleBackColor = true;
            this.buttonStatusRefresh.Click += new System.EventHandler(this.buttonStatusRefresh_Click);
            // 
            // buttonSilent
            // 
            this.buttonSilent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonSilent.Location = new System.Drawing.Point(73, 513);
            this.buttonSilent.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSilent.Name = "buttonSilent";
            this.buttonSilent.Size = new System.Drawing.Size(494, 70);
            this.buttonSilent.TabIndex = 14;
            this.buttonSilent.Text = "Enable Silent Mode";
            this.buttonSilent.UseVisualStyleBackColor = true;
            this.buttonSilent.Click += new System.EventHandler(this.buttonSilent_Click);
            // 
            // checkBoxSilent
            // 
            this.checkBoxSilent.AutoCheck = false;
            this.checkBoxSilent.AutoSize = true;
            this.checkBoxSilent.Enabled = false;
            this.checkBoxSilent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBoxSilent.Location = new System.Drawing.Point(23, 533);
            this.checkBoxSilent.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxSilent.Name = "checkBoxSilent";
            this.checkBoxSilent.Size = new System.Drawing.Size(34, 33);
            this.checkBoxSilent.TabIndex = 15;
            this.checkBoxSilent.UseVisualStyleBackColor = true;
            // 
            // buttonLogClear
            // 
            this.buttonLogClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonLogClear.Location = new System.Drawing.Point(1166, 629);
            this.buttonLogClear.Margin = new System.Windows.Forms.Padding(5);
            this.buttonLogClear.Name = "buttonLogClear";
            this.buttonLogClear.Size = new System.Drawing.Size(235, 50);
            this.buttonLogClear.TabIndex = 16;
            this.buttonLogClear.Text = "Clear Log";
            this.buttonLogClear.UseVisualStyleBackColor = true;
            // 
            // notifyIconSilent
            // 
            this.notifyIconSilent.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconSilent.BalloonTipText = "Task Link 12 Client";
            this.notifyIconSilent.BalloonTipTitle = "Task Link 12 Client";
            this.notifyIconSilent.Text = "Task Link 12 Client";
            this.notifyIconSilent.Visible = true;
            this.notifyIconSilent.Click += new System.EventHandler(this.notifyIconSilent_Click);
            // 
            // buttonSPRemove
            // 
            this.buttonSPRemove.Enabled = false;
            this.buttonSPRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonSPRemove.Location = new System.Drawing.Point(331, 177);
            this.buttonSPRemove.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSPRemove.Name = "buttonSPRemove";
            this.buttonSPRemove.Size = new System.Drawing.Size(235, 50);
            this.buttonSPRemove.TabIndex = 17;
            this.buttonSPRemove.Text = "Delete File";
            this.buttonSPRemove.UseVisualStyleBackColor = true;
            this.buttonSPRemove.Click += new System.EventHandler(this.buttonSPRemove_Click);
            // 
            // checkBoxSPSave
            // 
            this.checkBoxSPSave.AutoCheck = false;
            this.checkBoxSPSave.AutoSize = true;
            this.checkBoxSPSave.Enabled = false;
            this.checkBoxSPSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBoxSPSave.Location = new System.Drawing.Point(21, 118);
            this.checkBoxSPSave.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxSPSave.Name = "checkBoxSPSave";
            this.checkBoxSPSave.Size = new System.Drawing.Size(34, 33);
            this.checkBoxSPSave.TabIndex = 18;
            this.checkBoxSPSave.UseVisualStyleBackColor = true;
            // 
            // FormTLClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 697);
            this.Controls.Add(this.checkBoxSPSave);
            this.Controls.Add(this.buttonSPRemove);
            this.Controls.Add(this.buttonLogClear);
            this.Controls.Add(this.checkBoxSilent);
            this.Controls.Add(this.buttonSilent);
            this.Controls.Add(this.buttonStatusRefresh);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.listBoxIPLocal);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.checkBoxReceiver);
            this.Controls.Add(this.checkBoxIPSet);
            this.Controls.Add(this.checkBoxSPSet);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.buttonIPRefresh);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.buttonSPSave);
            this.Controls.Add(this.buttonSPSet);
            this.Controls.Add(this.textBoxLog);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormTLClient";
            this.Text = "Task Link 12 Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSPSet;
        private System.Windows.Forms.Button buttonSPSave;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Button buttonIPRefresh;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.CheckBox checkBoxSPSet;
        private System.Windows.Forms.CheckBox checkBoxIPSet;
        private System.Windows.Forms.CheckBox checkBoxReceiver;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.ListBox listBoxIPLocal;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonStatusRefresh;
        private System.Windows.Forms.Button buttonSilent;
        private System.Windows.Forms.CheckBox checkBoxSilent;
        private System.Windows.Forms.Button buttonLogClear;
        public System.Windows.Forms.NotifyIcon notifyIconSilent;
        private System.Windows.Forms.Button buttonSPRemove;
        private System.Windows.Forms.CheckBox checkBoxSPSave;
        public System.Windows.Forms.TextBox textBoxLog;
    }
}

