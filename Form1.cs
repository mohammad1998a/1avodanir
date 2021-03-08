using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxtFile
{
    public partial class Form1 : Form
    {
        string inputfile = @"../../file1.txt";

        public Form1()
        {
            InitializeComponent();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            int flag = 0;
            foreach (var line in File.ReadAllLines(inputfile))//עוברים על כל שורה 
            {
                string[] inputs = line.Split(',');//מחלקים לפי הפסיק
                if(inputs[3]==txtCode.Text)
                {
                    MessageBox.Show("Recipe already in");
                    flag = 1;
                }
            }

            if (txtCode.Text==""||txtDesc.Text==""||txtName.Text==""||txtTimeInMin.Text=="")
            {
                MessageBox.Show("Fill all inputs");
                flag = 1;
            }
           if(flag==0)
            {
                //מוספים את פרטי המוצר בנוסף פסיק ביניהם
                File.AppendAllText(inputfile, txtName.Text + "," + txtTimeInMin.Text + "," + txtDesc.Text + "," + txtCode.Text + "\n");
                //משתנה שמכיל הטקסת שבקובץ
                String input = File.ReadAllText(inputfile);
                //הצגה
                lblViewr.Text = input;
                MessageBox.Show("Recipe added successfully");
            }
        }

        private void btnbuy_Click(object sender, EventArgs e)
        {
             File.WriteAllText(inputfile, "");//איפוס file
            String input = File.ReadAllText(inputfile);  //משתנה שמכיל הטקסת שבקובץ
            lblViewr.Text = input;//הצגה

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(inputfile))
            {
                File.Delete(inputfile);
                MessageBox.Show("File has been deleted");
            }
            else
                MessageBox.Show("File not found");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            if (!File.Exists(inputfile))
            {
                using (fs = File.Create(inputfile))
                {
                    MessageBox.Show("File has been Created");

                }
            }
            else
                MessageBox.Show("File already exists");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(inputfile))
            {
                String input = File.ReadAllText(inputfile);
                lblViewr.Text = input;
            }
            else
                MessageBox.Show("File not exists");

        }
    }
}
