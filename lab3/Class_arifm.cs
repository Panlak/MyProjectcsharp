using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab3;

namespace lab3
{
    class Class_arifm : Class_Base
    {
        public Class_arifm(char size)
             : base(size)
        { }
        public override int krok { get => base.krok; set => base.krok = value; }

        int next(int prev, int step)
        {
            return prev + step;
        }
        public void generetik()
        {                       
            for (int i = 1; i < arrey.Length; i++)
            {
                
                arrey[i] = next(save,krok);
                save = next(save, krok);
            }           
            arrey[0] = save;
        }
        public override int k_elem(int k)
        {
            return save +krok*(k-1);            
        }
        public override int sum(int k)
        {
            return Convert.ToInt32((((Math.Pow(krok,2)* (k-1) / krok) *k)/2)+save);            
        }

    }
}
