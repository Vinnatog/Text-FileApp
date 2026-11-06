using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EDPLab2SOpenFile;


namespace Text_FileApp
{
    public partial class FrmStudentRecord : Form
    {
        public FrmStudentRecord()
        {
            InitializeComponent();
            ApplyStyle();
            BuildLeftPanel();
        }
        public void DisplayToList()
        {
            openFileDialog1.InitialDirectory = @"C:\Users\Enteng13\source\repos";
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string path = openFileDialog1.FileName;
            lvShowText.Items.Clear();

            try
            {
                lvShowText.View = View.Details;
                lvShowText.FullRowSelect = true;
                lvShowText.GridLines = true;
                lvShowText.Columns.Clear();
                lvShowText.Columns.Add("Line #", 60);
                lvShowText.Columns.Add("Text", 400);
                this.Text = "Selected: " + Path.GetFileName(path);

                using (StreamReader streamReader = File.OpenText(path))
                {
                    string lineText;
                    int lineNumber = 1;

                    while ((lineText = streamReader.ReadLine()) != null)
                    {
                        ListViewItem item = new ListViewItem(lineNumber.ToString());
                        item.SubItems.Add(lineText);
                        lvShowText.Items.Add(item);
                        lineNumber++;
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot read the file.", "File Error");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegistration frmRegistration = new FrmRegistration();
            frmRegistration.ShowDialog();
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DisplayToList();

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully Uploaded!", "Upload");
            lvShowText.Items.Clear();
        }

        private readonly Color primary = Color.FromArgb(164, 179, 138); // sage mo
        private readonly Color primaryHover = Color.FromArgb(143, 159, 116);
        private readonly Color headerColor = Color.FromArgb(74, 85, 62);
        private readonly Color bgColor = Color.FromArgb(247, 249, 243);
        private readonly Color textDark = Color.FromArgb(45, 52, 38);

        private void ApplyStyle()
        {
            this.BackColor = bgColor;
            this.Font = new Font("Segoe UI", 10F);
            this.StartPosition = FormStartPosition.CenterScreen;

            StyleButton(btnRegister);
            StyleButton(btnFind);
            StyleButton(btnUpload);
        }

        private void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = primary;
            btn.ForeColor = textDark;
            btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Size = new Size(180, 56);

            btn.MouseEnter += (s, e) => btn.BackColor = primaryHover;
            btn.MouseLeave += (s, e) => btn.BackColor = primary;
        }

        private void BuildLeftPanel()
        {
            Panel leftPanel = new Panel
            {
                BackColor = headerColor,
                Dock = DockStyle.Left,
                Width = 330
            };

            Label title = new Label
            {
                Text = "Student\nRecord",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(30, 90)
            };

            Label subtitle = new Label
            {
                Text = "Manage, search, and upload\nstudent information.",
                ForeColor = primary,
                Font = new Font("Segoe UI", 11F),
                AutoSize = true,
                Location = new Point(34, 220)
            };

            leftPanel.Controls.Add(title);
            leftPanel.Controls.Add(subtitle);
            this.Controls.Add(leftPanel);
            leftPanel.SendToBack();
        }
    }
}

