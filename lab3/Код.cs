using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        int[] arr;
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            button1.Enabled = true;
            button3.Enabled = true;
            int size = Convert.ToInt32( numericUpDown4.Value);            
            Class_arifm poshuk1 = new Class_arifm(size);
            poshuk1.krok = Convert.ToInt32(numericUpDown2.Value);
            int a = 0;           
            arr = new int[size];
            poshuk1.generetik();
            arr = poshuk1.return_elements();
            arr[0] = poshuk1.save = Convert.ToInt32(numericUpDown1.Value);
            textBox1.Text = "Eлементи арефметичної прогресії ";
            for (int i =0 ; i < size;i++)
            {
                a = arr[i];
                textBox1.Text +=   a.ToString() + "  ,";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(numericUpDown4.Value);//дає розмір масиву            
            Class_arifm search = new Class_arifm(size);
            int k = Convert.ToInt32(numericUpDown3.Value);
            search.krok = Convert.ToInt32(numericUpDown2.Value);//різниця прогресу
            int c;//пошук  елементів
            int b;//пошук 1 елемента
            if (numericUpDown3.Value == 1)
            {
           
                search.save = Convert.ToInt32(numericUpDown1.Value);//перший елемент масиву
                b = search.k_elem(k);
                MessageBox.Show(b.ToString());
            }//вивід елемента
             else
            {
                search.save = 0;             
                c = search.k_elem(k);
                MessageBox.Show(c.ToString());

            }//вивід елемента
        }

        
        
       
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(numericUpDown4.Value);
            Class_arifm search = new Class_arifm(size);
            search.save = Convert.ToInt32(numericUpDown1.Value);
            search.krok = Convert.ToInt32(numericUpDown2.Value);
            int result = search.sum(Convert.ToInt32(numericUpDown3.Value));
            MessageBox.Show(result.ToString());
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
        }
    }
    



}
