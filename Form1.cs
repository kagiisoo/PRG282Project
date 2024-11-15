﻿using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

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


            myTable.Rows.Add(36564, "Tshegofatso Mashego", 21, "PRG281");
            myTable.Rows.Add(36564, "Onthatile Mapheto", 20, "WPR281");
            myTable.Rows.Add(36564, "Dariin Mokuena", 19, "SAD281");
            myTable.Rows.Add(36564, "Kagiso Sebati", 22, "IOT281");
          

            dataGridView1.DataSource = myTable;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myTable.Rows.Add(txtStudentID.Text, txtName.Text, txtAge.Text, txtCourse.Text);

            dataGridView1.DataSource = myTable;

            if(txtStudentID is null || txtName is null || txtAge is null || txtCourse is null)
            {
                MessageBox.Show("Please fill in all fields.", "Error");
                return;
            }

            string studentRecord = $"{txtStudentID},{txtName},{txtAge},{txtCourse}";

            //string path = "students.txt";

            try
            {
                // Append the student data to students.txt
                using (StreamWriter writer = new StreamWriter("students.txt", true))
                {
                    writer.Write(studentRecord);
                }

                MessageBox.Show("Student saved successfully!", "Success");

                // Clear the input fields after saving
                ClearFields();
               
            }
            catch (Exception ex)
            {
                // Handle any errors that occur while saving
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtStudentID.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtCourse.Clear();
        }

    }
}

