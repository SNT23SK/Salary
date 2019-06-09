using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    public static class HeplerJson
    {
        /// <summary>
        /// Сериализация списка данных в файл Json
        /// </summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="name">Путь к файлу</param>
        /// <param name="objects">Список данных</param>
        public static void Serialization<T>(string name, List<T> objects)
        {
            try
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));
                using (var fs = new FileStream(name, FileMode.OpenOrCreate))
                {
                    jsonSerializer.WriteObject(fs, objects);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Десериализация файла Json в список данных
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<T> Deserialization<T>(string name)
        {
            try
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));
                List<T> result = new List<T>();
                using (var fs = new FileStream(name, FileMode.OpenOrCreate))
                {
                    result = (List<T>)jsonSerializer.ReadObject(fs);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
