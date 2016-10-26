﻿using OSIM.Core.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSIM.Core.Persistence
{
    public interface IItemTypeRepository
    {
        int Save(ItemType itemType);
    }
    public class ItemTypeRepository : IItemTypeRepository
    {
        private ISessionFactory _sessionFactory;
        public ItemTypeRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
        public int Save(ItemType itemType)
        {
            int id;
            using (var session = _sessionFactory.OpenSession())
            {
                id = (int)session.Save(itemType);
                session.Flush();
            }
            return id;
        }
    }
}
