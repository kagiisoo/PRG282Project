using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282Project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadSummaryReport();
        }

        private void LoadSummaryReport()
        {
            string filePath = @"C:\Users\darri\Source\Repos\kagiisoo\PRG282Project\students.txt";
            List<Student> students = new List<Student>();

            // Read student data from the file
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var data = line.Split(',');

                    if (data.Length == 4 && int.TryParse(data[2], out int age)) // Ensure all fields are valid
                    {
                        students.Add(new Student
                        {
                            StudentID = int.Parse(data[0]),
                            Name = data[1],
                            Age = age,
                            Course = data[3]
                        });
                    }
                }
            }

            // Calculate summary data
            int totalStudents = students.Count;
            double averageAge = students.Count > 0 ? students.Average(s => s.Age) : 0;

            // Display summary data in DataGridView
            dataGridViewSummary.Rows.Clear();
            dataGridViewSummary.Columns.Clear();
            dataGridViewSummary.Columns.Add("Metric", "Metric");
            dataGridViewSummary.Columns.Add("Value", "Value");

            dataGridViewSummary.Rows.Add("Total Students", totalStudents);
            dataGridViewSummary.Rows.Add("Average Age", averageAge);
            

            // Save summary to summary.txt
            File.WriteAllText(@"C:\Users\darri\Source\Repos\kagiisoo\PRG282Project\summary.txt", $"Total Students: {totalStudents}\nAverage Age: {averageAge:F2}");
        }
    }

    // Define the Student class if not already defined elsewhere in the project
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
    }
}
