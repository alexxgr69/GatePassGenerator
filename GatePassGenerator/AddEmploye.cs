using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;


namespace GatePassGenerator
{
    public partial class AddEmploye : Form
    {
        DatabaseOperations databaseOperations = new DatabaseOperations();
        String query;
        DataSet ds;
        public AddEmploye()
        {
            InitializeComponent();
        }

        private void AddEmploye_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
      

            try
            {
                String name = txtName.Text;
                String hireDate = txtHireDate.Text;
                String contact = txtContact.Text;
                String gender = txtGender.Text;
                String address = txtAddress.Text;
                String city = txtCity.Text;
                String state = txtState.Text;
                String userName = txtUsername.Text;
                String password = txtPassword.Text;
                
                if(!String.IsNullOrEmpty(name) &&
                    !String.IsNullOrEmpty(hireDate) &&
                    !String.IsNullOrEmpty(contact) &&
                    !String.IsNullOrEmpty(gender) &&
                    !String.IsNullOrEmpty(address) &&
                    !String.IsNullOrEmpty(city) &&
                    !String.IsNullOrEmpty(state) &&
                    !String.IsNullOrEmpty(userName) &&
                    !String.IsNullOrEmpty(password))
                    //validarea(verificam daca nu se lasa campurile goale la completare)
                {

                    Int64 contactInt = Int64.Parse(contact);
            

                    query = "select * from appUser where username='" + userName + "' and uenabled=1";
                    ds = databaseOperations.getData(query);
                    if(ds!=null && ds.Tables[0].Rows.Count == 0)
                    {
                        query="insert into appUser(username,upass,urole) values ('"+userName+ "','" + password + "','EMPLOYEE')";
                        databaseOperations.setData(query, null);
                        
                        query =  "select * from appUser where username='" + userName + "' and upass = '" + password + "' and uenabled = 1";
                        ds = databaseOperations.getData(query);

                        query = "insert into employee(ename,hiredate,contact,gender,eaddress,city,estate,appuser_fk) values ('" + name + "','" + hireDate + "'," + contactInt + ",'" + gender + "','" + address + "','" + city + "','" + state + "'," + ds.Tables[0].Rows[0][0] + ")";
                        databaseOperations.setData(query, "Employee added successfully.");
                        clearAllFields();
                        MessageBox.Show("New employee was added succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Username already linked with another account.", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                      
                    }
                }
                else
                {
                    MessageBox.Show("Fields empty. Fill and try ahain", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Exception in Add Employe btnSave Click: " + ex);
                MessageBox.Show("Something wenr wrong :" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.onlyNumber(e);
        }

        private void clearAllFields()
        {
            txtName.Clear();
            txtHireDate.ResetText();
            txtContact.Clear();
            txtGender.SelectedIndex = -1;
            txtAddress.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
          
        }
    }
}
