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
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonSPSet = new System.Windows.Forms.Button();
            this.listBoxIPLocal = new System.Windows.Forms.ListBox();
            this.listBoxClientIP = new System.Windows.Forms.ListBox();
            this.listBoxProc = new System.Windows.Forms.ListBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.buttonSPRemove = new System.Windows.Forms.Button();
            this.checkBoxSPSet = new System.Windows.Forms.CheckBox();
            this.checkBoxIPSet = new System.Windows.Forms.CheckBox();
            this.buttonSPSave = new System.Windows.Forms.Button();
            this.buttonIPLocalRefresh = new System.Windows.Forms.Button();
            this.buttonLogClear = new System.Windows.Forms.Button();
            this.labelIP = new System.Windows.Forms.Label();
            this.buttonClientAdd = new System.Windows.Forms.Button();
            this.buttonClientSave = new System.Windows.Forms.Button();
            this.buttonClientLoad = new System.Windows.Forms.Button();
            this.buttonClientRemove = new System.Windows.Forms.Button();
            this.buttonClientClear = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.checkBoxClientSet = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(813, 12);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(595, 1258);
            this.textBoxLog.TabIndex = 1;
            // 
            // buttonSPSet
            // 
            this.buttonSPSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonSPSet.Location = new System.Drawing.Point(56, 12);
            this.buttonSPSet.Name = "buttonSPSet";
            this.buttonSPSet.Size = new System.Drawing.Size(494, 70);
            this.buttonSPSet.TabIndex = 2;
            this.buttonSPSet.Text = "Set Session Password";
            this.buttonSPSet.UseVisualStyleBackColor = true;
            this.buttonSPSet.Click += new System.EventHandler(this.buttonSPSet_Click);
            // 
            // listBoxIPLocal
            // 
            this.listBoxIPLocal.FormattingEnabled = true;
            this.listBoxIPLocal.ItemHeight = 31;
            this.listBoxIPLocal.Location = new System.Drawing.Point(556, 12);
            this.listBoxIPLocal.Name = "listBoxIPLocal";
            this.listBoxIPLocal.Size = new System.Drawing.Size(247, 221);
            this.listBoxIPLocal.TabIndex = 3;
            // 
            // listBoxClientIP
            // 
            this.listBoxClientIP.FormattingEnabled = true;
            this.listBoxClientIP.ItemHeight = 31;
            this.listBoxClientIP.Location = new System.Drawing.Point(56, 419);
            this.listBoxClientIP.Name = "listBoxClientIP";
            this.listBoxClientIP.Size = new System.Drawing.Size(300, 593);
            this.listBoxClientIP.TabIndex = 4;
            // 
            // listBoxProc
            // 
            this.listBoxProc.FormattingEnabled = true;
            this.listBoxProc.ItemHeight = 31;
            this.listBoxProc.Location = new System.Drawing.Point(362, 419);
            this.listBoxProc.Name = "listBoxProc";
            this.listBoxProc.Size = new System.Drawing.Size(441, 593);
            this.listBoxProc.TabIndex = 5;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(556, 297);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.ReadOnly = true;
            this.textBoxIP.Size = new System.Drawing.Size(247, 38);
            this.textBoxIP.TabIndex = 6;
            // 
            // buttonSPRemove
            // 
            this.buttonSPRemove.Enabled = false;
            this.buttonSPRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonSPRemove.Location = new System.Drawing.Point(315, 164);
            this.buttonSPRemove.Name = "buttonSPRemove";
            this.buttonSPRemove.Size = new System.Drawing.Size(235, 50);
            this.buttonSPRemove.TabIndex = 7;
            this.buttonSPRemove.Text = "Delete File";
            this.buttonSPRemove.UseVisualStyleBackColor = true;
            // 
            // checkBoxSPSet
            // 
            this.checkBoxSPSet.AutoCheck = false;
            this.checkBoxSPSet.AutoSize = true;
            this.checkBoxSPSet.Enabled = false;
            this.checkBoxSPSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBoxSPSet.Location = new System.Drawing.Point(14, 32);
            this.checkBoxSPSet.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxSPSet.Name = "checkBoxSPSet";
            this.checkBoxSPSet.Size = new System.Drawing.Size(34, 33);
            this.checkBoxSPSet.TabIndex = 8;
            this.checkBoxSPSet.UseVisualStyleBackColor = true;
            // 
            // checkBoxIPSet
            // 
            this.checkBoxIPSet.AutoCheck = false;
            this.checkBoxIPSet.AutoSize = true;
            this.checkBoxIPSet.Enabled = false;
            this.checkBoxIPSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBoxIPSet.Location = new System.Drawing.Point(370, 297);
            this.checkBoxIPSet.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxIPSet.Name = "checkBoxIPSet";
            this.checkBoxIPSet.Size = new System.Drawing.Size(34, 33);
            this.checkBoxIPSet.TabIndex = 19;
            this.checkBoxIPSet.UseVisualStyleBackColor = true;
            // 
            // buttonSPSave
            // 
            this.buttonSPSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonSPSave.Location = new System.Drawing.Point(56, 88);
            this.buttonSPSave.Name = "buttonSPSave";
            this.buttonSPSave.Size = new System.Drawing.Size(494, 70);
            this.buttonSPSave.TabIndex = 22;
            this.buttonSPSave.Text = "Save Session Password";
            this.buttonSPSave.UseVisualStyleBackColor = true;
            this.buttonSPSave.Click += new System.EventHandler(this.buttonSPSave_Click);
            // 
            // buttonIPLocalRefresh
            // 
            this.buttonIPLocalRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonIPLocalRefresh.Location = new System.Drawing.Point(556, 239);
            this.buttonIPLocalRefresh.Name = "buttonIPLocalRefresh";
            this.buttonIPLocalRefresh.Size = new System.Drawing.Size(247, 50);
            this.buttonIPLocalRefresh.TabIndex = 23;
            this.buttonIPLocalRefresh.Text = "Refresh Local IPs";
            this.buttonIPLocalRefresh.UseVisualStyleBackColor = true;
            // 
            // buttonLogClear
            // 
            this.buttonLogClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonLogClear.Location = new System.Drawing.Point(1175, 1278);
            this.buttonLogClear.Name = "buttonLogClear";
            this.buttonLogClear.Size = new System.Drawing.Size(235, 50);
            this.buttonLogClear.TabIndex = 24;
            this.buttonLogClear.Text = "Clear Log";
            this.buttonLogClear.UseVisualStyleBackColor = true;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(414, 300);
            this.labelIP.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(132, 32);
            this.labelIP.TabIndex = 25;
            this.labelIP.Text = "Local IP: ";
            // 
            // buttonClientAdd
            // 
            this.buttonClientAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonClientAdd.Location = new System.Drawing.Point(56, 343);
            this.buttonClientAdd.Name = "buttonClientAdd";
            this.buttonClientAdd.Size = new System.Drawing.Size(300, 70);
            this.buttonClientAdd.TabIndex = 26;
            this.buttonClientAdd.Text = "Add Client";
            this.buttonClientAdd.UseVisualStyleBackColor = true;
            // 
            // buttonClientSave
            // 
            this.buttonClientSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonClientSave.Location = new System.Drawing.Point(56, 1074);
            this.buttonClientSave.Name = "buttonClientSave";
            this.buttonClientSave.Size = new System.Drawing.Size(300, 50);
            this.buttonClientSave.TabIndex = 27;
            this.buttonClientSave.Text = "Save List";
            this.buttonClientSave.UseVisualStyleBackColor = true;
            // 
            // buttonClientLoad
            // 
            this.buttonClientLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonClientLoad.Location = new System.Drawing.Point(54, 1130);
            this.buttonClientLoad.Name = "buttonClientLoad";
            this.buttonClientLoad.Size = new System.Drawing.Size(302, 50);
            this.buttonClientLoad.TabIndex = 28;
            this.buttonClientLoad.Text = "Load List";
            this.buttonClientLoad.UseVisualStyleBackColor = true;
            // 
            // buttonClientRemove
            // 
            this.buttonClientRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonClientRemove.Location = new System.Drawing.Point(56, 1018);
            this.buttonClientRemove.Name = "buttonClientRemove";
            this.buttonClientRemove.Size = new System.Drawing.Size(300, 50);
            this.buttonClientRemove.TabIndex = 29;
            this.buttonClientRemove.Text = "Remove Client";
            this.buttonClientRemove.UseVisualStyleBackColor = true;
            // 
            // buttonClientClear
            // 
            this.buttonClientClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonClientClear.Location = new System.Drawing.Point(54, 1186);
            this.buttonClientClear.Name = "buttonClientClear";
            this.buttonClientClear.Size = new System.Drawing.Size(302, 50);
            this.buttonClientClear.TabIndex = 30;
            this.buttonClientClear.Text = "Clear List";
            this.buttonClientClear.UseVisualStyleBackColor = true;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonConnect.Location = new System.Drawing.Point(362, 343);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(441, 70);
            this.buttonConnect.TabIndex = 31;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            // 
            // buttonEnd
            // 
            this.buttonEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonEnd.Location = new System.Drawing.Point(362, 1018);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(441, 70);
            this.buttonEnd.TabIndex = 32;
            this.buttonEnd.Text = "End Process";
            this.buttonEnd.UseVisualStyleBackColor = true;
            // 
            // checkBoxClientSet
            // 
            this.checkBoxClientSet.AutoCheck = false;
            this.checkBoxClientSet.AutoSize = true;
            this.checkBoxClientSet.Enabled = false;
            this.checkBoxClientSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBoxClientSet.Location = new System.Drawing.Point(14, 363);
            this.checkBoxClientSet.Margin = new System.Windows.Forms.Padding(5);
            this.checkBoxClientSet.Name = "checkBoxClientSet";
            this.checkBoxClientSet.Size = new System.Drawing.Size(34, 33);
            this.checkBoxClientSet.TabIndex = 33;
            this.checkBoxClientSet.UseVisualStyleBackColor = true;
            // 
            // FormTLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 1358);
            this.Controls.Add(this.checkBoxClientSet);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonClientClear);
            this.Controls.Add(this.buttonClientRemove);
            this.Controls.Add(this.buttonClientLoad);
            this.Controls.Add(this.buttonClientSave);
            this.Controls.Add(this.buttonClientAdd);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.buttonLogClear);
            this.Controls.Add(this.buttonIPLocalRefresh);
            this.Controls.Add(this.buttonSPSave);
            this.Controls.Add(this.checkBoxIPSet);
            this.Controls.Add(this.checkBoxSPSet);
            this.Controls.Add(this.buttonSPRemove);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.listBoxProc);
            this.Controls.Add(this.listBoxClientIP);
            this.Controls.Add(this.listBoxIPLocal);
            this.Controls.Add(this.buttonSPSet);
            this.Controls.Add(this.textBoxLog);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormTLServer";
            this.Text = "Task Link 12 Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSPSet;
        private System.Windows.Forms.ListBox listBoxIPLocal;
        public System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.ListBox listBoxClientIP;
        private System.Windows.Forms.ListBox listBoxProc;
        public System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button buttonSPRemove;
        private System.Windows.Forms.CheckBox checkBoxSPSet;
        private System.Windows.Forms.CheckBox checkBoxIPSet;
        private System.Windows.Forms.Button buttonSPSave;
        private System.Windows.Forms.Button buttonIPLocalRefresh;
        private System.Windows.Forms.Button buttonLogClear;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Button buttonClientAdd;
        private System.Windows.Forms.Button buttonClientSave;
        private System.Windows.Forms.Button buttonClientLoad;
        private System.Windows.Forms.Button buttonClientRemove;
        private System.Windows.Forms.Button buttonClientClear;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.CheckBox checkBoxClientSet;
    }
}

