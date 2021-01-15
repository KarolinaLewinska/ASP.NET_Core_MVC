using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsDataSystem.Models
{
        public class DateRangeAttribute : RangeAttribute
        {
            public DateRangeAttribute()
                : base(typeof(DateTime), "01/01/1900", DateTime.Now.ToShortDateString())
            {
            }
        }
}