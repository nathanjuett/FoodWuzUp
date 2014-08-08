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
    public abstract class Base<T> : IBase, ICloneable
        where T : IBase, new()
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        public virtual void Init(Context db)
        {
            if (typeof(T) == typeof(RecordType))
                return;
            db.RecordTypes.Add(new RecordType() { Name = typeof(T).Name, Description = typeof(T).Name, DisplayName = typeof(T).Name });
        }

        public virtual object Clone()
        {
           T clone = new T();
           foreach (var item in typeof(T).GetProperties().Where(o=> o.Name != "ID" && o.Name != "UniqueID"))
           {
               if (item.PropertyType.IsGenericType)
                   continue;
               if (item.PropertyType.BaseType.IsGenericType)
                   continue;
               item.SetValue(clone, item.GetValue(this));
           }
           return clone;
        }

    }
   
    //public abstract class BaseRating<TBase, TComment> : IBaseComment<TBase>
    //    where TComment : IBaseComment<TBase>
    //    where TBase : IBase
    //{

    //    [Key]
    //    public int ID { get; set; }
    //    public string Comment { get; set; }

    //    [ForeignKey("Parent")]
    //    public int ParentID { get; set; }

    //    public TBase Parent { get; set; }
    //}
}
