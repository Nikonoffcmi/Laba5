using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Laba5
{
    public class HandlerComposite
    {
        private List<Handler> handlers;

        public HandlerComposite() { handlers = new List<Handler>(); }

        public void RunProcessing(List<double> numbers)
        {
            foreach (var handler in handlers)
                handler.RunProcessing(numbers);
        }

        public void AddHandlerAtTheEnd(Handler handler)
        {
            if (handler is null)
                throw new ArgumentNullException(nameof(handler));

            if (NameAbsent(handler.Name))
                handlers.Add(handler);
            else
                throw new ArgumentException("Обработчик с таким именем уже существует.\n", handler.Name);
        }

        public void AddHandlerByName(Handler handler, string Name)
        {
            if (handler is null)
                throw new ArgumentNullException(nameof(handler));

            if (!NameAbsent(handler.Name))
                throw new ArgumentException("Обработчик с таким именем уже существует.\n", handler.Name);

            for (int i = 0; i < handlers.Count; i++)
            {
                if (handlers[i].Name == Name)
                {
                    handlers.Insert(i + 1, handler);
                    return;
                }
            }
            throw new ArgumentException("Обработчик с таким именем не существует.\n", Name);
        }

        public void RemoveHandlerByName(string name)
        {
            for (int i = 0; i < handlers.Count; i++)
            {
                if (handlers[i].Name == name)
                {
                    handlers.RemoveAt(i);
                    return;
                }
            }
            throw new ArgumentException("Обработчик с таким именем не существует.\n", name);
        }

        public bool NameAbsent(string name)
        {
            foreach (var handler in handlers)
                if (handler.Name == name)
                    return false;
            return true;
        }

        public List<string> GetNames()
        {
            return handlers
                .Select(name => name.Name)
                .ToList();
        }

        public List<HandlerOne> GetHandlerOne()
        {
            return handlers
                .Where(h => h.GetType() == typeof(HandlerOne))
                .Select(h => (HandlerOne)h)
                .ToList();
        }

        public List<HandlerTwo> GetHandlerTwo()
        {
            return handlers
                .Where(h => h.GetType() == typeof(HandlerTwo))
                .Select(h => (HandlerTwo)h)
                .ToList();
        }
    }
}
