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
        {
            string inFile = "in.txt";
            string outFile = "out.txt";

            string[] s = new string[intReadFile(inFile)+1];
            ReadFile(inFile, s);
            int l = 0;
            int N = int.Parse(s[0]);
            string xstr = null;
            string[] nStr = s[1].Split(' ');
            for (int i = 0; i < nStr.Length; i++)
            {
                if (l + nStr[i].Length + 1 < N)
                {
                    xstr += nStr[i]+ " ";
                    l += nStr[i].Length; 
                }
                else
                    if (l + nStr[i].Length == N)
                    {
                        xstr += nStr[i] + "\n";
                        l = 0;
                    }
                    else
                    {
                        xstr += "\n" + nStr[i]+ " ";
                        l = 0;
                    }
            }

            WriteFile(outFile, xstr);
        }

        static void WriteFile(string filename, string str)
        {
            using (StreamWriter writer = File.CreateText(filename))
            {
                
                for(int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '\n')
                        writer.WriteLine();
                    else
                        writer.Write(str[i]);
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
