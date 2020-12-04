using System;
using System.Linq;
using System.Reflection;

namespace CharactorSelectorApi.Models
{
    /// <summary>Pseudo extension class for enumerations</summary>
    /// <typeparam name="TEnum">Enumeration type</typeparam>
    public class EnumHelper<TEnum> where TEnum : struct, IConvertible
    {
        public static string GetDescription(Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if (memberInfo.Length > 0)
            {
                var _Attribs = memberInfo[0]
                    .GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (_Attribs.Length > 0)
                {
                    return ((System.ComponentModel.DescriptionAttribute) _Attribs.ElementAt(0)).Description;
                }
            }

            return GenericEnum.ToString();
        }
    }
}