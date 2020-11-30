using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab3;

namespace lab3
{
    abstract class Class_Base
    {
        protected int[] arrey;       
        int _krok;
        int _saveFirstElem;
        protected Class_Base(int size)
        {
            arrey = new int[size];
        }
        
        public int save { get { return _saveFirstElem; } set { _saveFirstElem = value; } }
        public virtual int krok {get { return _krok ; } set {_krok = value; } }
        public int[] return_elements()
        {            
            return arrey;
        }
        public abstract int sum(int k); 
        public abstract int k_elem(int k);
        
    }

}
