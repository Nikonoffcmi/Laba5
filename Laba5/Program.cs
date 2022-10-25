using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //string name;
            //HandlerComposite handlerComposite = new HandlerComposite();
            //HandlerOne handlerOne;
            //HandlerTwo handlerTwo;
            //Console.WriteLine("Создайте обработчики в порядке их вызова.\n");
            //for (; ; )
            //{
            //    try
            //    {
            //        Console.WriteLine("\n1. Создать обработчик Тип 1 и добавить его в конец списка обработки.\n" +
            //        "2. Создать обработчик Тип 2 и добавить его в конец списка обработки.\n" +
            //        "3. Создать обработчик Тип 1 и добавить его после обрабочика с указанным именем.\n" +
            //        "4. Создать обработчик Тип 2 и добавить его после обрабочика с указанным именем.\n" +
            //        "5. Удалить обработчик с указанным именем.\n" +
            //        "6. Обработать массив значений.\n" +
            //        "7. Завершение работы.\n" +
            //        "Выберите цифру действия\n");

            //        var userChoice = int.Parse(Console.ReadLine());
            //        switch (userChoice)
            //        {
            //            case 1:
            //                handlerOne = AddHandlerOne();
            //                handlerComposite.AddHandlerAtTheEnd(handlerOne);
            //                break;
                    
            //            case 2:
            //                handlerTwo = AddHandlerTwo();
            //                handlerComposite.AddHandlerAtTheEnd(handlerTwo); 
            //                break;
                    
            //            case 3:
            //                Console.WriteLine("Введите имя обработчика, после которого будет добавлен новый.");
            //                name = Console.ReadLine();
            //                handlerOne = AddHandlerOne();

            //                if (handlerComposite.AddHandlerByName(handlerOne, name))
            //                    Console.WriteLine("Oбработчик добавлен");
            //                else
            //                    Console.WriteLine("Обработчика с таким именем нет");
            //                break;
                    
            //            case 4:
            //                Console.WriteLine("Введите имя обработчика, после которого будет добавлен новый.");
            //                name = Console.ReadLine();
            //                handlerTwo = AddHandlerTwo();

            //                if (handlerComposite.AddHandlerByName(handlerTwo, name))
            //                    Console.WriteLine("Oбработчик добавлен");
            //                else
            //                    Console.WriteLine("Обработчика с таким именем нет");
            //                break;
                    
            //            case 5:
            //                Console.WriteLine("Введите имя обработчика, который надо удалить.");
            //                name = Console.ReadLine();

            //                if (handlerComposite.RemoveHandlerByName(name))
            //                    Console.WriteLine("Oбработчик удален");
            //                else
            //                    Console.WriteLine("Обработчика с таким именем нет"); ;
            //                break;
                    
            //            case 6:
            //                var text = File.ReadAllText("test.txt");
            //                if (text.Length < 1)
            //                    throw new Exception("нет значений сигнала");
                            
            //                var numbers = new List<double>();
            //                foreach (var line in text.Split(new char[] { ' ' }))
            //                {
            //                    if (double.TryParse(line, out double number))
            //                        numbers.Add(number);
            //                    else
            //                        throw new ArgumentException("значение сигнала не является числом", line);
            //                }
                                
                            
            //                Console.WriteLine("Входные значения сигнала:" + text);
            //                handlerComposite.RunProcessing(numbers);

            //                string result = "";
            //                foreach (var number in numbers)
            //                    result += number.ToString() + " ";

            //                File.WriteAllText("test.txt", result.Remove(result.Length - 1));
            //                Console.WriteLine("Выходные значения сигнала:" + File.ReadAllText("test.txt"));
            //                break;
                    
            //            case 7:
            //                return;
            //            default:
            //                Console.WriteLine("Неправильный номер!");
            //                break;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }
                
            //}
        }
    }
}
