using System;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{
    public class NeedContainSpaceAttribute : DataTypeAttribute
    {
        public NeedContainSpaceAttribute(): base(DataType.Text)
        {
            ErrorMessage = "必須包含一個空白";
        }

        public override bool IsValid(object value)
        {
            var str = (string)value;
            return str.Contains(" ");
        }
    }
}