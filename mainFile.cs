using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace search_string
{
    public class MainFile
    {
        static void Main()
        {
            string fileName = "list.txt";
            Console.WriteLine("Выберите режим (" +
                "1 - Добавить в файл, " +
                "2 - Просмотр файла, " +
                "3 - Поиск строки):");
            int choice = int.Parse(Console.ReadLine());

            if (!File.Exists(fileName))
            {
                // Файл не существует, создаем его
                using (StreamWriter writer = File.CreateText(fileName))
                {
                    writer.WriteLine("Пример текста в файле.");
                    writer.WriteLine("Другая строка.");
                }

                Console.WriteLine($"Файл {fileName} успешно создан.");
            }
            else
            {
                Console.WriteLine($"Файл {fileName} уже существует.");
            }

            switch (choice)
            {
                case 1:
                    // Режим добавления данных в файл
                    Console.WriteLine("Введите данные для добавления в файл:");
                    string dataToAdd = Console.ReadLine();

                    // Запись данных в файл
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                        writer.WriteLine(dataToAdd);
                    }

                    Console.WriteLine("Данные успешно добавлены в файл.");
                    break;

                case 2:
                    // Режим просмотра содержимого файла
                    if (File.Exists(fileName))
                    {
                        // Чтение содержимого файла
                        using (StreamReader reader = new StreamReader(fileName))
                        {
                            string content = reader.ReadToEnd();
                            Console.WriteLine($"Содержимое файла {fileName}:");
                            Console.WriteLine(content);
                        }
                    }
                    break;

                case 3:
                    // Режим поиска строки в файле
                    Console.WriteLine("Введите данные для поиска:");
                    string searchString = Console.ReadLine();
                    if (SearchStringInFile(fileName, searchString))
                    {
                        Console.WriteLine($"Строка '{searchString}' найдена в файле {fileName}.");
                    }
                    else
                    {
                        Console.WriteLine($"Строка '{searchString}' не найдена в файле {fileName}.");
                    }
                    break;

                default:
                    Console.WriteLine("Неверный выбор режима.");
                    break;
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
