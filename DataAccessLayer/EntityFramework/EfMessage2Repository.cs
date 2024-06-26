﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListWithMessageByWriter(int id)
        {
            using (Context c = new Context())
            {
                return c.Messages2.Include(x => x.SenderUser).Where(z => z.ReceiverID == id).ToList();

            }
        }
        public List<Message2> GetListWithMessageBySender(int id)
        {
            using (Context c = new Context())
            {
                return c.Messages2.Include(y => y.ReceiverUser).Where(x => x.SenderID == id).ToList();
            }
        }
        public Message2 GetByIdWithSender(int id)
        {
            using (Context c = new Context())
            {
                return c.Messages2.Include(y => y.SenderUser).Where(x => x.MessageID == id).FirstOrDefault();
            }
        }
    }
}
