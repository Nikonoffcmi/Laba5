using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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
            {
                throw new ArgumentNullException(nameof(handler));
            }

            handlers.Add(handler);
        }

        public void AddHandlerByName(Handler handler, string strName)
        {
            if (handler is null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            for (int i = 0; i < handlers.Count; i++)
            {
                if (handlers[i].Name == strName)
                {
                    handlers.Insert(i + 1, handler);
                    break;
                }
            }
        }

        public void RemoveHandlerByName<T>(T handler, string strName)
            where T : class
        {
            for (int i = 0; i < handlers.Count; i++)
            {
                if (handlers[i].Name == strName && handlers[i].GetType() == handler.GetType())
                {
                    handlers.RemoveAt(i);
                    break;
                }
            }
        }

        public List<string> GetNames()
        {
            return handlers.Select(name => name.Name).ToList();
        }

        public List<HandlerOne> GethandlerOne()
        {
            return handlers.Where(h => h.GetType() == typeof(HandlerOne)).Select(h => (HandlerOne)h).ToList();
        }

        public List<HandlerTwo> GethandlerTwo()
        {
            return handlers.Where(h => h.GetType() == typeof(HandlerTwo)).Select(h => (HandlerTwo)h).ToList();
        }
    }
}
