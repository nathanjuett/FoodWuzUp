using System;
using FoodWuzUp.Core;
using System.ComponentModel.DataAnnotations;

namespace FoodWuzUp.DAL
{
    public class RecordType : Base<RecordType>
    {
        [MaxLength(255)]
        public string DisplayName { get; set; }
        [MaxLength(255)]
        public string CssClass { get; set; }
    }
}