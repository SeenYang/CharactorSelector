using System;
using System.ComponentModel;
using System.Linq;

namespace CharactorSelectorApi.Models
{
    /// <summary>Extension class for enumerations</summary>
    /// <typeparam name="TEnum">Enumeration type</typeparam>
    public class EnumHelper<TEnum> where TEnum : struct, IConvertible
    {
        public static string GetDescription(Enum GenericEnum)
        {
            var genericEnumType = GenericEnum.GetType();
            var memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if (memberInfo.Length > 0)
            {
                var _Attribs = memberInfo[0]
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (_Attribs.Length > 0) return ((DescriptionAttribute) _Attribs.ElementAt(0)).Description;
            }

            return GenericEnum.ToString();
        }
    }
}