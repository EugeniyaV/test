using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace line
{
    class Program
    {
        static void Main(string[] args)
        {   //имя файла
            string inFile = "in.txt";
            string outFile = "out.txt";

            //строка в которой будет текста с файла
            string[] s = new string[intReadFile(inFile)+1];
            //чтение из файла
            ReadFile(inFile, s);
            //перемення для подсчета длины новой строки которая будет записываться в 
            //строку шириной N
            int l = 0;
            //ширина строки, взята с первой строки файла
            int N = int.Parse(s[0]);
            //новая строка в которой определены переносы на следующую строку 
            string xstr = null;
            //символы по которым будут разделяться строки
            char[] ch = new char[] { ' ' };
            char[] ch1 = new char[] { '\n' };
            //массив слов прочитаной строки из файла 
            string[] nStr = s[1].Split(ch,StringSplitOptions.RemoveEmptyEntries);
            //индекс по которому буду записываться v-е слова считаной строки из файла     
            int v = 0;
            //цикл в котором слова разбиваются по строкам. Цикл работает пока мы не записали все слова
            while(v != nStr.Length)
            {   //если после записи слова длина строки не превышается, то добавляем это слово к строке
                if (l + nStr[v].Length <= N)
                {
                    xstr += nStr[v];
                    l += nStr[v].Length;
                    v++;
                }
                //если строка менше длины вписываем пробел
                if (l < N)
                {
                    xstr += " ";
                    l++;
                }
                //если длины строки равна возможной то записываем знак переноса на следующую
                if (l == N)
                {
                    xstr += "\n";
                   
                    l = 0;
                }
            }       
            //массив строк, в которых слова записаны в возможном колиичестве на одну строку
            string[] p = xstr.Split(ch1,StringSplitOptions.RemoveEmptyEntries);
            //массив строк в котором слова будут выровяны по ширине
            string[] newStr = new string [p.Length];
            //цикл по строкам, в которых слова записаны в возможном колиичестве на одну строку
            for (int i = 0; i < p.Length; i++)
            {
                //будем каждую строку разбивать на слова
                string[] spl = p[i].Split(ch,StringSplitOptions.RemoveEmptyEntries);
                //узнаем количество слов
                int m = spl.Length;
                //количество пробелов в конце строки
                int k = 0;
                //определяем конец строки
                int g = p[i].Length-1;

                //ищем количество пробелов в конце
                while (p[i][g] == ' ')
                {
                    k++;
                    g--;
                }
                //количество пробелов, которое нужно добавить между каждым словом
                int a = 0;
                //количество пробелов которые осталось расставить между словами,
                //но оно менше чем количество слов минус 1
                int b = 0;
                //если в конце были пробелы и слово в строке не одно, то находим
                //количество пробелов, которое нужно добавить между каждым словом 
                //и количество пробелов которые осталось расставить между словами,
                //но оно менше чем количество слов минус 1
                if (k != 0 && m != 1)
                {
                     a = k / (m - 1);
                     b = k % (m - 1);
                }
                //цикл в котором будем записывать новую строку расстянутую по ширине    
                for (int j = 0; j < m; j++)
                    {
                        //записывем слово
                        newStr[i] += spl[j];
                        //если длина строки позволяет добавляем один пробел
                        if(newStr[i].Length != N)
                            newStr[i] += " ";
                        //счетчик, что бы знать сколько пробелов (которых нужно вставить 
                        //одинаковое количество между каждым словом) мы вставили 
                        int h = 0;
                        //цикл в котором записывае пробелы
                        while (h != a)
                        {
                            newStr[i] += " ";
                            h++;
                        }
                        //записываем пробел если ещё остались (является не обязательным для каждого промежутка)
                        if (b != 0)
                        {
                            newStr[i] += " ";
                            b--;
                        }
                    }
                    //записываем перенос на новую строку
                    newStr[i] += "\n";
                
            }
                    //записываем массив строк в файл            
                    WriteFile(outFile, newStr);
        }

        static void WriteFile(string filename, string[] str)
        {
            using (StreamWriter writer = File.CreateText(filename))
            {
                
                for(int i = 0; i < str.Length; i++)
                {
                    
                        writer.WriteLine(str[i]);
                }
            }          
        }

        static void ReadFile(string filename, string[] str)
        {
            using (StreamReader reader = File.OpenText(filename))
            {
                string line = null;
                int i = 0;
                do
                {
                   line = reader.ReadLine();
                   str[i] = line;
                   i++;
                }
                while(line != null);
            }
        }

        static int intReadFile(string filename)
        {
            int i = 0;
            using (StreamReader reader = File.OpenText(filename))
            {
                string line = null;
                do
                {
                    line = reader.ReadLine();
                    i++;
                }
                while (line != null);
            }
            return i;
        }
    }
}
