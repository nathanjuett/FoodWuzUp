using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.Core
{
    interface IParameters
    {
        int id { get; set; }
        Dictionary<string, string> filters { get; set; }
        Dictionary<string, string> orderby { get; set; }

    }
    public class Parameters : IParameters
    {
        public int id { get; set; }
        public Dictionary<string, string> filters { get; set; }
        public Dictionary<string, string> orderby { get; set; }

        public Parameters()
        {
            filters = new Dictionary<string, string>();
            orderby = new Dictionary<string, string>();
        }
    }
}
