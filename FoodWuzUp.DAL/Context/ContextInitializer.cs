using FoodWuzUp.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class ContextInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            base.Seed(context);

            ApplicationAuthType google = new ApplicationAuthType() { Name = "Google", ThirdPartyKey = "767908454013-n8obtkbr51sjm57jgeh9i3dtbep0c7sb.apps.googleusercontent.com", ThirdPartySecret = "l-11RV3J9E_5QB-vXB7wLS5m" };
            context.ApplicationAuthTypes.Add(google);
            ApplicationAuthType facebook = new ApplicationAuthType() { Name = "Facebook", ThirdPartyKey = "675135002567966", ThirdPartySecret = "d926d4f1094111a4cc49a9ddddfb005c" };
            context.ApplicationAuthTypes.Add(facebook);

            context.RecordTypes.Add(new RecordType() { Name = "RecordType", Description = "BaseTypes", DisplayName = "Base Types" });
            context.SaveChanges();

            foreach (var item in typeof(Context).GetProperties())
            {
                if (item.PropertyType.GetInterface(typeof(IDbSet<>).Name) == null)
                    continue;
                Type prop = item.PropertyType.GenericTypeArguments[0];
                object obj = Activator.CreateInstance(prop, false);
                var method = prop.BaseType.GetMethod("Init");
                object[] parms = { context };
                method.Invoke(obj, parms);
            }
            context.SaveChanges();
        }
    }
}
