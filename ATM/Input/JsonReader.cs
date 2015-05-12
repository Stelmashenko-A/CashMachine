using System.IO;
using System.Runtime.Serialization.Json;

namespace ATM.Input
{
    public class JsonReader<T>:IReader<T>
    {
        public T Read(string fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.Open);
            var ds = new DataContractJsonSerializer(typeof(T));
            return (T) ds.ReadObject(stream);
        }
    }
}
