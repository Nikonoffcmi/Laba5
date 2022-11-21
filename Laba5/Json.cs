using Newtonsoft.Json;
using System.IO;

//////////////////////// Практика 5 ///////////////////////////////
namespace Laba5
{
    internal class JsonHandlers<T>
        where T : class
    {
        public string FileName { get; private set; }

        public void JsonSerialize(T handlerComposite)
        {
            string jsonHandlers = JsonConvert.SerializeObject(handlerComposite, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            File.WriteAllText(FileName, jsonHandlers);
        }

        public T JsonDeserialize()
        {
            T handlerComposite = JsonConvert.DeserializeObject<T>(File.ReadAllText(FileName), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            return handlerComposite;
        }

        public JsonHandlers(string fileName)
        {
            FileName = fileName;
        }
    }
}
