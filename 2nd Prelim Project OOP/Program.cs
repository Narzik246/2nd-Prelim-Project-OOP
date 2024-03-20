using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2nd_Prelim_Project_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Write();
            string file = "C:\\Users\\Krizan246\\Downloads\\The significance of culture.txt";   
            Console.WriteLine();
            EstimateFile(file);

            Console.ReadKey();
        }
        static void Write() 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello, I am your word counter.");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("Pleased to meet you.");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("Before we start, let me ask you first.");
            Console.WriteLine();
            Console.ReadKey();
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Are you ready?\n(Y/N)");
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Well whatever you said doesnt matter.\nPlease proceed.");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("Please enter your filepath.");
        }
        static string StreamRead(string file)
        {
            string readstring = "";
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    readstring += line;
                }
            }
            return (readstring);
        }
        public static void EstimateFile(string file)
        {
            Console.ForegroundColor = ConsoleColor.White;
            file = StreamRead(file);
            Console.WriteLine();
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Blue;
            if (WordCount(file) == 1)
                Console.Write($"There is {WordCount(file)} word and ");
            else
                Console.Write($"There are {WordCount(file)} words and ");
            if (SentenceCount(file) == 1)
                Console.WriteLine($"{SentenceCount(file)} sentence.");
            else
                Console.WriteLine($"{SentenceCount(file)} sentences.");
            Console.WriteLine();
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ok next is the word breakdown.");
            Console.WriteLine();
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Blue;
            WordBreakdown(file);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Check your downloads for this info.");
            StreamWrite(file);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any button to end analysis.");
            Console.ReadKey();
        }
        static int SentenceCount(string file)
        {
            int counter = 0;
            for (int x = 0; x < file.Length; x++)
            {
                if (file[x] == '.' || file[x] == '!' || file[x] == '?')
                    counter++;
                if (file[x] == '.' && file[x - 1] == '.')
                    counter--;
                if ((file[x] == '!' && file[x - 1] == '!') || (file[x] == '!' && file[x - 1] == '?'))
                    counter--;
                if ((file[x] == '?' && file[x - 1] == '?') || (file[x] == '?' && file[x - 1] == '!'))
                    counter--;
            }
            return counter;
        }
        static int WordCount(string file)
        {
            string[] words = file.Split(new[] { ' ', '.', ',', ';', '!', '?', '"', '/', '|', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int counter = words.Length;
            return counter;
        }
        public static void WordBreakdown(string file)
        {
            int total = 0;
            file = file.ToLower();
            string[] word = file.Split(' ', '\n', '?', '!', '.', ',','/','(',')','-','"');
            Array.Sort(word);
            int[] counter = new int[word.Length];
            for (int x = 0; x < word.Length; x++)
            {
                if (x == 0)
                {
                    if ((word[x] == "") || (word[x] == " "))
                        continue;
                    counter[x] = 0;
                    for (int y = 0; y < word.Length; y++)
                        if (word[x] == word[y])
                            counter[x]++;

                    if (counter[x] == 1)
                        Console.WriteLine($"There was {counter[x]} instance of '{word[x]}'.");
                    else
                        Console.WriteLine($"There were {counter[x]} instances of '{word[x]}'.");
                }
                else if (x > 0)
                {
                    if (word[x] == word[0])
                        continue;
                    if (word[x] != word[x - 1])
                    {
                        if ((word[x] == "") || (word[x] == " "))
                            continue;
                        counter[x] = 0;
                        for (int y = 0; y < word.Length; y++)
                            if (word[x] == word[y])
                                counter[x]++;

                        if (counter[x] == 1)
                            Console.WriteLine($"There was {counter[x]} instance of '{word[x]}'.");
                        else
                            Console.WriteLine($"There were {counter[x]} instances of '{word[x]}'.");
                    }
                }
            }
        }
        static void StreamWrite(string file)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Users\\Krizan246\\Downloads\\Analysis.txt"))
            {
                if (WordCount(file) == 1)
                    sw.Write($"There is {WordCount(file)} word and ");
                else
                    sw.Write($"There are {WordCount(file)} words and ");
                if (SentenceCount(file) == 1)
                    sw.WriteLine($"{SentenceCount(file)} sentence.");
                else
                    sw.WriteLine($"{SentenceCount(file)} sentences.");
                sw.WriteLine();
                int total = 0;
                file = file.ToLower();
                string[] word = file.Split(' ', '\n', '?', '!', '.', ',');
                Array.Sort(word);
                int[] counter = new int[word.Length];

                for (int x = 0; x < word.Length; x++)
                {
                    if (x == 0)
                    {
                        if ((word[x] == "") || (word[x] == " "))
                            continue;
                        counter[x] = 0;
                        for (int y = 0; y < word.Length; y++)
                            if (word[x] == word[y])
                                counter[x]++;
                        total += counter[x];
                        if (counter[x] == 1)
                            sw.WriteLine($"There was {counter[x]} instance of '{word[x]}'.");
                        else
                            sw.WriteLine($"There were {counter[x]} instances of '{word[x]}'.");
                    }
                    else if (x > 0)
                    {
                        if (word[x] == word[0])
                            continue;
                        if (word[x] != word[x - 1])
                        {
                            if ((word[x] == "") || (word[x] == " "))
                                continue;
                            counter[x] = 0;
                            for (int y = 0; y < word.Length; y++)
                                if (word[x] == word[y])
                                    counter[x]++;
                            total += counter[x];
                            if (counter[x] == 1)
                                sw.WriteLine($"There was {counter[x]} instance of '{word[x]}'.");
                            else
                                sw.WriteLine($"There were {counter[x]} instances of '{word[x]}'.");
                        }
                    }
                }

            }
        }
    }
}
