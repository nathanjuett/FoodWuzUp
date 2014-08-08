using FoodWuzUp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public abstract class BaseComment<TBase, TComment> : IBaseComment<TBase>
        where TComment : IBaseComment<TBase>
        where TBase : IBase
    {

        [Key]
        public int ID { get; set; }
        public string Comment { get; set; }

        [ForeignKey("Parent")]
        public int ParentID { get; set; }

        public TBase Parent { get; set; }
    }
}
