using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fullnames = new string[0];
            string[] posts = new string[0];
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                PrintMenu(ref fullnames, ref posts, ref isWork);
            }

            Console.Write("Для продолжения нажмите любую кнопку...");
            Console.ReadKey();
        }

        static void PrintMenu(ref string[] fullnames, ref string[] posts, ref bool isWork)
        {
            const int CommandAddFile = 1;
            const int CommandAllFiles = 2;
            const int CommandDeleteFiles = 3;
            const int CommandSearchToSecondName = 4;
            const int CommandExit = 5;
            Console.WriteLine($"{CommandAddFile}. Добавить досье.");
            Console.WriteLine($"{CommandAllFiles}. Вывести все досье.");
            Console.WriteLine($"{CommandDeleteFiles}. Удалить досье.");
            Console.WriteLine($"{CommandSearchToSecondName}. Поиск по фамилии.");
            Console.WriteLine($"{CommandExit}. Выход.");
            Console.WriteLine();
            Console.Write("Введите команду: ");
            int command = Convert.ToInt32(Console.ReadLine());

            switch (command)
            {
                case CommandAddFile:
                    AddFile(ref fullnames, ref posts);
                    break;
                case CommandAllFiles:
                    PrintAllFiles(fullnames, posts);
                    break;
                case CommandDeleteFiles:
                    DeleteFile(ref fullnames, ref posts);
                    break;
                case CommandSearchToSecondName:
                    SearchToSecondName(fullnames, posts);
                    break;
                case CommandExit:
                    isWork = false;
                    break;
                default:
                    Console.WriteLine("Такой команды нет. Попробуйте заного.");
                    break;
            }

            Console.ReadKey();
        }

        static void AddFile(ref string[] fullnames, ref string[] posts)
        {
            Console.Clear();
            Console.Write("Введите ФИО: ");
            string newFullname = Console.ReadLine();
            newFullname = newFullname.Trim();

            if (newFullname.Split().Length!= 3)
            {
                Console.WriteLine("Неверно введено ФИО. Оно должно быть введено в формате ФАМИЛИЯ ИМЯ ОТЧЕСТВО");
            }
            else
            {
                Console.Write("Введите должность: ");
                string newPost = Console.ReadLine();
                newPost = newPost.Trim();

                IncreaseSizeArray(ref fullnames, fullnames.Length + 1);
                IncreaseSizeArray(ref posts, posts.Length + 1);

                fullnames[fullnames.Length - 1] = newFullname;
                posts[posts.Length - 1] = newPost;
            }
        }

        static void PrintAllFiles(string[] fullnames, string[] posts)
        {
            Console.Clear();

            if (fullnames.Length > 0)
            {
                for (int arrayIndex = 0; arrayIndex < fullnames.Length; arrayIndex++)
                {
                    Console.WriteLine($"{arrayIndex + 1}. {fullnames[arrayIndex]} - {posts[arrayIndex]}");
                }
            }
            else
            {
                Console.WriteLine("Пусто");
            }
        }

        static void DeleteFile(ref string[] fullnames, ref string[] posts)
        {
            if (fullnames.Length > 0)
            {
                const string CommandCancel = "Cancel";
                string command;
                int arrayLength = fullnames.Length;

                do
                {
                    Console.Clear();
                    Console.Write($"Введите номер досье, который хотите удалить (для отмены команды - {CommandCancel}): ");
                    command = Console.ReadLine();

                    if (command.ToLower() != CommandCancel.ToLower())
                    {
                        if (Convert.ToInt32(command) > fullnames.Length || Convert.ToInt32(command) <= 0)
                        {
                            Console.WriteLine("Введено неверное значение, попробуйте заного.");
                            Console.ReadKey();
                        }
                        else
                        {
                            for (int arrayIndex = Convert.ToInt32(command) - 1; arrayIndex < fullnames.Length - 1; arrayIndex++)
                            {
                                fullnames[arrayIndex] = fullnames[arrayIndex + 1];
                                posts[arrayIndex] = posts[arrayIndex + 1];
                            }

                            ReduceSizeArray(ref fullnames, fullnames.Length - 1);
                            ReduceSizeArray(ref posts, posts.Length - 1);
                            Console.WriteLine("Досье успешно удалено.");
                        }
                    }
                    else
                    {
                        break;
                    }

                } while (Convert.ToInt32(command) > arrayLength || Convert.ToInt32(command) <= 0);
            }
            else
            {
                Console.WriteLine("Данных нет");
            }
        }

        static void SearchToSecondName(string[] fullnames, string[] posts)
        {
            Console.Clear();
            Console.Write("Введите фамилию: ");
            string secondName = Console.ReadLine();
            bool haveInformation = false;
            secondName = secondName.Trim();

            for (int arrayIndex = 0; arrayIndex < fullnames.Length; arrayIndex++)
            {
                if (fullnames[arrayIndex].Split()[0] == secondName)
                {
                    Console.WriteLine($"{arrayIndex + 1}. {fullnames[arrayIndex]} - {posts[arrayIndex]}");
                    haveInformation = true;
                }
            }

            if (haveInformation == false)
            {
                Console.WriteLine("Ничего не найдено.");
            }
        }

        static void IncreaseSizeArray (ref string[] array, int newSize)
        {
            string[] arrayCopy = new string[newSize];

            for (int arrayIndex = 0; arrayIndex < array.Length; arrayIndex++)
            {
                arrayCopy[arrayIndex] = array[arrayIndex];
            }

            array = arrayCopy;
        }

        static void ReduceSizeArray(ref string[] array, int newSize)
        {
            string[] arrayCopy = new string[newSize];

            for (int arrayIndex = 0; arrayIndex < arrayCopy.Length; arrayIndex++)
            {
                arrayCopy[arrayIndex] = array[arrayIndex];
            }

            array = arrayCopy;
        }
    }
}