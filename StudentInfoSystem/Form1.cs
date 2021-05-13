using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.Serialization.Formatters.Binary;
/*
 * This class consists of main user interface.
 */
namespace StudentInfoSystem
{
    public partial class Form1 : Form
    {
        public static BindingList<Student> StdList = new BindingList<Student>(); //Binding List is created to store the student record
        public Form1() 
        {
            InitializeComponent();
        }
        /*
         * This method contains id validation and provides data source for datagridview
         */
        public void AddStudent(Student s)
        {
            Boolean idRepeatCheck = false;
            for(int i =0; i < dataGridView1.Rows.Count; i++) 
            {
                if(s.Id.ToString() == dataGridView1.Rows[i].Cells[0].Value.ToString()) //to check if id already exists
                {

                    idRepeatCheck = true; //if repeated, bool set to true
                }
            }
            if (idRepeatCheck == true)
            {
                MessageBox.Show("Id Already Taken!");
            }
            else
            {
                StdList.Add(s);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = StdList; //initializing datasource for grid to add student data in grid
            }
        }
        /*
         * This method contorls form load event
         */
        
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("studentRecord.txt"))//check if the serialized file exists
            {
                DeSerialize(); //calling Deserialize method
            }

            dataGridView1.DataSource = StdList;
            dataGridView1.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            comboBox1.SelectedIndex = 0;
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(6); //loading value of dateTimePicker2 on form load

        }
        /*
         * This method retrives the data from studentRecord.txt file 
         */
        private void DeSerialize()
        {
            FileStream fst = new FileStream("studentRecord.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter bfr = new BinaryFormatter();
            StdList = (BindingList<Student>)bfr.Deserialize(fst);
            fst.Close();
        }
        /*
         * This method saves the data to studentRecord.txt file
         */
        private void Serialize()
        {
            FileStream fst = new FileStream("studentRecord.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter bfr = new BinaryFormatter();
            bfr.Serialize(fst, StdList);
            fst.Close();

        }

        /*
         * This method is used for modifying student record
         */
        public void ModifyStudent(int id, String name, String addr, String gen, DateTime dob,String cntct, String mail, String program, DateTime regdate)
        {
            foreach (Student s in StdList)
            {
                if (s.Id == id)
                {
                    s.SetStudent(id, name, addr, gen, dob, cntct, mail, program, regdate); 
                    dataGridView1.Refresh();
                    return;
                }
            }
        }
        /*
         *This method is used for deleting existin record from gridview 
         */
        public void RemoveStudent(int id)
        {
            foreach (Student es in StdList)
            {
                if (es.Id == id) //check id
                {
                    StdList.Remove(es); // removes the data of selected id
                    return;
                }
            }
        }


        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        /*
         * This method is invoked when Add Student button is clicked. It opens the form to add student
         */
        private void Button1_Click_1(object sender, EventArgs e)
        {
           
            if (Application.OpenForms["AddStudent"] == null) //check if form is already opened or not 
            {
                AddStudent a = new AddStudent(); //create object of AddStudent
                a.Show(); //show AddStudent form
                
            }
            else
            {
                Application.OpenForms["AddStudent"].BringToFront(); //if form is already opened brings to front
            }
        }
        /*
         * This method imports data to external csv file 
         */
        private void Button2_Click_1(object sender, EventArgs e)
        {
            //opens open dialog with file type csv
            OpenFileDialog ofd = new OpenFileDialog(); 
            ofd.Filter = "CSV File|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //StreamReader sr = new StreamReader(ofd.FileName);
                String[] lines = File.ReadAllLines(ofd.FileName);
                String[] items;
                bool firstline = true;
                //lines.Skip(1);
                foreach (String line in lines)
                {
                    items = line.Split(',');
                    if (firstline == true)
                        firstline = false;
                    else
                    {
                        //defining data to store in file
                        Student s = new Student(Convert.ToInt32(items[0]), items[1], items[2], items[3], Convert.ToDateTime(items[4]), items[5], items[6], items[7], Convert.ToDateTime(items[8]));
                        AddStudent(s);
                    }
                }
                MessageBox.Show("Data imported successfully.");
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["AddStudent"] == null)
                {
                    AddStudent a = new AddStudent();
                    a.ModifyRecord = true;//to allow modify the student record
                    a.Text = "Modify Record";
                    a.SetData(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value), dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[4].Value), dataGridView1.SelectedRows[0].Cells[5].Value.ToString(), dataGridView1.SelectedRows[0].Cells[6].Value.ToString(), dataGridView1.SelectedRows[0].Cells[7].Value.ToString(), Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[8].Value));
                    a.Show();

                }
                else
                {
                    MessageBox.Show("Already Opened!");
                    Application.OpenForms["AddStudent"].BringToFront();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No rows selected!");
            }
            }
        /*
         * When user clicks delete button this method handles the click event
         */
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveStudent(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("No rows selected!\n Select Row to Delete");
            }
        }
        /*
         * Handles Export button click event
         */
        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv;";
            sfd.DefaultExt = ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter wr = new StreamWriter(sfd.FileName);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ID, Name, Address, Gender, DateofBirth, Contact, Email, Program, Registration Date");
                foreach (Student std in StdList)
                {
                    sb.AppendLine(std.Id.ToString() + "," + std.Name + "," + std.Address + "," + std.Gender+ ","+std.DateOfBirth.ToString()+"," + std.Contact.ToString() + "," + std.Email + "," + std.ProgramEnrol + "," + std.RegistrationDate.ToString());
                }
                wr.Write(sb.ToString());
                wr.Close();
                MessageBox.Show("Data exported Successfully!");
            }
        }
       
        /*
         * Handles Search button click event
         */
        private void BtnSearch_Click(object sender, EventArgs e)
        {

            BindingList<WeeklyReport> MyReport = new BindingList<WeeklyReport>(); // initializing bindin list to store weekly report
            MyReport.Add(new WeeklyReport("Computing", 0)); //adding rows
            MyReport.Add(new WeeklyReport("Multimedia Technologies", 0));
            MyReport.Add(new WeeklyReport("Networks & IT Security", 0));
            MyReport.Add(new WeeklyReport("BBA", 0));

            int totalCount = 0;
            foreach (Student st in StdList)
            {
                //comparing reistration date of the students in gridview within the user selected week
                if (st.RegistrationDate.CompareTo(Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString())) >= 0 && st.RegistrationDate.CompareTo(Convert.ToDateTime(dateTimePicker2.Value.AddDays(1).ToShortDateString())) < 0)
                {
                    foreach (WeeklyReport r in MyReport)
                        if (r.ProgramName.Equals(st.ProgramEnrol))
                            r.StudentCount++; //count student in each program
                    totalCount++;
                }
            }
            dataGridView3.DataSource = MyReport; //addin report list data to datagridview
            dataGridView3.Columns[0].HeaderText = "Program Name"; //assining columns name
            dataGridView3.Columns[1].HeaderText = "Student Count";
            dataGridView3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
            txtGrandTotal.Text = totalCount.ToString();

        } 

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        /*
         * Initialize the value of dateTimepicker2 by adding 6 days in the value chosen in dateTimePicker1
         */
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(6);
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  SortList();
        }
        /*
         * Method for swapping items in a list
         */

        private void SwapingItem(int i, int j)
        {
            Student temp;
            temp = StdList[i];
            StdList[i] = StdList[j];
            StdList[j] = temp;
        }
        /*
         * bubble sort agorithm to sort the data 
         */
        private void SortList()
        {

            for (int i = 0; i < StdList.Count - 1; i++)
                for (int j = 0; j < StdList.Count - 1; j++)
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0: //when Id is chosen in comboBox
                            if (StdList[j].Id.CompareTo(StdList[j + 1].Id) > 0) 
                            {
                                SwapingItem(j, j + 1);
                            }
                            break;
                        case 1: //when Name is chosen in comboBox
                            if (StdList[j].Name.CompareTo(StdList[j + 1].Name) > 0)
                            {
                                SwapingItem(j, j + 1);
                            }
                            break;
                        case 2: //when Reistration Date is chosen in comboBox
                            if (StdList[j].RegistrationDate.CompareTo(StdList[j + 1].RegistrationDate) > 0)
                            {
                                SwapingItem(j, j + 1);
                            }
                            break;
                    }

                }
            dataGridView1.DataSource = StdList; 
        }
