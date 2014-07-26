using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.Core
{
    public interface IBase
    {
        int ID { get; set; }
        string Name { get; set; }
    }
    public interface IBaseWithComments<IBase, IBaseComment>
    {
        ICollection<IBaseComment> Comments { get; set; }
    }

    public interface IBaseComment<TParent>
        where TParent : IBase
    {
        int ID { get; set; }
        string Comment { get; set; }
        int ParentID { get; set; }
        TParent Parent {get;set;}

    }
   
}
