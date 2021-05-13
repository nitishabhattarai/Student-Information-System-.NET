using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StudentInfoSystem
{
    public partial class DataVisualize : Form
    {
        BindingList<Student> StdList; 
        BindingList<ChartList> chartlist = new BindingList<ChartList>();
        public DataVisualize(BindingList<Student> NewStdList)
        {
            InitializeComponent();
            StdList = NewStdList;
        }
        /*
         * To create charts showin programs and number of students
         */
        public void EnrollmentChart()
        {
            int totalstd=0;
            
            chartlist.Add(new ChartList("Computing", 0));
            chartlist.Add(new ChartList("Multimedia Technologies", 0));
            chartlist.Add(new ChartList("Networks & IT Security", 0));
            chartlist.Add(new ChartList("BBA", 0));

            foreach (Student student in StdList) //each student one by one
            {

                foreach (ChartList list in chartlist) 
                    if (list.name.Equals(student.ProgramEnrol)) //checks the student in respective program
                        list.count++;
                totalstd++;

            }
            txtTotalStd.Text = Convert.ToString(totalstd); //shows total number of student in text box

            chart1.DataSource = chartlist;
            chart1.Series[0].YValueMembers = "count";
            chart1.Series[0].XValueMember = "name";
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[0].IsVisibleInLegend = true;
            cmbChart.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void BtnChartBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        /*
         * To show different types of charts on user preference
         */
        private void CmbChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChart.SelectedIndex == 0)
                chart1.Series[0].ChartType = SeriesChartType.Pie;
            else if (cmbChart.SelectedIndex == 1)
                chart1.Series[0].ChartType = SeriesChartType.Pyramid;
            else if (cmbChart.SelectedIndex == 2)
                chart1.Series[0].ChartType = SeriesChartType.Line;

        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void DataVisualize_Load(object sender, EventArgs e)
        {
            EnrollmentChart();
        }
    }
    public class ChartList
    {

        public ChartList(String Name, int Count)
        {
            this.count = Count;
            this.name = Name;

        }
        public string name
        {
            get;
            set;
        }
        public int count
        {
            get;
            set;
        }
    }
}
