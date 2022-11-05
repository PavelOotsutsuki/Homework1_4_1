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

            string[] fullname = new string[0];
            string[] post = new string[0];
            bool isWork = true;

            while (isWork)
            {
                Console.Clear();
                PrintMenu(ref fullname, ref post, ref isWork);
            }

            Console.Write("Для продолжения нажмите любую кнопку...");
            Console.ReadKey();
        }

        static void PrintMenu(ref string[] fullname, ref string[] post, ref bool isWork)
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
                    AddFile(ref fullname, ref post);
                    break;
                case CommandAllFiles:
                    GetAllFiles(fullname, post);
                    break;
                case CommandDeleteFiles:
                    DeleteFile(ref fullname, ref post);
                    break;
                case CommandSearchToSecondName:
                    SearchToSecondName(fullname, post);
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

        static void AddFile(ref string[] fullname, ref string[] post)
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

                ChangeSizeArray(ref fullname, fullname.Length + 1);
                ChangeSizeArray(ref post, post.Length + 1);

                fullname[fullname.Length - 1] = newFullname;
                post[post.Length - 1] = newPost;
            }
        }

        static void GetAllFiles(string[] fullname, string[] post)
        {
            Console.Clear();

            if (fullname.Length > 0)
            {
                for (int arrayIndex = 0; arrayIndex < fullname.Length; arrayIndex++)
                {
                    Console.WriteLine($"{arrayIndex + 1}. {fullname[arrayIndex]} - {post[arrayIndex]}");
                }
            }
            else
            {
                Console.WriteLine("Пусто");
            }
        }

        static void DeleteFile(ref string[] fullname, ref string[] post)
        {
            if (fullname.Length > 0)
            {
                const string CommandCancel = "Cancel";
                Console.Clear();
                Console.Write($"Введите номер досье, который хотите удалить (для отмены команды - {CommandCancel}): ");
                string command = Console.ReadLine();

                if (command.ToLower() != CommandCancel.ToLower())
                {
                    if (Convert.ToInt32(command) > fullname.Length || Convert.ToInt32(command) <= 0)
                    {
                        Console.WriteLine("Введено неверное значение, попробуйте заного.");
                        Console.ReadKey();
                        DeleteFile(ref fullname, ref post);
                    }
                    else
                    {
                        for (int arrayIndex = Convert.ToInt32(command) - 1; arrayIndex < fullname.Length - 1; arrayIndex++)
                        {
                            fullname[arrayIndex] = fullname[arrayIndex + 1];
                            post[arrayIndex] = post[arrayIndex + 1];
                        }

                        ChangeSizeArray(ref fullname, fullname.Length - 1);
                        ChangeSizeArray(ref post, post.Length - 1);
                        Console.WriteLine("Досье успешно удалено.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Данных нет");
            }
        }

        static void SearchToSecondName(string[] fullname, string[] post)
        {
            Console.Clear();
            Console.Write("Введите фамилию: ");
            string secondName = Console.ReadLine();
            bool haveInformation = false;
            secondName = secondName.Trim();

            for (int arrayIndex = 0; arrayIndex < fullname.Length; arrayIndex++)
            {
                if (fullname[arrayIndex].Split()[0] == secondName)
                {
                    Console.WriteLine($"{arrayIndex + 1}. {fullname[arrayIndex]} - {post[arrayIndex]}");
                    haveInformation = true;
                }
            }

            if (haveInformation == false)
            {
                Console.WriteLine("Ничего не найдено.");
            }
        }

        static void ChangeSizeArray(ref string [] array, int newSize)
        {
            string[] arrayCopy = new string[newSize];
            int minLength;

            if (array.Length >= newSize)
            {
                minLength = newSize;
            }
            else
            {
                minLength = array.Length;
            }

            for (int arrayIndex = 0; arrayIndex < minLength; arrayIndex++)
            {
                arrayCopy[arrayIndex] = array[arrayIndex];
            }

            array = arrayCopy;
        }
    }
}