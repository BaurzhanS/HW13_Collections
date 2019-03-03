using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex7();
        }
        public static void Ex1()
        {
            //Создать коллекцию List<int>.Вывести на экран позицию и значение элемента, 
            //являющегося вторым максимальным значением в коллекции.Вывести на экран сумму элементов на четных позициях.
            List<int> list = new List<int>();
            Random rnd = new Random();
            int sum = 0;
            for (int i = 0; i < 20; i++)
            {
                list.Add(rnd.Next(0, 100));
                Console.Write("{0} ", list[i]);
                if (i % 2 == 0)
                    sum += list[i];
            }
            Console.WriteLine("");

            var orderedList = list.OrderByDescending(l => l).ElementAtOrDefault(1);
            Console.WriteLine("Сумма элементов на четных позициях = {0}", sum);
            Console.WriteLine("Позиция и значение элемента, яв-ся вторым макс.значением в коллекции:" +
                " {0} и {1}", orderedList.ToString(), list.IndexOf(orderedList));
        }
        public static void Ex2()
        {
            //Удалить все нечетные элементы списка List<int>
            List<int> list = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                list.Add(rnd.Next(0, 20));
                Console.Write("{0} ", list[i]);
            }
            Console.WriteLine("");
            var tmp = list.Where(i => i % 2 == 0);
            foreach (var item in tmp)
            {
                Console.Write("{0} ", item);
            }
        }
        public static void Ex3()
        {
            //Дана коллекция типа List<double>. Вывести на экран элементы списка, значение которых 
            //больше среднего арифметического всех элементов коллекции.
            List<double> list = new List<double>();
            Random rnd = new Random();
            double sum = 0.0;
            for (int i = 0; i < 20; i++)
            {
                list.Add(rnd.NextDouble()*100);
                Console.Write("{0:0.00}  ", list[i]);
                sum += list[i];
            }
            double avg = sum / list.Count;
            Console.WriteLine("");
            Console.WriteLine(avg);
            foreach (var item in list)
            {
                if(item>avg)
                Console.Write("{0:0.00} ", item);
            }
        }
        public static void Ex4()
        {
            //Напечатать содержимое текстового файла t, выписывая литеры 
            //каждой его строки в обратном порядке.
            string file = @"1.txt";
            string str;
            using (StreamReader s = new StreamReader(file))
            {
                str = s.ReadToEnd();
                s.Close();
            }
            //Console.WriteLine(str);
            var tmp = str.ToCharArray().Reverse();
            foreach (char i in tmp)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
        public static void Ex5()
        {
            //Даны 2 строки s1 и s2. Из каждой можно читать по одному символу.
            //Выяснить, является ли строка s2 обратной s1.
            Console.Write("введите строку s1: ");
            string str1 = Console.ReadLine();
            Console.Write("введите строку s2: ");
            string str2 = Console.ReadLine();
            char[] arr = str2.ToCharArray();
            Array.Reverse(arr);
            string tmp = new string(arr);
            Console.WriteLine(tmp);
           Console.WriteLine("Является ли строка str2 обратной str1? {0}", str1 == tmp);
        }
        public static void Ex6()
        {
            //Дан текстовый файл. За один просмотр файла напечатать элементы
            //файла в следующем порядке: сначала все слова, начинающиеся на 
            //гласную букву, потом все слова, начинающиеся на согласную букву, 
            //сохраняя исходный порядок в каждой группе слов.
            string file = @"1.txt";
            string str;
            using (StreamReader s = new StreamReader(file))
            {
                str = s.ReadToEnd();
                s.Close();
            }
            //Console.WriteLine(str);
            string[] words = str.Split(' ');
            var wordsWithVowels=words.Where(w => IsVowel(w[0]));
            foreach (var word in wordsWithVowels)
            {
                Console.Write("{0} ",word);
            }
            Console.WriteLine("\n\n");
            var wordsWithConsonant = words.Where(w => !IsVowel(w[0]));
            foreach (var word in wordsWithConsonant)
            {
                Console.Write("{0} ", word);
            }
        }
        public static bool IsVowel(char ch)
        {
            return (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' ||
                ch == 'y')|| (ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U' ||
                ch == 'Y');
        }
        public static void Ex7()
        {
            //Дан файл, содержащий числа. За один просмотр файла напечатать элементы файла 
            //в следующем порядке: сначала все положительные числа, потом все отрицательные
            //числа, сохраняя исходный порядок в каждой группе чисел.
            Random rnd = new Random();
            string wFile = @"2.txt";
            using (StreamWriter sw = new StreamWriter(wFile))
            {
                for (int i = 0; i < 30; i++)
                {
                    sw.Write("{0} ",rnd.Next(-100, 100));
                }
                sw.Close();
            }
            string rFile= @"2.txt";
            string str;
            using (StreamReader sr = new StreamReader(rFile))
            {
                str=sr.ReadToEnd();
                sr.Close();
            }
            string[] arr = str.Split(' ');
            List<int> numbers = new List<int>();
            int out_ = 0;
            foreach (var num in arr)
            {
                int.TryParse(num, out out_);
                numbers.Add(out_);
            }
            
            var positive = numbers.Where(n => n >= 0);
            foreach (var num in positive)
            {
                Console.Write("{0} ",num);
            }
            Console.WriteLine();
            var negative = numbers.Where(n => n < 0);
            foreach (var num in negative)
            {
                Console.Write("{0} ", num);
            }
        }
    }
}
