using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    public class HandlerComposite
    {
        public List<Handler> handlers;

        public HandlerComposite() { handlers = new List<Handler>(); }

        public void RunProcessing(List<double>  numbers)
        {
            foreach (var handler in handlers)
                handler.RunProcessing(numbers);
        }

        public void AddHandlerAtTheEnd(Handler handler) => handlers.Add(handler);
        
        public bool AddHandlerByName(Handler handler, string strName)
        {
            for (int i = 0; i < handlers.Count; i++)
            {
                if (handlers[i].Name == strName)
                {
                    handlers.Insert(i + 1, handler);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveHandlerByName(string strName)
        {
            for (int i = 0; i < handlers.Count; i++)
            {
                if (handlers[i].Name == strName)
                {
                    handlers.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
