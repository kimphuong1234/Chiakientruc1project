using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Model
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayName : Attribute
    {
        public string PropertyName { get; set; }
        public DisplayName(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        public int Length { get; set; }
        public MaxLength(int maxLength)
        {
            Length = maxLength;
        }
    }
    class Base
    {
    }
}
