using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatePassGenerator
{
    public partial class UpdateEmployee : Form
    {
        DatabaseOperations databaseOperations = new DatabaseOperations();
        String query;
        DataSet ds;
        Boolean employeeAvailable;

        public UpdateEmployee()
        {
            InitializeComponent();
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                String username = txtUsername.Text;
                query = "select e.*, a.* from employee as e inner join appUser as a on e.appuser_fk=a.appuser_pk where a.username='" + username + "'";
                ds = databaseOperations.getData(query);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    employeeAvailable = true;
                    txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtHireDate.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtGender.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtCity.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtState.Text = ds.Tables[0].Rows[0][7].ToString();

                    //umplem campurile cu atributele utilizatorului gasit;
                }
                else
                {
                    employeeAvailable = false;
                    MessageBox.Show("Employee not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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


                if (employeeAvailable)
                {
                    if(!String.IsNullOrEmpty(name) &&
                    !String.IsNullOrEmpty(hireDate) &&
                    !String.IsNullOrEmpty(contact) &&
                    !String.IsNullOrEmpty(gender) &&
                    !String.IsNullOrEmpty(address) &&
                    !String.IsNullOrEmpty(city) &&
                    !String.IsNullOrEmpty(state) &&
                    !String.IsNullOrEmpty(userName))
                    {
                        Int64 number = Int64.Parse(contact);
                        query = "update e set e.ename='" + name + "', e.hiredate='" + hireDate + "',e.contact=" + contact + ",e.gender='" + gender + "',e.eadress='" + address + "',e.city='" + city + "', e.estate='"+state+"' from employee as e inner join appUser as a on e.appuser_fk=a.appUser_pk where a.username = '"+userName+"' ";
                        databaseOperations.setData(query, "Employee updated");
                        clearAllFields();
                    }
                    else
                    {
                        MessageBox.Show("Fields empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                   
                    //validarea(verificam daca nu se lasa campurile goale la completare)
                }
                else
                {
                    MessageBox.Show("Employee not found. ", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
               catch (Exception ex)
               {
                Console.WriteLine(ex);
               }
            }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAllFields();
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
            employeeAvailable = false;
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.onlyNumber(e);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            clearAllFields();
            //ca sa evitam errorile, de fiecare adta dupa ce gasim un utilizator si incercam sa mai scriem ceva in cautare,
            //mai intai se sterg toate campurile si dupa cautam alt utilizator
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
 }
