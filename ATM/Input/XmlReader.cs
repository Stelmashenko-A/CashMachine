using System.IO;
using System.Runtime.Serialization;

namespace ATM.Input
{
    public class XmlReader<T>:IReader<T>
    {
        public T Read(string fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.Open);
            var ds = new DataContractSerializer(typeof(T));
            return (T)ds.ReadObject(stream);
        }
    }
}
