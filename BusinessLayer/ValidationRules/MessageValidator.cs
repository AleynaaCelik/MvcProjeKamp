using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz.");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage(" Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage(" Konu en fazla 100 karakter olmalı");

            RuleFor(x => x.MessageContent).MinimumLength(10).WithMessage(" Mesaj içeriği en az 10 karakter olmalı");

        }
    }
}
