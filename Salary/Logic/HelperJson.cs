using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Logic
{
    public static class HelperJson
    {
        /// <summary>
        /// Сериализация списка данных в файл Json
        /// </summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="pathFile">Путь к файлу</param>
        /// <param name="objects">Список данных</param>
        public static void Save<T>(string pathFile, T obj)
        {
            try
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                using (var fs = new FileStream(pathFile, FileMode.OpenOrCreate))
                {
                    jsonSerializer.WriteObject(fs, obj);
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
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public static T Load<T>(string pathFile)
        {
            try
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                T result;
                using (var fs = new FileStream(pathFile, FileMode.OpenOrCreate))
                {
                    result = (T)jsonSerializer.ReadObject(fs);
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
