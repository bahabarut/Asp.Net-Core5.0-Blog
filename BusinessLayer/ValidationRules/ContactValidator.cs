using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactUserName).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.ContactMessage).MinimumLength(10).WithMessage("Bu Alan 10 Karakterden Az Olamaz!");
            RuleFor(x => x.ContactMail).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi giriniz!");
        }
    }
}
