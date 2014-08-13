using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class ApplicationAuthType : Base<ApplicationAuthType>
    {
        public string ThirdPartyKey { get; set; }
        public string ThirdPartySecret { get; set; }

        
    }
}
