using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Text_FileApp
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {


                string olderFileName = Application.StartupPath;

                string folderPath = Application.StartupPath;

                string[] studentInfo =
                {
                    "Student No.: " + txtStuNo.Text,
                    "Full Name: " + txtLname.Text + ", " + txtFname.Text + " " + txtMI.Text + ".",
                    "Program: " + cmbProgram.Text,
                    "Gender: " + cmbGender.Text,
                    "Age: " + txtAge.Text,
                    "Birthday: " + dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                    "Contact No.: " + txtContact.Text
                };
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(folderPath, txtStuNo.Text + ".txt")))
                {
                    foreach (string infoLine in studentInfo)
                    {
                        outputFile.WriteLine(infoLine);
                    }
                }
                if (!long.TryParse(txtContact.Text, out long contactNumber) || txtContact.Text.Length != 11)
                {
                    throw new FormatException("Invalid contact number. Please enter a valid 11-digit number.");
                }
                if (dateTimePicker1.Value >= DateTime.Now)
                {
                    throw new InvalidOperationException("Invalid birthday. Please enter a valid date.");
                }
                if (string.IsNullOrWhiteSpace(txtStuNo.Text) || string.IsNullOrWhiteSpace(txtLname.Text) ||
                    string.IsNullOrWhiteSpace(txtFname.Text) || string.IsNullOrWhiteSpace(txtMI.Text) ||
                    string.IsNullOrWhiteSpace(cmbProgram.Text) || string.IsNullOrWhiteSpace(cmbGender.Text) ||
                    string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(txtContact.Text))
                {
                    throw new FormatException("Please fill in all the required fields.");
                }

                MessageBox.Show("Registration successful! Check " + folderPath);


            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] programs = { "BSIT", "BSCS", "BSIS", "BSEMC", "BSECE" };
            foreach (string program in programs)
            {

                cmbProgram.Items.Add(program);
            }
            string[] Gender = { "Male", "Female" };
            foreach (string gender in Gender)
            {
                cmbGender.Items.Add(gender);
            }
            cmbGender.SelectedIndex = 0;

        }
    }
}
