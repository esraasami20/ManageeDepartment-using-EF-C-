using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFW1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DeptStdEntities employ = new DeptStdEntities();
        Emp emp = new Emp();
        public bool con()
        {
            foreach (var item in employ.Emps)
            {
                if (item.ID == emp.ID)
                {
                    MessageBox.Show("Rep ID");
                }
            }
            return true;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {            
            try
            {
                emp.ID = int.Parse(IDbox.Text);
                emp.Fname = fname.Text;
                emp.Lname = lname.Text;
                emp.Title = title.Text;
                emp.Salary = int.Parse(salary.Text);
                employ.Emps.Add(emp);
                employ.SaveChanges();
                MessageBox.Show("^_^ Employe Added ^_^");
                fname.Text = lname.Text = title.Text = salary.Text = IDbox.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("^_^ Try Again ^_^");
                fname.Text = lname.Text = title.Text = salary.Text = IDbox.Text = string.Empty;

            }
            

        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            
            try
            {
                DeptStdEntities ent = new DeptStdEntities();
                Emp emp = new Emp();
                int IFound = int.Parse(IDbox.Text);
                var itemFound = ent.Emps.Where(d => d.ID == IFound).Select(d => d).First();

                fname.Text = itemFound.Fname;
                lname.Text = itemFound.Lname;
                title.Text = itemFound.Title;
                salary.Text = Convert.ToString(itemFound.Salary);               

            }
            catch
            {
                MessageBox.Show("^_^ It Can not be Founded ^_^");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                DeptStdEntities EmpEnt = new DeptStdEntities();
                Emp emp2 = new Emp();
                int IDFound = int.Parse(IDbox.Text);
                var itemFound = EmpEnt.Emps.Where(d => d.ID == IDFound).Select(d => d).First();
                itemFound.Fname = fname.Text.ToString();
                itemFound.Lname = lname.Text.ToString();
                itemFound.Title = title.Text.ToString();
                itemFound.Salary = int.Parse(salary.Text);          

                EmpEnt.SaveChanges();                
                MessageBox.Show("^_^ Employe Updated ^_^");
                fname.Text = lname.Text = title.Text = salary.Text = IDbox.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show("^_^ Try Again ^_^");
                fname.Text = lname.Text = title.Text = salary.Text = IDbox.Text = string.Empty;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            { 
                DeptStdEntities ent = new DeptStdEntities();
                Emp emp = new Emp();
                int IDFound = int.Parse(IDbox.Text);
                var itemFound = ent.Emps.Where(d => d.ID == IDFound).Select(d => d).First();
                ent.Emps.Remove(itemFound);
                ent.SaveChanges();
                MessageBox.Show("^_^ Employe Deleted ^_^");
                IDbox.Text = fname.Text = lname.Text = title.Text = salary.Text = string.Empty;
            }  
            catch
            {
                MessageBox.Show("^_^ Try Again ^_^");
                fname.Text = lname.Text = title.Text = salary.Text = IDbox.Text = string.Empty;
            }
}
    }
}
