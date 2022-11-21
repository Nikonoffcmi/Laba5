using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Laba5
{
    internal class Program
    {
        public static HandlerOne AddHandlerOne()
        {
            Console.WriteLine("Введите имя обработчика");
            var name = Console.ReadLine();
            Console.WriteLine("Введите минимальное значение помехи.");
            var min = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите максмальное значение помехи.");
            var max = int.Parse(Console.ReadLine());

            return new HandlerOne(name, min, max);
        }

        public static HandlerTwo AddHandlerTwo()
        {
            Console.WriteLine("Введите имя обработчика");
            var name = Console.ReadLine();
            Console.WriteLine("Введите коэффициент усреденеия.");
            var average = int.Parse(Console.ReadLine());

            return new HandlerTwo(name, average);
        }

        static void Main(string[] args)
        {
            string name;
            HandlerComposite handlerComposite = new HandlerComposite();
            HandlerOne handlerOne;
            HandlerTwo handlerTwo;
            var json = new JsonHandlers<HandlerComposite>("Handlers.json");
            Console.WriteLine("Создайте обработчики в порядке их вызова.\n");
            for (; ; )
            {
                try
                {
                    Console.WriteLine("\n1. Создать обработчик Тип 1 и добавить его в конец списка обработки.\n" +
                    "2. Создать обработчик Тип 2 и добавить его в конец списка обработки.\n" +
                    "3. Создать обработчик Тип 1 и добавить его после обрабочика с указанным именем.\n" +
                    "4. Создать обработчик Тип 2 и добавить его после обрабочика с указанным именем.\n" +
                    "5. Удалить обработчик с указанным именем.\n" +
                    "6. Обработать массив значений.\n" +
                    "7. Завершение работы.\n" +
                    "Выберите цифру действия\n");

                    var userChoice = int.Parse(Console.ReadLine());
                    switch (userChoice)
                    {
                        case 1:
                            handlerOne = AddHandlerOne();
                            handlerComposite.AddHandlerAtTheEnd(handlerOne);
                            break;

                        case 2:
                            handlerTwo = AddHandlerTwo();
                            handlerComposite.AddHandlerAtTheEnd(handlerTwo);
                            break;

                        case 3:
                            Console.WriteLine("Введите имя обработчика, после которого будет добавлен новый.");
                            name = Console.ReadLine();
                            handlerOne = AddHandlerOne();

                            handlerComposite.AddHandlerByName(handlerOne, name);
                            break;

                        case 4:
                            Console.WriteLine("Введите имя обработчика, после которого будет добавлен новый.");
                            name = Console.ReadLine();
                            handlerTwo = AddHandlerTwo();

                            handlerComposite.AddHandlerByName(handlerTwo, name);
                            break;

                        case 5:
                            Console.WriteLine("Введите имя обработчика, который надо удалить.");
                            name = Console.ReadLine();

                            handlerComposite.RemoveHandlerByName(name);
                            break;

                        case 6:
                            var text = File.ReadAllText("test.txt");
                            if (text.Length < 1)
                                throw new Exception("нет значений сигнала");

                            var numbers = new List<double>();
                            foreach (var line in text.Split(new char[] { ' ' }))
                            {
                                if (double.TryParse(line, out double number))
                                    numbers.Add(number);
                                else
                                    throw new ArgumentException("значение сигнала не является числом", line);
                            }


                            Console.WriteLine("Входные значения сигнала:" + text);
                            handlerComposite.RunProcessing(numbers);

                            string result = "";
                            foreach (var number in numbers)
                                result += number.ToString() + " ";

                            File.WriteAllText("test.txt", result.Remove(result.Length - 1));
                            Console.WriteLine("Выходные значения сигнала: " + result);
                            break;

                        case 7:
                            return;
                        case 8:
                            json.JsonSerialize(handlerComposite);
                            break;
                        case 9:
                            handlerComposite = json.JsonDeserialize();
                            break;
                        default:
                            Console.WriteLine("Неправильный номер!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }
    }
}
