using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Uken_QA_Test_Part_1
{
    class Program
    {

        static SortedDictionary<int, int> m_entries = new SortedDictionary<int, int>();
        static int m_lowestKey;

        static void FindLowestOccurence()
        {
            //set it as the highest possible value
            m_lowestKey = int.MaxValue;
            int lowestValue = int.MaxValue;
            foreach (var entry in m_entries)
            {
                Console.Out.WriteLine(entry);
                
                if (entry.Value < lowestValue)
                {
                    m_lowestKey = entry.Key;
                    lowestValue = entry.Value;

                }
                else if (entry.Value == lowestValue && entry.Key < m_lowestKey)
                {
                    m_lowestKey = entry.Key;
                    lowestValue = entry.Value;
                }
            }
        }

        //supply the file as an argument
        //eg: uken_test.exe 
        static void Main(string[] args)
        {
            if (System.IO.File.Exists(args[0]))
            {
                //load the file as a stream
                //streams read until they reach a newline
                //since the file format is one int per line, this is suitable for our use case
                System.IO.StreamReader _file = new StreamReader(args[0]);
                while (_file.Peek() != -1) //stop when we reach EOF
                {
                    int key;
                    if (int.TryParse(_file.ReadLine(), out key))
                    {
                        if (m_entries.ContainsKey(key))
                        {
                            m_entries[key]++;
                        }
                        else
                        {
                            m_entries.Add(key, 1);
                        }
                        //Console.Out.WriteLine(key);
                    }
                }
                FindLowestOccurence();
                Console.Out.WriteLine(m_lowestKey);

            }
            else
            {
                Console.Out.WriteLine("Invalid file name " + args[0] + " is not a valid file");

            }

            Console.Out.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
        }
    }
}
