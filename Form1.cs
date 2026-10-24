using System;
using System.IO;
using System.Linq.Expressions;
using System.Windows.Forms;
namespace Text_FileApp
{
    public partial class FrmLab1 : Form
    {
        public FrmLab1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtInput.Text))
                {
                    throw new Exception("Input cannot be empty. Please enter some text.");
                }


                FrmFileName frmFileName = new FrmFileName();
                frmFileName.ShowDialog();
                string getInput = txtInput.Text;

                string docpath = Application.StartupPath;

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docpath, FrmFileName.SetFileName)))
                {
                    outputFile.WriteLine(getInput);
                    Console.WriteLine(getInput);
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show("An I/O error occurred: " + ioEx.Message);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show("Access denied: " + uaEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message);
            }
        }

        private void FrmLab1_Load(object sender, EventArgs e)
        {

        }
    }
}
