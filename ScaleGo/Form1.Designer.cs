namespace ScaleGo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      this.btnConnectScale = new System.Windows.Forms.Button();
      this.txtWeight = new System.Windows.Forms.TextBox();
      this.txtAWB = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tmrGetWeight = new System.Windows.Forms.Timer(this.components);
      this.btnUpdateWeight = new System.Windows.Forms.Button();
      this.lblMsg = new System.Windows.Forms.Label();
      this.txtComPortID = new System.Windows.Forms.TextBox();
      this.txtLog = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnConnectScale
      // 
      this.btnConnectScale.Location = new System.Drawing.Point(19, 101);
      this.btnConnectScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnConnectScale.Name = "btnConnectScale";
      this.btnConnectScale.Size = new System.Drawing.Size(95, 19);
      this.btnConnectScale.TabIndex = 0;
      this.btnConnectScale.Text = "Connect Scale";
      this.btnConnectScale.UseVisualStyleBackColor = true;
      this.btnConnectScale.Click += new System.EventHandler(this.btnConnectScale_Click);
      // 
      // txtWeight
      // 
      this.txtWeight.Location = new System.Drawing.Point(119, 101);
      this.txtWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.txtWeight.Name = "txtWeight";
      this.txtWeight.ReadOnly = true;
      this.txtWeight.Size = new System.Drawing.Size(95, 20);
      this.txtWeight.TabIndex = 1;
      // 
      // txtAWB
      // 
      this.txtAWB.Location = new System.Drawing.Point(119, 127);
      this.txtAWB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.txtAWB.Name = "txtAWB";
      this.txtAWB.Size = new System.Drawing.Size(95, 20);
      this.txtAWB.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(16, 127);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(30, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "AWB";
      // 
      // tmrGetWeight
      // 
      this.tmrGetWeight.Interval = 1000;
      this.tmrGetWeight.Tick += new System.EventHandler(this.tmrGetWeight_Tick);
      // 
      // btnUpdateWeight
      // 
      this.btnUpdateWeight.Location = new System.Drawing.Point(19, 158);
      this.btnUpdateWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnUpdateWeight.Name = "btnUpdateWeight";
      this.btnUpdateWeight.Size = new System.Drawing.Size(195, 19);
      this.btnUpdateWeight.TabIndex = 4;
      this.btnUpdateWeight.Text = "Update Weight";
      this.btnUpdateWeight.UseVisualStyleBackColor = true;
      this.btnUpdateWeight.Click += new System.EventHandler(this.btnUpdateWeight_Click);
      // 
      // lblMsg
      // 
      this.lblMsg.Location = new System.Drawing.Point(219, 101);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new System.Drawing.Size(259, 76);
      this.lblMsg.TabIndex = 5;
      this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // txtComPortID
      // 
      this.txtComPortID.Location = new System.Drawing.Point(39, 46);
      this.txtComPortID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.txtComPortID.Name = "txtComPortID";
      this.txtComPortID.Size = new System.Drawing.Size(96, 20);
      this.txtComPortID.TabIndex = 6;
      // 
      // txtLog
      // 
      this.txtLog.Location = new System.Drawing.Point(222, 198);
      this.txtLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.txtLog.Multiline = true;
      this.txtLog.Name = "txtLog";
      this.txtLog.ReadOnly = true;
      this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtLog.Size = new System.Drawing.Size(266, 276);
      this.txtLog.TabIndex = 7;
      // 
      // Form1
      // 
      this.AcceptButton = this.btnUpdateWeight;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(508, 485);
      this.Controls.Add(this.txtComPortID);
      this.Controls.Add(this.txtLog);
      this.Controls.Add(this.lblMsg);
      this.Controls.Add(this.btnUpdateWeight);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtAWB);
      this.Controls.Add(this.txtWeight);
      this.Controls.Add(this.btnConnectScale);
      this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.Name = "Form1";
      this.Text = "ScaleGo v1.0";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Shown += new System.EventHandler(this.Form1_Shown);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnectScale;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtAWB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrGetWeight;
        private System.Windows.Forms.Button btnUpdateWeight;
        private System.Windows.Forms.Label lblMsg;
    private System.Windows.Forms.TextBox txtComPortID;
    private System.Windows.Forms.TextBox txtLog;
  }
}

