using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace search_string
{
    public class mainFile
    {
        static void Main()
        {
            string fileName = "example.txt";
            string content = "Это текст, который будет записан в файл.";

            // Создание и запись в файл с использованием using
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(content);
                Console.WriteLine($"Файл {fileName} успешно создан и заполнен.");
            }

            // Чтение файла:
            if (File.Exists(fileName))
            {
                // Чтение содержимого файла
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string content2 = reader.ReadToEnd();
                    Console.WriteLine($"Содержимое файла {fileName}:");
                    Console.WriteLine(content2);
                }
            }
            else
            {
                Console.WriteLine($"Файл {fileName} не существует.");
            }

            // Добавление функции поиска строки в файле
            string searchString = "текст, который";
            if (SearchStringInFile(fileName, searchString))
            {
                Console.WriteLine($"Строка '{searchString}' найдена в файле {fileName}.");
            }
            else
            {
                Console.WriteLine($"Строка '{searchString}' не найдена в файле {fileName}.");
            }
        }

        static bool SearchStringInFile(string fileName, string searchString)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(searchString))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
