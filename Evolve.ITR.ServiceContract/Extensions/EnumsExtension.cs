using System.ComponentModel;
using System.Reflection;

namespace Evolve.ITR.ServiceContract.Extensions
{
    public static class EnumsExtension
    {
        public static string ToDisplayDescription(this object value)
        {
            FieldInfo fi = value?.GetType().GetField(value.ToString());
            if (fi == null) return String.Empty;

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value?.ToString();
        }
    }
}
