namespace CloudLM.Forms
{
    partial class FrmApp
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
            this.valValidTill = new System.Windows.Forms.Label();
            this.lblValidTill = new System.Windows.Forms.Label();
            this.valValidFrom = new System.Windows.Forms.Label();
            this.lblValidFrom = new System.Windows.Forms.Label();
            this.valMachineId = new System.Windows.Forms.Label();
            this.lblMachineId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // valValidTill
            // 
            this.valValidTill.AutoSize = true;
            this.valValidTill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valValidTill.Location = new System.Drawing.Point(98, 105);
            this.valValidTill.Name = "valValidTill";
            this.valValidTill.Size = new System.Drawing.Size(64, 13);
            this.valValidTill.TabIndex = 11;
            this.valValidTill.Text = "Loading...";
            // 
            // lblValidTill
            // 
            this.lblValidTill.AutoSize = true;
            this.lblValidTill.Location = new System.Drawing.Point(32, 105);
            this.lblValidTill.Name = "lblValidTill";
            this.lblValidTill.Size = new System.Drawing.Size(46, 13);
            this.lblValidTill.TabIndex = 10;
            this.lblValidTill.Text = "Valid Till";
            // 
            // valValidFrom
            // 
            this.valValidFrom.AutoSize = true;
            this.valValidFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valValidFrom.Location = new System.Drawing.Point(98, 68);
            this.valValidFrom.Name = "valValidFrom";
            this.valValidFrom.Size = new System.Drawing.Size(64, 13);
            this.valValidFrom.TabIndex = 9;
            this.valValidFrom.Text = "Loading...";
            // 
            // lblValidFrom
            // 
            this.lblValidFrom.AutoSize = true;
            this.lblValidFrom.Location = new System.Drawing.Point(32, 68);
            this.lblValidFrom.Name = "lblValidFrom";
            this.lblValidFrom.Size = new System.Drawing.Size(56, 13);
            this.lblValidFrom.TabIndex = 8;
            this.lblValidFrom.Text = "Valid From";
            // 
            // valMachineId
            // 
            this.valMachineId.AutoSize = true;
            this.valMachineId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valMachineId.Location = new System.Drawing.Point(98, 30);
            this.valMachineId.Name = "valMachineId";
            this.valMachineId.Size = new System.Drawing.Size(64, 13);
            this.valMachineId.TabIndex = 7;
            this.valMachineId.Text = "Loading...";
            // 
            // lblMachineId
            // 
            this.lblMachineId.AutoSize = true;
            this.lblMachineId.Location = new System.Drawing.Point(32, 30);
            this.lblMachineId.Name = "lblMachineId";
            this.lblMachineId.Size = new System.Drawing.Size(60, 13);
            this.lblMachineId.TabIndex = 6;
            this.lblMachineId.Text = "Machine Id";
            // 
            // FrmApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.valValidTill);
            this.Controls.Add(this.lblValidTill);
            this.Controls.Add(this.valValidFrom);
            this.Controls.Add(this.lblValidFrom);
            this.Controls.Add(this.valMachineId);
            this.Controls.Add(this.lblMachineId);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmApp";
            this.Text = "App";
            this.Load += new System.EventHandler(this.FrmApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label valValidTill;
        private System.Windows.Forms.Label lblValidTill;
        private System.Windows.Forms.Label valValidFrom;
        private System.Windows.Forms.Label lblValidFrom;
        private System.Windows.Forms.Label valMachineId;
        private System.Windows.Forms.Label lblMachineId;
    }
}