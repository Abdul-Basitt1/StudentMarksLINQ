using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentMarksLINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        List<Studentinfo> studentinfo = new List<Studentinfo>();

        private void addInfo(object sender, EventArgs e)
        {
            Studentinfo std = new Studentinfo();
            std.StudentID = int.Parse(stdid.Text);
            std.StudentName = stdname.Text;
            std.Age = int.Parse(stdage.Text);
            std.marks = int.Parse(stdmarks.Text);
            std.gender = stdgender.Text;
            studentinfo.Add(std);
            dataGridView1.Rows.Add(std.StudentID, std.StudentName, std.Age, std.marks, std.gender);

            MessageBox.Show("Data inserted");
        }

        private void searchbyname(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string combine = "";
            var names = from name in studentinfo
                        where name.StudentName == stdname.Text
                        select name;
            foreach (Studentinfo studentinfo in names)
            {
                 dataGridView1.Rows.Add(studentinfo.StudentID, studentinfo.StudentName, studentinfo.Age, studentinfo.marks, studentinfo.gender);

                combine = combine + studentinfo.StudentName + " ";
            }

            answer.Text = combine;
        }

        private void search_greatermarks(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string combine = "";
            var names = from name in studentinfo
                        where name.marks > int.Parse(mrks.Text)
                        select name;
            foreach (Studentinfo studentinfo in names)
            {
                dataGridView1.Rows.Add(studentinfo.StudentID, studentinfo.StudentName, studentinfo.Age, studentinfo.marks, studentinfo.gender);
                combine = combine + studentinfo.marks + " ";
            }

            answer.Text = combine;
        }

        private void sort_aCCTOMARKS(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string combine = "";
            var names = from name in studentinfo
                        orderby name.marks descending
                        select name;
            foreach (Studentinfo studentinfo in names)
            {
                dataGridView1.Rows.Add(studentinfo.StudentID, studentinfo.StudentName, studentinfo.Age, studentinfo.marks, studentinfo.gender);
                combine = combine + studentinfo.marks + " ";
            }

            answer.Text = combine;
        }

        private void sortgender(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string combine = "";
            var names = from name in studentinfo
                        orderby name.gender ascending
                        select name;
            foreach (Studentinfo studentinfo in names)
            {
                dataGridView1.Rows.Add(studentinfo.StudentID, studentinfo.StudentName, studentinfo.Age, studentinfo.marks, studentinfo.gender);
                combine = combine + studentinfo.gender + " ";
            }

            answer.Text = combine;
        }
    }
}
