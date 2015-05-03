using System.IO;
using System.Runtime.Serialization.Json;

namespace ATM.Output
{
    class JsonWriter<T>
    {
        public void Write(T data, string fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.OpenOrCreate);
            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));
            

            ds.WriteObject(stream, data);
            stream.Close();
        }
    }
}
