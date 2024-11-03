using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace PRG282Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable myTable = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            myTable.Columns.Add("StudentID", typeof(int));
            myTable.Columns.Add("Name", typeof(string));
            myTable.Columns.Add("Age", typeof(int));
            myTable.Columns.Add("Course", typeof(string));


            myTable.Rows.Add(600836, "Kagiso Sebati", 20, "PRG281");
            myTable.Rows.Add(36564, "KSUHUH JSDHIU", 43, "UIUWU7");

            dataGridView1.DataSource = myTable;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myTable.Rows.Add(txtStudentID.Text, txtName.Text, txtAge.Text, txtCourse.Text);

            dataGridView1.DataSource = myTable;
        }
    }
}
