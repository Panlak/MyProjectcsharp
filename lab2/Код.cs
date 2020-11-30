using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
        }
        private void changevalue()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            toolStripSplitButton1.Enabled = true;

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void GenericA_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            areyA = geteretic(areyA);


            print(areyA, 1);


            changevalue();
        }

        private void GenericB_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            areyB = geteretic(areyB);



            print(areyB, 2);


            changevalue();
        }
        public static int[,] areyA;
        public static int[,] areyB;

        public int[,] geteretic(int[,] arrey)
        {

            int size = 0, size2 = 0;
            switch (domainUpDown1.SelectedIndex)
            {
                case 0:
                    size = 3; size2 = 3;
                    break;
                case 1:
                    size = 4; size2 = 4;
                    break;
                case 2:
                    size = 5; size2 = 5;
                    break;

            }

            Random rand = new Random();
            arrey = new int[size, size2];
            for (int i = 0; i < arrey.GetLength(0); i++)
            {

                for (int j = 0; j < arrey.GetLength(1); j++)
                {
                    arrey[i, j] = rand.Next(0, 10);

                }
            }

            return arrey;


        }
        public void print(int[,] myary, int indexFORPRINT)
        {
            string s;
            for (int i = 0; i < myary.GetLength(0); i++)
            {
                s = "        ";
                for (int j = 0; j < myary.GetLength(1); j++)
                {
                    s += (myary[i, j]).ToString() + "  ";
                }
                if (indexFORPRINT == 1)
                    listBox1.Items.Add(s);
                else if (indexFORPRINT == 2)
                    listBox2.Items.Add(s);



            }
        }
        public int[] addarey(int index1rey, int[] str, int size = 0, int size1 = 0)
        {
            try
            {
                switch (domainUpDown1.SelectedIndex)
                {
                    case 0:
                        size = 3;
                        break;
                    case 1:
                        size = 4;
                        break;
                    case 2:
                        size = 5;
                        break;

                }

                str = new int[size];

                if (index1rey == 1)
                    for (int i = 0; i < size; i++)
                        str[i] = areyA[size1, i];


                else if (index1rey == 2)
                    for (int i = 0; i < size; i++)
                        str[i] = areyB[size1, i];



                
            }
            
            catch
            {
                MessageBox.Show("Не правильно введений діапазон",
                    "Помилка");
                
                
            }
            
            return str;
            
        }
        public void test(int indexfortest)
        {
            try
            {
                listBox2.Items.Clear();
                int valueA = 0;
                int valueB = 0;
                int size = 0;
                valueA = int.Parse(toolStripTextBox1.Text);
                valueB = int.Parse(toolStripTextBox2.Text);
                switch (domainUpDown1.SelectedIndex)
                {
                    case 0:
                        size = 3;
                        break;
                    case 1:
                        size = 4;
                        break;
                    case 2:
                        size = 5;
                        break;

                }

                if (indexfortest == 1)
                {
                    for (int i = 0; i < size; i++)
                        areyB[valueB, i] = areyA[valueA, i];
                }
                else if (indexfortest == 2)
                {
                    for (int i = 0; i < size; i++)
                        areyB[i, valueB] = areyA[i, valueA];
                }

                print(areyB, 2);
            }
            catch 
            {
                MessageBox.Show("Не правильно введенні рядки або стовпці",
                    "Помилка Введення");
                print(areyB, 2);
            }
        }

        private void Рядки_Click(object sender, EventArgs e)
        {
            string a = "Рядки";
            toolStripLabel1.Text = a;
            toolStripLabel5.Text = a;
            toolStripButton1.Enabled = true;
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripLabel1.Text == "Рядки")
                test(1);
            else if (toolStripLabel5.Text == "Стовпці")
                test(2);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = 4;
            numericUpDown1.Minimum = 0;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = 4;
            numericUpDown2.Minimum = 0;
        }

        private void Стовпці_Click(object sender, EventArgs e)
        {
            string a = "Стовпці";
            toolStripLabel1.Text = a;
            toolStripLabel5.Text = a;
            toolStripButton1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listBox3.Items.Clear();
                int sizea = 0;
                int sizeb = 0;
                int size = 0;
                switch (domainUpDown1.SelectedIndex)
                {
                    case 0:
                        size = 3;
                        break;
                    case 1:
                        size = 4;
                        break;
                    case 2:
                        size = 5;
                        break;
                }

                switch (numericUpDown1.Value)
                {
                    case 0:
                        sizea = 0;
                        break;
                    case 1:
                        sizea = 1;
                        break;
                    case 2:
                        sizea = 2;
                        break;
                    case 3:
                        sizea = 3;
                        break;
                    case 4:
                        sizea = 4;
                        break;
                }
                switch (numericUpDown2.Value)
                {
                    case 0:
                        sizeb = 0;
                        break;
                    case 1:
                        sizeb = 1;
                        break;
                    case 2:
                        sizeb = 2;
                        break;
                    case 3:
                        sizeb = 3;
                        break;
                    case 4:
                        sizeb = 4;
                        break;
                }



                onedimensional a1, a2, a3;
                a1 = new onedimensional(size);
                a1.inpt(1, size, sizea);
                a2 = new onedimensional(size);
                a2.inpt(2, size, sizeb);
                a3 = new onedimensional(size);
                a3 = a1 + a2;
                string s = a3.outp(1);
                listBox3.Items.Add(s);
            }
            catch
            {
                

            }


            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
           
            int size = 0;
            switch (domainUpDown1.SelectedIndex)
            {
                case 0:
                    size = 3;
                    break;
                case 1:
                    size = 4;
                    break;
                case 2:
                    size = 5;
                    break;
            }
            int sizeb = 0;
            switch (numericUpDown3.Value)
            {
                case 0:
                    sizeb = 0;
                    break;
                case 1:
                    sizeb = 1;
                    break;
                case 2:
                    sizeb = 2;
                    break;
                case 3:
                    sizeb = 3;
                    break;
                case 4:
                    sizeb = 4;
                    break;
            }
            onedimensional b;
            b = new onedimensional(size);
            b.inpt(2, size, sizeb);
            ++b;
            string s = b.outp(2);
            textBox1.Text = s;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Maximum = 4;
            numericUpDown3.Minimum = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
                int sizea = 0;
                int sizeb = 0;
                int size = 0;
                switch (domainUpDown1.SelectedIndex)
                {
                    case 0:
                        size = 3;
                        break;
                    case 1:
                        size = 4;
                        break;
                    case 2:
                        size = 5;
                        break;
                }

                switch (numericUpDown4.Value)
                {
                    case 0:
                        sizea = 0;
                        break;
                    case 1:
                        sizea = 1;
                        break;
                    case 2:
                        sizea = 2;
                        break;
                    case 3:
                        sizea = 3;
                        break;
                    case 4:
                        sizea = 4;
                        break;
                }
                switch (numericUpDown5.Value)
                {
                    case 0:
                        sizeb = 0;
                        break;
                    case 1:
                        sizeb = 1;
                        break;
                    case 2:
                        sizeb = 2;
                        break;
                    case 3:
                        sizeb = 3;
                        break;
                    case 4:
                        sizeb = 4;
                        break;
                }
                onedimensional a, b;
                a = new onedimensional(size);
                b = new onedimensional(size);
                a.inpt(1, size, sizea);
                b.inpt(2, size, sizeb);

            if (a != b)
            {
                MessageBox.Show("Рядки  не рівні",
                    "Перевірка на рівність");
            }
            else 
            {
                MessageBox.Show("Рядки рівні",
                   "Перевірка на рівність");
            }



        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown7.Maximum = 5;
            numericUpDown7.Minimum = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sizea = 0;
            int sizeb = 0;
            int size = 0;
            switch (domainUpDown1.SelectedIndex)
            {
                case 0:
                    size = 3;
                    break;
                case 1:
                    size = 4;
                    break;
                case 2:
                    size = 5;
                    break;
            }
            
            
            switch (numericUpDown6.Value)
            {
                case 0:
                    sizeb = 0;
                    break;
                case 1:
                    sizeb = 1;
                    break;                
                case 2:
                    sizeb = 2;
                    break;
                case 3:
                    sizeb = 3;
                    break;
                case 4:
                    sizeb = 4;
                    break;
            }
            switch (numericUpDown7.Value)
            {

                case 2:
                    sizea = 2;
                    break;
                case 3:
                    sizea = 3;
                    break;
                case 4:
                    sizea = 4;
                    break;
            }
            onedimensional a ;
            a = new onedimensional(size);
            a.inpt(1, size, sizeb);
            a=  a * sizea;
            string s = a.outp(1);
            textBox2.Text = s;
            


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown6.Maximum = 4;
            numericUpDown6.Minimum = 0;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown4.Maximum = 4;
            numericUpDown4.Minimum = 0;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown5.Maximum = 4;
            numericUpDown5.Minimum = 0;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    
}
