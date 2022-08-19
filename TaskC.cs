using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolShopTask
{
    class TaskC
    {
        static void Main(string[] args)
        {

            try
            {
                string filePath = args[0];
                List<string> fileContents = System.IO.File.ReadLines(filePath).ToList();
                List<string[]> splitedFileContents = fileContents.Select(x => x.Replace(";", "").Split(',')).ToList();
                int index = -1;
                bool isParsed = int.TryParse(args[1], out index);
                if (!isParsed || index == -1 || index >= splitedFileContents[0].Length)
                {
                    throw new Exception("Invalid Index");
                }
                string searchKey = args[2];
                int foundIndex = splitedFileContents.FindIndex(x => x[index].ToLower() == searchKey.ToLower());
                if (foundIndex > -1)
                {
                    Console.WriteLine(fileContents[foundIndex]);
                }
                else
                {
                    throw new Exception("Not Found");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally {
                Console.ReadKey();
            }
          
        }
    }
}
