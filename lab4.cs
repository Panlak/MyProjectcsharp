using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_
{
    public partial class Form1 : Form
    {
        String text = "Найбільше й найдорожче добро в кожного народу - це його мова, ота жива схованка людського духу, його багата скарбниця, у яку народ складає і своє давнє життя, і свої сподіванки, розум, досвід, почування." +
        "Навчаючись з малих літ балакати, ми разом з тими словами, що доводиться їх запамятати, набуваємо й розуміння того, що ті слова визначають, чи назву якої речі, чи думку про що-небудь. Тобто ми разом зі словами набираємося й розуму, набуваємо чужих думок, навчаємося самі думати й ті думки викладати словами." +
        "діти у свою чергу додають до здобутого від нас скарбу мови своїх вимовів того, що їм за свого життя довелося навчитися, пере­думати, пережити. Таким побитом і складається людська мова, що з кожним новим коліном все більше та більше шириться-зростає.";
        string[] arrey;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            char[] sep = { ' ', ',', '!', '.', ':', '?' };
            arrey = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            foreach (string slova in arrey)
            { listBox1.Items.Add(slova); listBox2.Items.Add(slova); }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (listBox1.SelectedIndex > -1)
            {
                string s = listBox1.SelectedItem.ToString();
                MessageBox.Show("Вибрані слова задом наперед" + "\n" + string.Concat(s.Reverse()),
                    "Реверс слів");
            }
            else if (listBox1.SelectedIndex < 0) errorProvider1.SetError(button1, "Ви нічого не вибрали");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            
            /* Regex regex = new Regex(@"\w*ти$*"); // Робоча спроба пошуку слів які закінчуються на 'ти' (Regex)
             string task = " ";
             int count = 0;
             string reserv = " ";           
             foreach (string slova1 in listBox2.SelectedItems)
             {
                 reserv += slova1 + " ";
             }
             if (listBox2.SelectedIndex > -1)
             {                                   
                     MatchCollection matches = regex.Matches(reserv);
                     foreach (Match match in matches)
                     {
                         task += match.Value + " ";
                         count++;

                     }
                 MessageBox.Show(task + ".",
                           "Кілість слів які закінчуються на 'ти' : " + count.ToString());

             }
             else if (listBox2.SelectedIndex < 0) errorProvider1.SetError(button3, "Ви нічого не вибрали");
             */

            string s = "ти";
            string reserv = "";
            foreach (string slova in arrey)
                if (slova.EndsWith(s))
                    reserv += slova + "\n";
            MessageBox.Show(reserv, "Пошук слів які закінчуються на 'ти'");

        }


        private void button2_Click(object sender, EventArgs e)
        {
           
            /*  Regex consonants = new Regex(@"[м,р,с,М,Р,С]"); // робоча спроба спроба через Regex Пошуку літер
              Regex vowels = new Regex(@"[(ї,а,Ї,А]");
              if(radioButton2.Checked)
              print(consonants, 1);//приголосні
              if (radioButton1.Checked)
              print(vowels, 2);//голосні
              */
            char[] consonants = { 'м', 'р', 'с', 'М', 'Р', 'С', };
            char[] vowels = { 'ї', 'а', 'Ї', 'А' };
            if (radioButton1.Checked) print1(vowels,1);
            if (radioButton2.Checked) print1(consonants,2);
        }
        public void print1(char[] one, int indexforprint)
        {
            int index = -1;
            int count = 0;
            while ((index = textBox1.Text.IndexOfAny(one, index+1)) != -1) { count++; }
            if (indexforprint == 1) MessageBox.Show("Кількість голосних  = " + count.ToString());
            if (indexforprint == 2) MessageBox.Show("Кількість приголосних  = " + count.ToString());
        }
       /* public void print1(char[] one, int index = 0)// Пошук Вказаних літер в тексті
        {
            if (index == 1) { string[] arrey = textBox1.Text.Split(one); MessageBox.Show("Кількість голосних = " + (arrey.Length - 1)); }
            if (index == 2) { string[] arrey = textBox1.Text.Split(one); MessageBox.Show("Кількість приголосних = " + (arrey.Length - 1)); }
        }
        /*  public void print(Regex one, int index=0) // робоча спроба спроба через Regex (метод) Пошуку літер
          {
              char[] sep = { ' ', ',', '!', '.', ':', '?' };
              int count = 0;
              string[] arrey = textBox1.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);            
                  foreach (string slova1 in arrey)
                  {
                      MatchCollection math = one.Matches(slova1);
                      count += math.Count;
                  }
                  if(index == 1)
                  MessageBox.Show("Приголосних букв: 'м', 'р', 'с' = " + count.ToString());
                  if (index == 2)
                  MessageBox.Show("голосних букв 'ї', 'а' = " + count.ToString());

          } */
        private void button4_Click(object sender, EventArgs e)
        {
            string input = "hello world swi1f gg a^ swi1f gg n^ swi1f gg aaaaa^ swi1f gg nnnnn^ swi1lf gg nn^";
            string reserv = "";
            Regex regex = new Regex(@"swi.(l?f g+) [an]{1,5}\^");
            MatchCollection mtcl = regex.Matches(input);
            Match math = regex.Match(input);
            foreach (Match mc in mtcl)
                reserv += mc.Value.ToString() + "\n";
            MessageBox.Show(reserv + "\n", "Результат роботи MatchCollection ");
            Console.WriteLine();
            if (math.Success)
            {
                MessageBox.Show(math.Value.ToString() + "\n", "Результат роботи Match ");
            }
        }
    }

}
