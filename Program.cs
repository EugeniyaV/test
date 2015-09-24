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
            
            int N = int.Parse(s[0]);
            WriteFile(outFile, s[1]);
        }

        static void WriteFile(string filename, string str)
        {
            using (StreamWriter writer = File.CreateText(filename))
            {
                string[] nStr = str.Split(' ');
                for(int i = 0; i < nStr.Length; i++)
                {
                    writer.WriteLine(nStr[i]);
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
