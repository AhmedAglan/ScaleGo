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
      this.SuspendLayout();
      // 
      // btnConnectScale
      // 
      this.btnConnectScale.Location = new System.Drawing.Point(22, 124);
      this.btnConnectScale.Name = "btnConnectScale";
      this.btnConnectScale.Size = new System.Drawing.Size(111, 23);
      this.btnConnectScale.TabIndex = 0;
      this.btnConnectScale.Text = "Connect Scale";
      this.btnConnectScale.UseVisualStyleBackColor = true;
      this.btnConnectScale.Click += new System.EventHandler(this.btnConnectScale_Click);
      // 
      // txtWeight
      // 
      this.txtWeight.Location = new System.Drawing.Point(139, 124);
      this.txtWeight.Name = "txtWeight";
      this.txtWeight.ReadOnly = true;
      this.txtWeight.Size = new System.Drawing.Size(110, 24);
      this.txtWeight.TabIndex = 1;
      // 
      // txtAWB
      // 
      this.txtAWB.Location = new System.Drawing.Point(139, 156);
      this.txtAWB.Name = "txtAWB";
      this.txtAWB.Size = new System.Drawing.Size(110, 24);
      this.txtAWB.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(19, 156);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 17);
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
      this.btnUpdateWeight.Location = new System.Drawing.Point(22, 195);
      this.btnUpdateWeight.Name = "btnUpdateWeight";
      this.btnUpdateWeight.Size = new System.Drawing.Size(227, 23);
      this.btnUpdateWeight.TabIndex = 4;
      this.btnUpdateWeight.Text = "Update Weight";
      this.btnUpdateWeight.UseVisualStyleBackColor = true;
      this.btnUpdateWeight.Click += new System.EventHandler(this.btnUpdateWeight_Click);
      // 
      // lblMsg
      // 
      this.lblMsg.Location = new System.Drawing.Point(255, 124);
      this.lblMsg.Name = "lblMsg";
      this.lblMsg.Size = new System.Drawing.Size(302, 94);
      this.lblMsg.TabIndex = 5;
      this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // txtComPortID
      // 
      this.txtComPortID.Location = new System.Drawing.Point(45, 56);
      this.txtComPortID.Name = "txtComPortID";
      this.txtComPortID.Size = new System.Drawing.Size(111, 24);
      this.txtComPortID.TabIndex = 6;
      // 
      // Form1
      // 
      this.AcceptButton = this.btnUpdateWeight;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.txtComPortID);
      this.Controls.Add(this.lblMsg);
      this.Controls.Add(this.btnUpdateWeight);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtAWB);
      this.Controls.Add(this.txtWeight);
      this.Controls.Add(this.btnConnectScale);
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ScaleGo v1.0";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
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
  }
}

