using System;
using System.IO;
using IniFileSharp;

namespace TestIniFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test IniFile\n");

            if (!Test1()) goto ERROR;
            if (!Test2()) goto ERROR;
            if (!Test3()) goto ERROR;
            if (!Test4()) goto ERROR;
            if (!Test5()) goto ERROR;
            if (!Test6()) goto ERROR;

            Console.WriteLine("\nAll Test clear!");
            return;

        ERROR:
            Console.WriteLine("\nTest aborted!");
        }

        // Test1
        static private bool Test1()
        {
            Console.WriteLine("\nTest1: IniFile(), Exists(), Create()\n");

            string[] filenames = {
                "FILE1.INI", // file name only
                @"DIR2\FILE2.INI", // relative path
                Directory.GetCurrentDirectory() + @"\FILE3.INI" // absolute path
            };
            dir_delete("DIR2");

            foreach (var filename in filenames)
            {
                file_delete(filename);
                IniFile iniFile = new IniFile(filename);
                if (!iniFile.Exists())
                {
                    Console.WriteLine(filename + " not exist now.");
                    iniFile.Create();
                }
                else
                {
                    Console.WriteLine("UNEXPECTED ERROR!!!");
                    return false;
                }
                if (iniFile.Exists())
                {
                    Console.WriteLine(filename + " created now.");
                }
                else
                {
                    Console.WriteLine("ERROR: " + filename + " not created!");
                    return false;
                }
            }
            {
                file_delete("SETTING.INI");
                IniFile iniFile = new IniFile(); // no parameter
                if (!iniFile.Exists())
                {
                    Console.WriteLine("SETTING.INI not exist now.");
                    iniFile.Create();
                }
                else
                {
                    Console.WriteLine("UNEXPECTED ERROR!!!");
                    return false;
                }
                if (iniFile.Exists())
                {
                    Console.WriteLine("SETTING.INI created now.");
                }
                else
                {
                    Console.WriteLine("ERROR: SETTING.INI not created!");
                    return false;
                }
            }
            return true;
        }

        // Test2
        static private bool Test2()
        {
            Console.WriteLine("\nTest2: WriteInteger(), ReadInteger()\n");

            File.Delete("TEST.INI");

            IniFile iniFile = new IniFile("TEST.INI");

            // no need
        #if false
            if (!iniFile.Exists())
            {
                iniFile.Create();
            }
        #endif

            // write
            int[] Val1 = { 1234567, 0, -1234567 };
            iniFile.WriteInteger("SECT_INT", "KEY_A", Val1[0]);
            iniFile.WriteInteger("SECT_INT", "KEY_B", Val1[1]);
            iniFile.WriteInteger("SECT_INT", "KEY_C", Val1[2]);

            // read
            int[] Val2 = new int[3];
            Val2[0] = iniFile.ReadInteger("SECT_INT", "KEY_A", -1);
            Val2[1] = iniFile.ReadInteger("SECT_INT", "KEY_B", -1);
            Val2[2] = iniFile.ReadInteger("SECT_INT", "KEY_C", -1);

            for (int i = 0; i < Val1.Length; i++)
            {
                Console.WriteLine("Write " + Val1[i].ToString());
                Console.WriteLine("Read  " + Val2[i].ToString());
                if(Val1[i] != Val2[i])
                {
                    Console.WriteLine("ERROR: not matched!");
                    return false;
                }
            }
            Console.WriteLine("OK!");

            return true;
        }

        // Test3
        static private bool Test3()
        {
            Console.WriteLine("\nTest3: WriteString(), ReadString()\n");

            IniFile iniFile = new IniFile("TEST.INI");

            // write
            string[] Val1 = { "ABCDEFG", "John Smith", "徳川家康" };
            iniFile.WriteString("SECT_STR", "KEY_A", Val1[0]);
            iniFile.WriteString("SECT_STR", "KEY_B", Val1[1]);
            iniFile.WriteString("SECT_STR", "KEY_C", Val1[2]);

            // read
            string[] Val2 = new string[3];
            Val2[0] = iniFile.ReadString("SECT_STR", "KEY_A", "NG");
            Val2[1] = iniFile.ReadString("SECT_STR", "KEY_B", "NG");
            Val2[2] = iniFile.ReadString("SECT_STR", "KEY_C", "NG");

            for (int i = 0; i < Val1.Length; i++)
            {
                Console.WriteLine("Write " + Val1[i]);
                Console.WriteLine("Read  " + Val2[i]);
                if (Val1[i] != Val2[i])
                {
                    Console.WriteLine("ERROR: not matched!");
                    return false;
                }
            }
            Console.WriteLine("OK!");
            return true;
        }

        // Test4
        static private bool Test4()
        {
            Console.WriteLine("\nTest4: WriteBoolean(), ReadBoolean()\n");

            IniFile iniFile = new IniFile("TEST.INI");

            // write
            bool[] Val1 = { true, false };
            iniFile.WriteBoolean("SECT_BOOL", "KEY_A", Val1[0]);
            iniFile.WriteBoolean("SECT_BOOL", "KEY_B", Val1[1]);

            // read
            bool[] Val2 = new bool[2];
            Val2[0] = iniFile.ReadBoolean("SECT_BOOL", "KEY_A", false);
            Val2[1] = iniFile.ReadBoolean("SECT_BOOL", "KEY_B", true);

            for (int i = 0; i < Val1.Length; i++)
            {
                Console.WriteLine("Write " + Val1[i].ToString());
                Console.WriteLine("Read  " + Val2[i].ToString());
                if (Val1[i] != Val2[i])
                {
                    Console.WriteLine("ERROR: not matched!");
                    return false;
                }
            }
            Console.WriteLine("OK!");
            return true;
        }

        // Test5
        static private bool Test5()
        {
            Console.WriteLine("\nTest5: WriteDouble(), ReadDouble()\n");

            IniFile iniFile = new IniFile("TEST.INI");

            // write
            double[] Val1 = { 1234567890, 0.123456789, 0, -1.23 };
            iniFile.WriteDouble("SECT_DOUBLE", "KEY_A", Val1[0]);
            iniFile.WriteDouble("SECT_DOUBLE", "KEY_B", Val1[1]);
            iniFile.WriteDouble("SECT_DOUBLE", "KEY_C", Val1[2]);
            iniFile.WriteDouble("SECT_DOUBLE", "KEY_D", Val1[3]);

            // read
            double[] Val2 = new double[4];
            Val2[0] = iniFile.ReadDouble("SECT_DOUBLE", "KEY_A", -1);
            Val2[1] = iniFile.ReadDouble("SECT_DOUBLE", "KEY_B", -1);
            Val2[2] = iniFile.ReadDouble("SECT_DOUBLE", "KEY_C", -1);
            Val2[3] = iniFile.ReadDouble("SECT_DOUBLE", "KEY_D", -1);

            for (int i = 0; i < Val1.Length; i++)
            {
                Console.WriteLine("Write " + Val1[i].ToString());
                Console.WriteLine("Read  " + Val2[i].ToString());
                if (Val1[i] != Val2[i])
                {
                    Console.WriteLine("ERROR: not matched!");
                    return false;
                }
            }
            Console.WriteLine("OK!");
            return true;
        }

        // Test6
        static private bool Test6()
        {
            Console.WriteLine("\nTest6: WriteDecimal(), ReadDecimal()\n");

            IniFile iniFile = new IniFile("TEST.INI");

            // write
            decimal[] Val1 = { 1234567890, 0.123456789M, 0, -1.23M };
            iniFile.WriteDecimal("SECT_DECIMAL", "KEY_A", Val1[0]);
            iniFile.WriteDecimal("SECT_DECIMAL", "KEY_B", Val1[1]);
            iniFile.WriteDecimal("SECT_DECIMAL", "KEY_C", Val1[2]);
            iniFile.WriteDecimal("SECT_DECIMAL", "KEY_D", Val1[3]);

            // read
            decimal[] Val2 = new decimal[4];
            Val2[0] = iniFile.ReadDecimal("SECT_DECIMAL", "KEY_A", -1);
            Val2[1] = iniFile.ReadDecimal("SECT_DECIMAL", "KEY_B", -1);
            Val2[2] = iniFile.ReadDecimal("SECT_DECIMAL", "KEY_C", -1);
            Val2[3] = iniFile.ReadDecimal("SECT_DECIMAL", "KEY_D", -1);

            for (int i = 0; i < Val1.Length; i++)
            {
                Console.WriteLine("Write " + Val1[i].ToString());
                Console.WriteLine("Read  " + Val2[i].ToString());
                if (Val1[i] != Val2[i])
                {
                    Console.WriteLine("ERROR: not matched!");
                    return false;
                }
            }
            Console.WriteLine("OK!");
            return true;
        }

        // delete directory
        static private void dir_delete(string dir)
        {
            try
            {
                Directory.Delete(dir);
            }
            catch
            {
                ;
            }
        }

        // delete file
        static private void file_delete(string filename)
        {
            try
            {
                File.Delete(filename);
            }
            catch
            {
                ;
            }
        }
    }
}