/*
 * Handles click event of generate report button
 */
        private void Button1_Click_2(object sender, EventArgs e)
        {
            if (Application.OpenForms["DataVisualize"] == null) //check is already open or not
            {
                DataVisualize d = new DataVisualize(StdList);

                d.ShowDialog(); //opens DataVisualize form
            }
            else
            {
                Application.OpenForms["DataVisualize"].BringToFront(); //brings to front if already open
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            Serialize(); //calls Serialize method to store data on form closing
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click_3(object sender, EventArgs e)
        {
            
            if (pageSetupDialog1.ShowDialog() == DialogResult.OK) 
            {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
                printPreviewDialog1.ShowDialog();
            }
        }
        //for printing out data 
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 300, 300, printDocument1.DefaultPageSettings.
               PaperSize.Height - 300, printDocument1.DefaultPageSettings.PaperSize.
               Width - 300);


            int line = 110;
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                e.Graphics.DrawString(dataGridView3.Rows[i].Cells["Program"].
                    Value.ToString(), dataGridView3.Font, Brushes.Black, 120, line);
                line = line + 50;
                e.Graphics.DrawString(dataGridView3.Rows[i].Cells["Student Count"].
                    Value.ToString(), dataGridView3.Font, Brushes.Black, 120, line);
                line = line + 50;
               

            }
        }
        
        private void TxtSearch_TextChanged_1(object sender, EventArgs e)
        {
            BindingList<Student> result = new BindingList<Student>();
            foreach (Student st in StdList)
            {
                if (st.Name.ToUpper().Contains(txtSearch.Text.ToUpper())) //searches name same to that in textbox
                {
                    result.Add(st); 
                }
            }
            dataGridView1.DataSource = result; //shows search data to grid view
            
        }

        private void TxtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.Text = ""; //clears text box on click
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SortList(); //sorting table on combobox item change
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    
    [Serializable]
    public class Student
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public String Name { get; set; }
        public String Address { get; set; }
        public String Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Contact { get; set; }
        public String Email { get; set; }
        public String ProgramEnrol
        {
            get; set;
        }
        public DateTime RegistrationDate { get; set; }

        public Student(int id, String name, String addr, String gen, DateTime dob, String cntct, String mail, String program, DateTime regdate)
        {
            SetStudent(id, name, addr, gen, dob, cntct, mail, program, regdate);

        }
        public void SetStudent(int id, String name, String addr, String gen, DateTime dob, String cntct, String mail, String program, DateTime regdate)
        {
            this.id = id;
            Name = name;
            Address = addr;
            Gender = gen;
            DateOfBirth = dob;
            Contact = cntct;
            Email = mail;
            ProgramEnrol = program;
            RegistrationDate = regdate;

        }
    }
    public class WeeklyReport
    {
        public string ProgramName
        { get; set; }
        public int StudentCount
        { get; set; }
        public WeeklyReport(string p, int c)
        {
            ProgramName = p;
            StudentCount = c;
        }
    }
}
