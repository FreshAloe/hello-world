using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerSample1
{
    class IntegerText
    {
        char[] txtNumber;

        public IntegerText(int number)
        {
            txtNumber = number.ToString().ToCharArray();
        }

        //인덱서
        public char this[int index]
        {
            get
            {
                return txtNumber[txtNumber.Length - index - 1];
            }
            set
            {
                txtNumber[txtNumber.Length - index - 1] = value;
            }
        }

        public override string ToString()
        {
            return new string(txtNumber);
        }

        public int ToInt32()
        {
            return Int32.Parse(ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IntegerText aInt = new IntegerText(123456);

            int step = 1;
            for(int i = 0; i < aInt.ToString().Length; i++)
            {
                Console.WriteLine(step + "의 자릿수: " + aInt[i]);
                step *= 10;
            }

            aInt[3] = '5';
            Console.WriteLine(aInt.ToInt32());
        }
    }
}
