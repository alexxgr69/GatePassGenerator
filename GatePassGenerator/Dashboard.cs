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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        String role;
        public Dashboard(String role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
         
        private void Dashboard_Load(object sender, EventArgs e)
        {
            String backgroundName;
            if ("ADMIN".Equals(role))
            {
                employeeToolStripMenuItem.Visible = true;
                backgroundName = "gatePassBg1";
                labelWelcomeText.Text = "Admin Dashboard";
            }
            else
            {
                employeeToolStripMenuItem.Visible = false;
                backgroundName = "gatePassBg2";
                labelWelcomeText.Text =  "Employee Dashboard";
            }
            Image image = Image.FromFile(Utility.getImageStorePath(backgroundName));
            this.BackgroundImage = image;
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
             if(MessageBox.Show("You want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to Exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
              if(Application.OpenForms.OfType<AddEmploye>().Count() == 1)
            {
                Application.OpenForms.OfType<AddEmploye>().First().BringToFront();
                //forma AddEmploye dispare cand facem click pe Dashboard
            }
            else
            {
                AddEmploye addEmployee = new AddEmploye();
                addEmployee.Show();

            }
        }

        private void updateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<UpdateEmployee>().Count() == 1)
            {
                Application.OpenForms.OfType<UpdateEmployee>().First().BringToFront();
                //in cazul cand deja am creat o forma, apare la click pe buton
            }
            else
            {
                UpdateEmployee updateEmployee = new UpdateEmployee();
                updateEmployee.Show();
                //daca inca nu avem forma deschisa, o cream
            }
        }

        private void viewAllEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms.OfType<ViewEmployee>().Count() == 1)
            {
                Application.OpenForms.OfType<ViewEmployee>().First().BringToFront();
            }
            else
            {
                ViewEmployee viewEmployee = new ViewEmployee();
                viewEmployee.Show();
            }
        }

        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<DeleteEmployee>().Count() == 1)
            {
                Application.OpenForms.OfType<DeleteEmployee>().First().BringToFront();
            }
            else
            {
                DeleteEmployee deleteEmployee = new DeleteEmployee();
                deleteEmployee.Show();

            }
        }

        private void addVisitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms.OfType<AddVisitor>().Count() == 1)
            {
                Application.OpenForms.OfType<AddVisitor>().First().BringToFront();
            }
            else
            {
                AddVisitor addVisitor = new AddVisitor();
                addVisitor.Show();
            }
        }

        private void updateVisitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms.OfType<UpdateVisitor>().Count() == 1)
            {
                Application.OpenForms.OfType<UpdateVisitor>().First().BringToFront();
            }
            else
            {
                UpdateVisitor updateVisitor = new UpdateVisitor();
                updateVisitor.Show();
            }
        }

        private void viewVisitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Application.OpenForms.OfType<ViewVisitors>().Count() == 1)
            {
                Application.OpenForms.OfType<ViewVisitors>().First().BringToFront();
            }
            else
            {
                ViewVisitors viewVisitors = new ViewVisitors();
                viewVisitors.Show();
            }
        }

     

        private void validatePassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ValidatePass>().Count() == 1)
            {
                Application.OpenForms.OfType<ValidatePass>().First().BringToFront();
            }
            else
            {
                ValidatePass validatePass = new ValidatePass();
                validatePass.Show();
            }
        }

        private void generatePassToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<GeneratePass>().Count() == 1)
            {
                Application.OpenForms.OfType<GeneratePass>().First().BringToFront();
            }
            else
            {
                GeneratePass generatePass = new GeneratePass();
                generatePass.Show();
            }
        }

        private void filterPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FilterPass>().Count() == 1)
            {
                Application.OpenForms.OfType<FilterPass>().First().BringToFront();
            }
            else
            {
                FilterPass filterPass = new FilterPass();
                filterPass.Show();
            }
        }
    }
}
