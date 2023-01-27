using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Test
{
    class Program
    {
        public void reverse()
        {
            Console.WriteLine("Array length:");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Array:");
            string[] arr = Console.ReadLine().Split(' ');
            int[] array = new int[length];
            for (int i = 0; i < arr.Length; i++)
            {
                array[i] = Convert.ToInt32(arr[i]);
            }
            int[] reverse = Enumerable.Reverse(array).ToArray();
            foreach (int element in reverse)
                {
                Console.Write(element + " ");
                }
            Console.WriteLine();
        }
        public void palindrome()
        {
            Console.WriteLine("Input string:");
            string text = Console.ReadLine();
            text = Regex.Replace(text, @"[^a-zA-Z]", "").ToLower();
            char[] temp = text.ToCharArray();
            int j = temp.Length-1;
            bool palindrome = true;
            for(int i = 0; i < temp.Length/2; i++)
            {
                if (temp[i] != temp[j])
                {
                    palindrome = false;
                    break;
                }
                j--;
            }
            if (palindrome)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
        public void permutation()
        {
            Console.WriteLine("First array:");
            string[] arr1 = Console.ReadLine().Split(' ');
            Console.WriteLine("Second array:");
            string[] arr2 = Console.ReadLine().Split(' ');
            int[] array1 = new int[11];
            int[] array2 = new int[11];
            for (int i = 0; i < 11; i++)
            {
                array1[i] = Convert.ToInt32(arr1[i]);
                array2[i] = Convert.ToInt32(arr2[i]);
            }
            bool allOfList1IsInList2 = !array1.Except(array2).Any();
            if (allOfList1IsInList2)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        public void powerOf2()
        {
            List<int> list = new List<int>();
            Console.WriteLine("One element per line, type \"stop\" to finish");
            bool check = false;
            int maxPower = 1;
            string input;
            while(true)
            {
                input = Console.ReadLine();
                if (!input.Equals("stop"))
                {
                  list.Add(Convert.ToInt32(input)); 
                }
                else
                {
                    break;
                }
                
            }
            foreach (int i in list)
            {
                if (isPowerOf2(i))
                {
                    if (i > maxPower)
                    {
                        maxPower = i; ;
                    }
                    check = true;
                }
            }
            if (check)
            {
                List<int> result = getList2(maxPower);
                foreach(int i in result)
                {
                    Console.Write(i+", ");
                }
                Console.Write(maxPower);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("NA");
            }


        }
        public bool isPowerOf2(int n)
        {
            while (n > 0)
            {
                if(n%2 == 1 && n!=1)
                {
                    return false;
                }
                n /= 2;
            }
            return true;
        }
        public List<int> getList2(int n)
        {
            List<int> list = new List<int>();
            for(int i=1; i<n; i *= 2)
            {
                list.Add(i);
            }
            return list;
        }
        public void findPrimes()
        {
            Console.WriteLine("Number of pairs:");
            int n = Convert.ToInt32(Console.ReadLine());
            int x = 0;
            int y = 0;
            int iterations = n;
            Stack<int> numbers = new Stack<int>();
            List<int> resList = new List<int>();
            while (n>0)
            {
                Console.WriteLine("Range:");
                string[] input = Console.ReadLine().Split(' ');
                x = Convert.ToInt32(input[0]);
                y = Convert.ToInt32(input[1]);
                numbers.Push(x);
                numbers.Push(y);
                n--;
            }
            while(iterations>0)
            {
                y = numbers.Pop();
                x = numbers.Pop();
                resList.Add(numberOfPrimes(x, y));
                iterations--;
            }
            for(int i=resList.Count-1; i >= 0; i--)
            {
                Console.WriteLine(resList[i]);
            }

        }
        public int numberOfPrimes(int x, int y)
        {
            int result = 0;
            for (int i = x; i < y + 1; i++)
            {
                if (isPrime(i) || i == 2)
                    result++;
            }
            return result;
        }
        public bool isPrime(int n)
        {
            if (n <= 1)
                return false;
            for (int i = 2; i < (n / 2 + 1); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void commonDigit()
        {
            Console.WriteLine("Length of array:");
            string n = Console.ReadLine();
            int[] numbers = new int[10];
            Console.WriteLine("Array:");
            string[] s = Console.ReadLine().Split(' ');
            string str = String.Concat(s);
            char[] chAr = str.ToCharArray();
            int index = 0;
            foreach(char c in chAr)
            {
                index = c - '0';
                numbers[index] += 1;
            }
            Console.WriteLine(findIndexOfMax(numbers));
        }
        public int findIndexOfMax(int [] array)
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= max)
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }
   
        public void digitSum()
        {
            Console.WriteLine("Length of array:");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Array:");
            string[] strings = Console.ReadLine().Split(' ');
            int [] inputAr = Array.ConvertAll(strings, s => int.Parse(s));
            int[] sums = new int[length];
            int sum = 0;
            int tmp = 0;
            for (int i = 0; i < length; i++)
            {
                sum = 0;
                tmp = inputAr[i];
                while (tmp != 0)
                {
                    sum += tmp % 10;
                    tmp /= 10;
                }
                sums[i] += sum;
            }
            int max = 0;
            int resIndex = 0;
            for (int i = 0; i < length; i++)
            {
                if (sums[i] == max)
                {
                    if (inputAr[i] > inputAr[resIndex])
                        resIndex = i;
                }
                if (sums[i] > max)
                {
                    max = sums[i];
                    resIndex = i;
                }
            }
            Console.WriteLine(resIndex);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("REVERSE");
            p.reverse();
            Console.WriteLine("PALINDROME");
            p.palindrome();
            Console.WriteLine("PERMUTATION");
            p.permutation();
            Console.WriteLine("POWER OF 2");
            p.powerOf2();
            Console.WriteLine("PRIMES IN RANGE");
            p.findPrimes();
            Console.WriteLine("MOST COMMON DIGIT");
            p.commonDigit();
            Console.WriteLine("FINDING DIGIT SUM");
            p.digitSum();
            Console.ReadLine();
        }
    }
}
