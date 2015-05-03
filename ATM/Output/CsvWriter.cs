using System.IO;
using ServiceStack.Text;

namespace ATM.Output
{
    class CsvWriterer<T>
    {
        public void Write(T data, string fileName)
        {
            CsvSerializer.SerializeToStream(data, new FileStream(fileName,FileMode.OpenOrCreate));
        }
    }
}
