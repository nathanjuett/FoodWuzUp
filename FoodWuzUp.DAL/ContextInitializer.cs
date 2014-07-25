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
