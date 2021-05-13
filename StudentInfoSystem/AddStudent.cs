using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace StudentInfoSystem
{
    public partial class AddStudent : Form
    {
        public bool ModifyRecord { get; set; }

        public AddStudent()
        {
            InitializeComponent();
            
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }
        /*
         * 
         */
        public void SetData(int id, String name, String addr, String gen, DateTime dob, String cntct, String mail, String program, DateTime regdate)
        {
            txtId.Text = id.ToString();
            txtName.Text = name;
            txtAddress.Text = addr;
            cmbGender.SelectedItem = gen;
            DoB.Value = dob;
            txtContact.Text = cntct.ToString();
            txtEmail.Text = mail;
            cmbProgramAdd.SelectedItem = program;
            dateAddStd.Value = regdate;
            txtId.ReadOnly = true;
        }
        /*
         * Method to clear the field after each add
         */
        private void Clear()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            cmbGender.SelectedIndex = 0;
            DoB.Value = DateTime.Today;
            txtContact.Text = "";
            txtEmail.Text = "";
            cmbProgramAdd.SelectedIndex = 0;
            dateAddStd.Value = DateTime.Today;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ModifyRecord == false)
                {

                    Regex rg = new Regex("[a-zA-Z0-9]{1,20}@[a-zA-Z]{1,20}.[a-zA-Z]{2,3}");
                    if (txtId.Text != "" && txtName.Text != "" && txtAddress.Text != "" && cmbGender.SelectedIndex != 0 && txtContact.Text != "" && txtEmail.Text != "" && cmbProgramAdd.SelectedIndex != 0)
                    {
                        if (rg.IsMatch(txtEmail.Text)) // email validation
                        {
                            if (txtContact.Text.Length > 9 && txtContact.Text.Length < 16) // contact validation
                            {
                                if (cmbGender.SelectedIndex != 0) //checks if gender is selected
                                {
                                    if (cmbProgramAdd.SelectedIndex != 0) //checks if program is chosen
                                    {
                                        Student newStd = new Student(Convert.ToInt32(txtId.Text), txtName.Text, txtAddress.Text, cmbGender.SelectedItem.ToString(), DoB.Value, txtContact.Text, txtEmail.Text, cmbProgramAdd.SelectedItem.ToString(), dateAddStd.Value);
                                        ((Form1)Application.OpenForms["Form1"]).AddStudent(newStd);
                                        MessageBox.Show("Data Added Successfully!");
                                        Clear();


                                    }
                                    else
                                    {
                                        MessageBox.Show("Please select course!");//error message
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please Select your gender!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Enter valid Contact!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email not Valid!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Fill all Fields!");
                    }



                }
                else
                {
                    Regex rg = new Regex("[a-zA-Z0-9]{1,20}@[a-zA-Z]{1,20}.[a-zA-Z]{2,3}");
                    if (txtId.Text != "" && txtName.Text != "" && txtAddress.Text != "" && cmbGender.SelectedIndex != 0 && txtContact.Text != "" && txtEmail.Text != "" && cmbProgramAdd.SelectedIndex != 0)
                    {
                        if (rg.IsMatch(txtEmail.Text))
                        {
                            if (txtContact.Text.Length > 9 && txtContact.Text.Length < 16)
                            {
                                if (cmbGender.SelectedIndex != 0)
                                {
                                    if (cmbProgramAdd.SelectedIndex != 0)
                                    {
                                        //opens form  for modifying data 
                                        ((Form1)Application.OpenForms["Form1"]).ModifyStudent(Convert.ToInt32(txtId.Text), txtName.Text, txtAddress.Text, cmbGender.SelectedItem.ToString(), DoB.Value, txtContact.Text, txtEmail.Text, cmbProgramAdd.SelectedItem.ToString(), dateAddStd.Value);
                                        MessageBox.Show("Data Modified Successfully!");
                                        Clear();
                                        

                                    }
                                    else
                                    {
                                        MessageBox.Show("Please select course!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please Select your gender!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Enter valid Contact!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email not Valid!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Fill all Fields!");
                    }


                }
            }
            catch 
            {
                MessageBox.Show("All fields are required");
            }
            
        }
       

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            //cmbProgramAdd.SelectedIndex = 0;
            //cmbGender.SelectedIndex = 0;
        }

        private void TxtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //restricts user to type string in contact 
            {
                e.Handled = true;
            }
        }
    }
}
