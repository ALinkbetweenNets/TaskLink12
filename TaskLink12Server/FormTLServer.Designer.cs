﻿namespace TaskLink12Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTLServer));
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonSPSet = new System.Windows.Forms.Button();
            this.listBoxIPLocal = new System.Windows.Forms.ListBox();
            this.listBoxClientIP = new System.Windows.Forms.ListBox();
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
            this.checkedListBoxProc = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(407, 6);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(300, 576);
            this.textBoxLog.TabIndex = 100;
            // 
            // buttonSPSet
            // 
            this.buttonSPSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonSPSet.Location = new System.Drawing.Point(28, 44);
            this.buttonSPSet.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSPSet.Name = "buttonSPSet";
            this.buttonSPSet.Size = new System.Drawing.Size(247, 36);
            this.buttonSPSet.TabIndex = 1;
            this.buttonSPSet.Text = "Set Session Password";
            this.buttonSPSet.UseVisualStyleBackColor = true;
            this.buttonSPSet.Click += new System.EventHandler(this.buttonSPSet_Click);
            // 
            // listBoxIPLocal
            // 
            this.listBoxIPLocal.FormattingEnabled = true;
            this.listBoxIPLocal.ItemHeight = 16;
            this.listBoxIPLocal.Location = new System.Drawing.Point(277, 6);
            this.listBoxIPLocal.Margin = new System.Windows.Forms.Padding(1);
            this.listBoxIPLocal.Name = "listBoxIPLocal";
            this.listBoxIPLocal.Size = new System.Drawing.Size(125, 116);
            this.listBoxIPLocal.TabIndex = 99;
            this.listBoxIPLocal.SelectedIndexChanged += new System.EventHandler(this.listBoxIPLocal_SelectedIndexChanged);
            // 
            // listBoxClientIP
            // 
            this.listBoxClientIP.FormattingEnabled = true;
            this.listBoxClientIP.ItemHeight = 16;
            this.listBoxClientIP.Location = new System.Drawing.Point(28, 217);
            this.listBoxClientIP.Margin = new System.Windows.Forms.Padding(1);
            this.listBoxClientIP.Name = "listBoxClientIP";
            this.listBoxClientIP.Size = new System.Drawing.Size(152, 308);
            this.listBoxClientIP.TabIndex = 4;
            this.listBoxClientIP.Click += new System.EventHandler(this.listBoxClientIP_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(277, 151);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.ReadOnly = true;
            this.textBoxIP.Size = new System.Drawing.Size(125, 22);
            this.textBoxIP.TabIndex = 101;
            // 
            // buttonSPRemove
            // 
            this.buttonSPRemove.Enabled = false;
            this.buttonSPRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonSPRemove.Location = new System.Drawing.Point(28, 123);
            this.buttonSPRemove.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSPRemove.Name = "buttonSPRemove";
            this.buttonSPRemove.Size = new System.Drawing.Size(247, 26);
            this.buttonSPRemove.TabIndex = 3;
            this.buttonSPRemove.Text = "Delete File";
            this.buttonSPRemove.UseVisualStyleBackColor = true;
            this.buttonSPRemove.Click += new System.EventHandler(this.buttonSPRemove_Click);
            // 
            // checkBoxSPSet
            // 
            this.checkBoxSPSet.AutoCheck = false;
            this.checkBoxSPSet.AutoSize = true;
            this.checkBoxSPSet.Enabled = false;
            this.checkBoxSPSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBoxSPSet.Location = new System.Drawing.Point(7, 54);
            this.checkBoxSPSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxSPSet.Name = "checkBoxSPSet";
            this.checkBoxSPSet.Size = new System.Drawing.Size(18, 17);
            this.checkBoxSPSet.TabIndex = 106;
            this.checkBoxSPSet.UseVisualStyleBackColor = true;
            // 
            // checkBoxIPSet
            // 
            this.checkBoxIPSet.AutoCheck = false;
            this.checkBoxIPSet.AutoSize = true;
            this.checkBoxIPSet.Enabled = false;
            this.checkBoxIPSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBoxIPSet.Location = new System.Drawing.Point(185, 154);
            this.checkBoxIPSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxIPSet.Name = "checkBoxIPSet";
            this.checkBoxIPSet.Size = new System.Drawing.Size(18, 17);
            this.checkBoxIPSet.TabIndex = 105;
            this.checkBoxIPSet.UseVisualStyleBackColor = true;
            // 
            // buttonSPSave
            // 
            this.buttonSPSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonSPSave.Location = new System.Drawing.Point(28, 84);
            this.buttonSPSave.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSPSave.Name = "buttonSPSave";
            this.buttonSPSave.Size = new System.Drawing.Size(247, 36);
            this.buttonSPSave.TabIndex = 2;
            this.buttonSPSave.Text = "Save Session Password";
            this.buttonSPSave.UseVisualStyleBackColor = true;
            this.buttonSPSave.Click += new System.EventHandler(this.buttonSPSave_Click);
            // 
            // buttonIPLocalRefresh
            // 
            this.buttonIPLocalRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonIPLocalRefresh.Location = new System.Drawing.Point(277, 123);
            this.buttonIPLocalRefresh.Margin = new System.Windows.Forms.Padding(1);
            this.buttonIPLocalRefresh.Name = "buttonIPLocalRefresh";
            this.buttonIPLocalRefresh.Size = new System.Drawing.Size(124, 26);
            this.buttonIPLocalRefresh.TabIndex = 4;
            this.buttonIPLocalRefresh.Text = "Refresh Local IPs";
            this.buttonIPLocalRefresh.UseVisualStyleBackColor = true;
            this.buttonIPLocalRefresh.Click += new System.EventHandler(this.buttonIPLocalRefresh_Click);
            // 
            // buttonLogClear
            // 
            this.buttonLogClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonLogClear.Location = new System.Drawing.Point(587, 586);
            this.buttonLogClear.Margin = new System.Windows.Forms.Padding(1);
            this.buttonLogClear.Name = "buttonLogClear";
            this.buttonLogClear.Size = new System.Drawing.Size(117, 26);
            this.buttonLogClear.TabIndex = 13;
            this.buttonLogClear.Text = "Clear Log";
            this.buttonLogClear.UseVisualStyleBackColor = true;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(207, 155);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(66, 17);
            this.labelIP.TabIndex = 102;
            this.labelIP.Text = "Local IP: ";
            // 
            // buttonClientAdd
            // 
            this.buttonClientAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonClientAdd.Location = new System.Drawing.Point(28, 177);
            this.buttonClientAdd.Margin = new System.Windows.Forms.Padding(1);
            this.buttonClientAdd.Name = "buttonClientAdd";
            this.buttonClientAdd.Size = new System.Drawing.Size(149, 36);
            this.buttonClientAdd.TabIndex = 5;
            this.buttonClientAdd.Text = "Add Client";
            this.buttonClientAdd.UseVisualStyleBackColor = true;
            this.buttonClientAdd.Click += new System.EventHandler(this.buttonClientAdd_Click);
            // 
            // buttonClientSave
            // 
            this.buttonClientSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonClientSave.Location = new System.Drawing.Point(28, 556);
            this.buttonClientSave.Margin = new System.Windows.Forms.Padding(1);
            this.buttonClientSave.Name = "buttonClientSave";
            this.buttonClientSave.Size = new System.Drawing.Size(149, 26);
            this.buttonClientSave.TabIndex = 7;
            this.buttonClientSave.Text = "Save List";
            this.buttonClientSave.UseVisualStyleBackColor = true;
            this.buttonClientSave.Click += new System.EventHandler(this.buttonClientSave_Click);
            // 
            // buttonClientLoad
            // 
            this.buttonClientLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonClientLoad.Location = new System.Drawing.Point(28, 586);
            this.buttonClientLoad.Margin = new System.Windows.Forms.Padding(1);
            this.buttonClientLoad.Name = "buttonClientLoad";
            this.buttonClientLoad.Size = new System.Drawing.Size(149, 26);
            this.buttonClientLoad.TabIndex = 8;
            this.buttonClientLoad.Text = "Load List";
            this.buttonClientLoad.UseVisualStyleBackColor = true;
            this.buttonClientLoad.Click += new System.EventHandler(this.buttonClientLoad_Click);
            // 
            // buttonClientRemove
            // 
            this.buttonClientRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonClientRemove.Location = new System.Drawing.Point(28, 528);
            this.buttonClientRemove.Margin = new System.Windows.Forms.Padding(1);
            this.buttonClientRemove.Name = "buttonClientRemove";
            this.buttonClientRemove.Size = new System.Drawing.Size(149, 26);
            this.buttonClientRemove.TabIndex = 6;
            this.buttonClientRemove.Text = "Remove Client";
            this.buttonClientRemove.UseVisualStyleBackColor = true;
            this.buttonClientRemove.Click += new System.EventHandler(this.buttonClientRemove_Click);
            // 
            // buttonClientClear
            // 
            this.buttonClientClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonClientClear.Location = new System.Drawing.Point(28, 614);
            this.buttonClientClear.Margin = new System.Windows.Forms.Padding(1);
            this.buttonClientClear.Name = "buttonClientClear";
            this.buttonClientClear.Size = new System.Drawing.Size(149, 26);
            this.buttonClientClear.TabIndex = 9;
            this.buttonClientClear.Text = "Clear List";
            this.buttonClientClear.UseVisualStyleBackColor = true;
            this.buttonClientClear.Click += new System.EventHandler(this.buttonClientClear_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonConnect.Location = new System.Drawing.Point(183, 177);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(1);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(220, 36);
            this.buttonConnect.TabIndex = 10;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonEnd.Location = new System.Drawing.Point(183, 585);
            this.buttonEnd.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(220, 36);
            this.buttonEnd.TabIndex = 12;
            this.buttonEnd.Text = "End Process";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // checkBoxClientSet
            // 
            this.checkBoxClientSet.AutoCheck = false;
            this.checkBoxClientSet.AutoSize = true;
            this.checkBoxClientSet.Enabled = false;
            this.checkBoxClientSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.checkBoxClientSet.Location = new System.Drawing.Point(7, 187);
            this.checkBoxClientSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxClientSet.Name = "checkBoxClientSet";
            this.checkBoxClientSet.Size = new System.Drawing.Size(18, 17);
            this.checkBoxClientSet.TabIndex = 107;
            this.checkBoxClientSet.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxProc
            // 
            this.checkedListBoxProc.FormattingEnabled = true;
            this.checkedListBoxProc.Location = new System.Drawing.Point(183, 217);
            this.checkedListBoxProc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkedListBoxProc.Name = "checkedListBoxProc";
            this.checkedListBoxProc.ScrollAlwaysVisible = true;
            this.checkedListBoxProc.Size = new System.Drawing.Size(223, 344);
            this.checkedListBoxProc.TabIndex = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 109;
            this.label1.Text = "TaskLink 12 Server";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(968, 279);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 110;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 652);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBoxProc);
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
            this.Controls.Add(this.listBoxClientIP);
            this.Controls.Add(this.listBoxIPLocal);
            this.Controls.Add(this.buttonSPSet);
            this.Controls.Add(this.textBoxLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.CheckedListBox checkedListBoxProc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

