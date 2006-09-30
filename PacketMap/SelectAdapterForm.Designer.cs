namespace PacketMap {
    partial class SelectAdapterForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.lstAdapters = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAdapterInfo1 = new System.Windows.Forms.Label();
            this.lblAdapterInfo2 = new System.Windows.Forms.Label();
            this.lblAdapterData1 = new System.Windows.Forms.Label();
            this.lblAdapterData2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select network adapter that you wish to monitor:";
            // 
            // lstAdapters
            // 
            this.lstAdapters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAdapters.FormattingEnabled = true;
            this.lstAdapters.Location = new System.Drawing.Point(12, 27);
            this.lstAdapters.Name = "lstAdapters";
            this.lstAdapters.Size = new System.Drawing.Size(480, 95);
            this.lstAdapters.TabIndex = 1;
            this.lstAdapters.SelectedIndexChanged += new System.EventHandler(this.lstAdapters_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(336, 232);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(417, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblAdapterInfo1
            // 
            this.lblAdapterInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdapterInfo1.AutoSize = true;
            this.lblAdapterInfo1.Location = new System.Drawing.Point(13, 131);
            this.lblAdapterInfo1.Name = "lblAdapterInfo1";
            this.lblAdapterInfo1.Size = new System.Drawing.Size(93, 65);
            this.lblAdapterInfo1.TabIndex = 4;
            this.lblAdapterInfo1.Text = "IP Address:\r\nSubnet Mask:\r\nDefault Gateway:\r\nPrimary WINS:\r\nSecondary WINS:";
            // 
            // lblAdapterInfo2
            // 
            this.lblAdapterInfo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdapterInfo2.AutoSize = true;
            this.lblAdapterInfo2.Location = new System.Drawing.Point(229, 131);
            this.lblAdapterInfo2.Name = "lblAdapterInfo2";
            this.lblAdapterInfo2.Size = new System.Drawing.Size(118, 78);
            this.lblAdapterInfo2.TabIndex = 5;
            this.lblAdapterInfo2.Text = "Loopback:\r\nMAC Address:\r\nDHCP Enabled:\r\nDHCP Server:\r\nDHCP Lease Obtained:\r\nDHCP " +
                "Lease Expires:";
            // 
            // lblAdapterData1
            // 
            this.lblAdapterData1.AutoSize = true;
            this.lblAdapterData1.Location = new System.Drawing.Point(112, 131);
            this.lblAdapterData1.Name = "lblAdapterData1";
            this.lblAdapterData1.Size = new System.Drawing.Size(92, 13);
            this.lblAdapterData1.TabIndex = 6;
            this.lblAdapterData1.Text = "-- select adapter --";
            // 
            // lblAdapterData2
            // 
            this.lblAdapterData2.AutoSize = true;
            this.lblAdapterData2.Location = new System.Drawing.Point(353, 131);
            this.lblAdapterData2.Name = "lblAdapterData2";
            this.lblAdapterData2.Size = new System.Drawing.Size(92, 13);
            this.lblAdapterData2.TabIndex = 7;
            this.lblAdapterData2.Text = "-- select adapter --";
            // 
            // SelectAdapterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 266);
            this.Controls.Add(this.lblAdapterData2);
            this.Controls.Add(this.lblAdapterData1);
            this.Controls.Add(this.lblAdapterInfo2);
            this.Controls.Add(this.lblAdapterInfo1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstAdapters);
            this.Controls.Add(this.label1);
            this.Name = "SelectAdapterForm";
            this.Text = "Select network adapter";
            this.Load += new System.EventHandler(this.SelectAdapterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstAdapters;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAdapterInfo1;
        private System.Windows.Forms.Label lblAdapterInfo2;
        private System.Windows.Forms.Label lblAdapterData1;
        private System.Windows.Forms.Label lblAdapterData2;
    }
}