using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message2>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverID).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz!");
            RuleFor(x => x.MessageDetails).NotEmpty().WithMessage("Bu Alan Boş Bırakılamaz!");
            RuleFor(x => x.MessageDetails).MinimumLength(8).WithMessage("Bu Alan 8 Karakterden Fazla Olmalıdır!");
        }
    }
}
