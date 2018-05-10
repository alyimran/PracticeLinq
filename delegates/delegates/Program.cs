using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates
{

    delegate int NumberChanger(int n);

    class Program
    {

        static int num = 10;


        public static int addNum(int p)
        {
            num += p;
            return num;
        }

        public static int mulNum(int q)
        {
            num *= q;
            return q;
        }


        public static int getNum()
        {
            return num;
        }
        static void Main(string[] args)
        {
            NumberChanger mydelegate;
            NumberChanger addNumberChanger = new NumberChanger(addNum);
            NumberChanger mullNumberChanger = new NumberChanger(mulNum);

            mydelegate = addNumberChanger;
            mydelegate += mullNumberChanger;
            Console.WriteLine(getNum());
            mydelegate(5);

            Console.WriteLine(getNum());

            //mullNumberChanger(30);

            //Console.WriteLine(getNum());
            Console.ReadLine();

        }
    }
}
