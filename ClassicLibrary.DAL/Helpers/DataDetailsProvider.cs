using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicLibrary.DAL.Helpers
{
    public class DataDetailsProvider
    {
        public static string GetEnumerationAsJson<TEnum>()
        {
            Type enumType = typeof(TEnum);

            if (!enumType.IsEnum)
            {
                return "";
            }

            var enumItems = from value in Enum.GetValues(enumType).Cast<int>()
                            let name = Enum.GetName(enumType, value)
                            select new
                            {
                                Value = value,
                                Name = name
                            };

            return JsonConvert.SerializeObject(enumItems);
        }
    }
}
