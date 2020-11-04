using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SmartAgri.DataBase.Communication.Helpers
{

    internal static class Extensions
    {
        internal static T GetRecord<T>(this IDataRecord record, string fieldName)
        {
            if (record.IsDBNull(record.GetOrdinal(fieldName))) return default(T);
            return (T)record[fieldName];
        }
        internal static List<List<T>> Chunk<T>(this List<T> theList, int chunkSize)
        {
            if (!theList.Any())
            {
                return new List<List<T>>();
            }

            List<List<T>> result = new List<List<T>>();
            List<T> currentList = new List<T>();
            result.Add(currentList);

            int i = 0;
            foreach (T item in theList)
            {
                if (i >= chunkSize)
                {
                    i = 0;
                    currentList = new List<T>();
                    result.Add(currentList);
                }
                i += 1;
                currentList.Add(item);
            }
            return result;
        }


    }
}
