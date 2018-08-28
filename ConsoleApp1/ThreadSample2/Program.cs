using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSample2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("입력한 숫자까지의 솟수 갯수 출력: (종료: 'x' + Enter)");

            while(true)
            {
                Console.WriteLine("숫자를 입력하세요.");
                string inputNumber = Console.ReadLine();
                if (inputNumber.Equals("x", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.WriteLine("프로그램 종료");
                    break;
                }

                //CountPrimeNumbers(inputNumber);

                Thread t = new Thread(CountPrimeNumbers);
                t.IsBackground = true;
                t.Start(inputNumber);

                //t.Join();
            }
        }

        static void CountPrimeNumbers(object initialValue)
        {
            string value = (string)initialValue;
            int primeCandidate = 0;

            if (int.TryParse(value, out primeCandidate) == false)
            {
                return;
            }

            int totalPrimes = 0;

            for (int i = 2; i < primeCandidate; i++)
            {
                if (IsPrime(i) == true)
                {
                    totalPrimes++;
                }
            }

            Console.WriteLine("숫자 {0} 까지의 솟수 갯수: {1}", value, totalPrimes);
        }

        static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                return candidate == 2;
            }

            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                    return false;
            }

            return candidate != 1;
        }
    }
}
