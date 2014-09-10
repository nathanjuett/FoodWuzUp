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
    public abstract class BaseXref<Txref, Tparent, Tchild> : IBaseXref
        where Txref : IBaseXref
        where Tparent : IBase
        where Tchild : IBase
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Parent")]
        public int ParentID { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("Child")]
        public int ChildID { get; set; }

        public Tparent Parent { get; set; }
        public Tchild Child { get; set; }

        public virtual void Init(Context db)
        {
            //if (typeof(Txref) == typeof(RecordType))
            //    return;
            //db.RecordTypes.Add(new RecordType() { Name = typeof(Txref).Name, Description = typeof(Txref).Name, DisplayName = typeof(Txref).Name });
        }
    }
     
}
