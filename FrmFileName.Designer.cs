namespace Text_FileApp
{
    partial class FrmFileName
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
            btnOkay = new Button();
            txtFileName = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnOkay
            // 
            btnOkay.FlatStyle = FlatStyle.Flat;
            btnOkay.Location = new Point(242, 178);
            btnOkay.Name = "btnOkay";
            btnOkay.Size = new Size(117, 37);
            btnOkay.TabIndex = 3;
            btnOkay.Text = "Ok";
            btnOkay.UseVisualStyleBackColor = true;
            btnOkay.Click += btnOkay_Click;
            // 
            // txtFileName
            // 
            txtFileName.BackColor = SystemColors.InactiveCaption;
            txtFileName.Location = new Point(175, 85);
            txtFileName.Multiline = true;
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(254, 74);
            txtFileName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(175, 43);
            label1.Name = "label1";
            label1.Size = new Size(156, 25);
            label1.TabIndex = 4;
            label1.Text = "Enter File Name:";
            // 
            // FrmFileName
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(653, 311);
            Controls.Add(label1);
            Controls.Add(btnOkay);
            Controls.Add(txtFileName);
            Name = "FrmFileName";
            Text = "FrmFileName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOkay;
        private TextBox txtFileName;
        private Label label1;
    }
}