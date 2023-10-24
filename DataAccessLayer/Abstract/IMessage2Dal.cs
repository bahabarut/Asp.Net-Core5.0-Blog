using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        public List<Message2> GetListWithMessageByWriter(int id);
        public List<Message2> GetListWithMessageBySender(int id);
        public Message2 GetByIdWithSender(int id);
    }
}
