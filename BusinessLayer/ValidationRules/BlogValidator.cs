using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("5 Karakterden Fazla Giriş Yapınız!");
            RuleFor(x => x.BlogTitle).MaximumLength(50).WithMessage("50 Karakterden Az Giriş Yapınız!");
            RuleFor(x => x.BlogContent).MinimumLength(20).WithMessage("Lütfen 20 Karakterden Fazla Giriş Yapınız!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.BLogImage).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
        }

    }
}
