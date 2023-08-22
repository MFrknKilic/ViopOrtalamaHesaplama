using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ViopOrtalama.Entities.Enums.EnumExtensions
{

        public static class EnumExtensions
        {
            public static string GetDisplayName(this Enum enumValue)
            {
                var enumType = enumValue.GetType();
                var memberInfo = enumType.GetMember(enumValue.ToString());

                if (memberInfo.Length > 0)
                {
                    var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)
                        .OfType<DisplayAttribute>()
                        .FirstOrDefault();

                    if (displayAttribute != null)
                    {
                        return displayAttribute.Name;
                    }
                }

                return enumValue.ToString();
            }
        }
    
}
