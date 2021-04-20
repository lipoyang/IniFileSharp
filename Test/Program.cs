using System;
using IniFileSharp;

namespace TestIniFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test IniFile");

            IniFile iniFile = new IniFile(@"TEST.INI");
            if (!iniFile.Exists())
            {
                Console.WriteLine("TEST.INI not found.");
                Console.WriteLine("create TEST.INI...");
                iniFile.Create();
            }

            // write integer
            int[] intVal = { 1234567, 0, -1234567 };
            iniFile.WriteInteger("SECT_INT", "KEY_A", intVal[0]);
            iniFile.WriteInteger("SECT_INT", "KEY_B", intVal[1]);
            iniFile.WriteInteger("SECT_INT", "KEY_C", intVal[2]);

            // write string
            string[] strVal = { "ABCDEFG", "John Smith", "徳川家康" };
            iniFile.WriteString("SECT_STR", "KEY_A", strVal[0]);
            iniFile.WriteString("SECT_STR", "KEY_B", strVal[1]);
            iniFile.WriteString("SECT_STR", "KEY_C", strVal[2]);

            // write boolean
            bool[] boolVal = { true, false };
            iniFile.WriteBoolean("SECT_STR", "KEY_A", boolVal[0]);
            iniFile.WriteBoolean("SECT_STR", "KEY_B", boolVal[1]);

            // write double
            double[] doubleVal = { 1234567890, 0.123456789, 0, -1.23 };
            iniFile.WriteString("SECT_STR", "KEY_A", strVal[0]);
            iniFile.WriteString("SECT_STR", "KEY_B", strVal[1]);
            iniFile.WriteString("SECT_STR", "KEY_C", strVal[2]);

            // read Integer
            int[] intVal2 = new int[4];
            intVal2[0] = iniFile.ReadInteger("SECT_INT", "KEY_A", -1);
            intVal2[1] = iniFile.ReadInteger("SECT_INT", "KEY_B", -1);
            intVal2[2] = iniFile.ReadInteger("SECT_INT", "KEY_C", -1);

            Console.Write("Read Integer ");
            Console.WriteLine(intVal2[0]);
            Console.WriteLine(intVal2[1]);
            Console.WriteLine(intVal2[2]);
        }
    }
}
