using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using VTMS.Model.Entities;
namespace VTMS.Access
{
    public class CustomerDao
    {
        public static Customer GetById(string id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Get<Customer>(id);
            }
        }
        public static void Update(Customer entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }
        public static void Add(Customer entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }
    }
}
