using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace PAWA.DAL
{
    public class TestDbContext<Entity> : IDbSet<Entity>
        where Entity : class
    {
        ObservableCollection<Entity> data;
        IQueryable query;

        public TestDbContext()
        {
            data = new ObservableCollection<Entity>();
            query = data.AsQueryable();
        }

        public virtual Entity Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<Entity> and" +
                " override Find");
        }

        public Entity Add(Entity item)
        {
            data.Add(item);
            return item;
        }

        public Entity Remove(Entity item)
        {
            data.Remove(item);
            return item;
        }

        public Entity Attach(Entity item)
        {
            data.Add(item);
            return item;
        }

        public Entity Detach(Entity item)
        {
            data.Remove(item);
            return item;
        }

        public Entity Create()
        {
            return Activator.CreateInstance<Entity>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, Entity
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<Entity> Local
        {
            get { return data; }
        }

        Type IQueryable.ElementType
        {
            get { return query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return query.Provider; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}