using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Text_FileApp
{
    public partial class FrmFileName : Form
    {
        public static string SetFileName;
     
        public FrmFileName()
        {
            InitializeComponent();
        }
      
        private void btnOkay_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFileName.Text))
                {
                    throw new Exception("File name cannot be empty. Please enter a valid file name.");
                }
                if (txtFileName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
                {
                    throw new Exception("File name contains invalid characters. Please enter a valid file name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            SetFileName = txtFileName.Text;
            Close();
        }
    }
}
