using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodWuzUp.Core;

namespace FoodWuzUp.DAL.Test
{

    public abstract class BaseTest<T>
        where T : class, IBase, new()
    {

        [TestInitialize]
        public void Init()
        {
            Context db = new Context();
            db.Database.Delete();
        }
        [TestCleanup]
        public void Clean()
        {
            Context db = new Context();
            db.Database.Delete();
        }
        public void BaseCreateTest()
        {
            Context db = new Context();
            string unique = Guid.NewGuid().ToString();
            T efobject = new T() { Name = unique };
            efobject = Create(efobject, db);
            db.Set<T>().Add(efobject);
            db.SaveChanges();

            db = new Context();
            T actual = AddIncludes(db, efobject.ID);
            AddedAsserts(db, actual, unique);
        }

        public virtual T AddIncludes(Context db, int ID)
        {
            T actual = db.Set<T>().Find(ID);
            return actual;
        }

        public virtual void AddedAsserts(Context db, T efobject, string unique)
        {
            Assert.AreNotEqual(0, efobject.ID);
            Assert.AreEqual(unique, efobject.Name);
         }
        public virtual T Create(T efobject, Context db)
        {
            throw new NotImplementedException("Please Implement This Method.");
        }

    }

    public abstract class BaseWithCommentsTest<TBase, TComment> : BaseTest<TBase>
        where TBase : class, IBaseWithComments<TBase, TComment>, IBase, new()
        where TComment : class, IBaseComment<TBase>, new()
    {
        public override TBase Create(TBase efobject, Context db)
        {
            TComment comment = new TComment() { Comment = efobject.Name };
            efobject.Comments.Add(comment);
            efobject.Comments.Add(new TComment() { Comment = Guid.NewGuid().ToString() });
            return efobject;
        }
        public override TBase AddIncludes(Context db, int ID)
        {
            return db.Set<TBase>().Include("Comments").Where(o => o.ID == ID).Single();
        }
        public override void AddedAsserts(Context db, TBase efobject, string unique)
        {
            base.AddedAsserts(db, efobject, unique);
            Assert.AreEqual(2, efobject.Comments.Count);
            Assert.AreEqual(efobject.Name, efobject.Comments.Where(o => o.ID == 1).Single().Comment);
            Assert.AreNotEqual(efobject.Comments.Where(o => o.ID == 1).Single().Comment, efobject.Comments.Where(o => o.ID == 2).Single().Comment);
        }
    }
}
