using ControlFinaApi.Utils;
using System.ComponentModel;
using System.Text;

namespace ControlFinaApi.Features.Histories.Enums
{
    public struct TypeHistory
    {
        public enum EType
        {
            [Description("Credit: 1")]
            Credit = 1,
            [Description("Debit: 2")]
            Debit = 2
        }

        public static string GetEnumDescriptionValues()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (EType tp in Enum.GetValues(typeof(EType)))
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append(", ");

                string description = EnumUtil.GetEnumDescription(tp);
                stringBuilder.Append($"{description}");
            }

            return stringBuilder.ToString();
        }
    }
}
