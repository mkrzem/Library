using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassicLibrary.Tests.Concrete
{
    class FakeDbSet<TEntity> : IDbSet<TEntity> where TEntity : class
    {
        public Type ElementType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Expression Expression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<TEntity> Local
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Attach(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Create()
        {
            throw new NotImplementedException();
        }

        public TEntity Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public TEntity Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        TDerivedEntity IDbSet<TEntity>.Create<TDerivedEntity>()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
