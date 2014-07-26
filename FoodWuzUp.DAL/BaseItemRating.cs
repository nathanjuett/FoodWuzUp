using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodWuzUp.Core;

namespace FoodWuzUp.DAL
{
    public class BaseItemRating<Txref, TParent, TItem> : BaseXref<Txref, TParent, TItem>
        where Txref : IBaseXref
        where TParent : IBase
        where TItem : IBase
    {
        public int RatingID { get; set; }
        public Rating Rating { get; set; }
    }
}
