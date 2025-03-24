using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatePassGenerator
{
    public partial class AddVisitor : Form
    {
        DatabaseOperations databaseOperations = new DatabaseOperations();
        String query;
        DataSet ds;
        public AddVisitor()
        {
            InitializeComponent();
        }
        String visitorID;
        Boolean imageUploaded = false;
        String path;
        private void AddVisitor_Load(object sender, EventArgs e)
        {
            visitorID = Utility.getUniqueId("VID-");
            //generam un id umic vizitatorilor cu prefixul VID
            txtVisitor.Text = visitorID;
            path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10)) + "\\Images\\" + visitorID+".jpg";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\";
            open.Filter = "(*.jpg;*.jpeg;*.bmp;) | *.jpg;*.jpeg;*.bmp;";
            open.FilterIndex = 1;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (open.CheckFileExists)
                {
                    if (!File.Exists(path))
                    {
                        System.IO.File.Copy(open.FileName, path);
                        //copiem imaginea gasita in path-ul nostru
                    }
                    else
                    {
                        pictureBox1.Image.Dispose(); //stergem imaginea din pictureBox
                        pictureBox1.Image = null;
                        System.IO.File.Delete(path);
                        System.IO.File.Copy(open.FileName, path);
                    }
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = Image.FromFile(path);
                    imageUploaded = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                String name = txtName.Text;
                String contact = txtContact.Text;
                String gender = txtGender.Text;
                String address = txtAddress.Text;
                String uniqueID = txtUniqueId.Text;

                if (imageUploaded)
                {
                    if (!String.IsNullOrEmpty(name) &&
                       !String.IsNullOrEmpty(contact) &&
                       !String.IsNullOrEmpty(gender) &&
                       !String.IsNullOrEmpty(address) &&
                       !String.IsNullOrEmpty(uniqueID))
                    {
                        Int64 contactNum = Int64.Parse(contact);
                        query = "insert into visitors (vname,contact,gender,vaddress,uniqueId,visitorId) values('" + name + "','" + contact + "','" + gender + "','" + address + "','" + uniqueID + "','" + visitorID + "')";
                        databaseOperations.setData(query, "Visitor was successfully added.");
                        clearAllfields();
                    }
                    else
                    {
                        MessageBox.Show("Fill mandatory fields and try again. ", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Picture not selected.","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in Add visitor Save Click" + ex);
                MessageBox.Show("Something went wrong: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.onlyNumber(e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (imageUploaded)
            {
                //in caz ca deja am incarcat imaginea in imagebox mai intai stergem imaginea si dupa dse inchide forma
                 if(MessageBox.Show("Image will be removed", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                    System.IO.File.Delete(path);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void clearAllfields()
        {
            txtName.Clear();
            txtUniqueId.Clear();
            txtGender.SelectedIndex = -1;
            txtContact.Clear();
            txtAddress.Clear();

            imageUploaded = false;
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;

            }
            AddVisitor_Load(this, null);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAllfields();
        }
    }
}
