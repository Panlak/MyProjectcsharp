using System;
using System.Messaging;
using lab_2_;

public class onedimensional 
{
    public int[] a;
    int n = 0;
    public int[] b;
    public onedimensional(int size)
    {
        Form1 p = new Form1();
        switch (p.domainUpDown1.SelectedIndex)
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

        n = size;
        a = new int[size];


    }

    public void inpt(int index, int size = 0, int size1 = 0)
    {
        Form1 p = new Form1();

        if (index == 1)
            a = p.addarey(1, a, size, size1);
        else if (index == 2)
            b = p.addarey(2, b, size, size1);

    }
    public static onedimensional operator +(onedimensional op1, onedimensional op2)
    {
        onedimensional tema = new onedimensional(op1.n);
        for (int i = 0; i < tema.n; i++)
        {
            tema.a[i] = op1.a[i] + op2.b[i];
        }
        return tema;
    }
    public string outp(int index)
    {
        Form1 p = new Form1();

        string s = " ";

        if (index == 1)
        {
            for (int i = 0; i < a.Length; i++)
            {

                s += a[i].ToString() + " ";

            }
        }
        else if (index == 2)
        {
            for (int i = 0; i < b.Length; i++)
            {

                s += b[i].ToString() + " ";

            }
        }
        return s;
    }
    public static onedimensional operator ++(onedimensional b)
    {
        onedimensional tema = new onedimensional(b.n);
        for (int i = 0; i < tema.n; i++)
        {
            b.b[i] = b.b[i] + 3;
        }
        return b;
    }
    
    public static bool operator !=(onedimensional a, onedimensional b)
    {
        onedimensional tema = new onedimensional(b.n);

        
        for (int i = 0; i < tema.a.Length; i++)
        {
            if(a.a[i] != b.b[i]) return true;

        }
        return false ;
    }
    public static bool operator ==(onedimensional a, onedimensional b)
    {

        onedimensional tema = new onedimensional(b.n);
        for (int i = 0; i < tema.a.Length; i++)
        {
            if (a.a[i] == b.b[i]) return false;
        }
        return true;



    }
    public static onedimensional operator *(onedimensional op1, int number )
    {
        onedimensional tema = new onedimensional(op1.n);
        for (int i = 0; i < tema.n; i++)
        {
             op1.a[i] = op1.a[i] * number;
        }
        return op1;
    }
}
