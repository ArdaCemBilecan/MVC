using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo1.Models;
using Microsoft.AspNetCore.Http;

namespace WebApiDemo1.Formatters
{
    public class VcardOutputFormatter:TextOutputFormatter
    {
        public VcardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var stringBuilder = new StringBuilder();
            if(context.Object is List<ContactModel>)
            {
                foreach(ContactModel model in context.Object as List<ContactModel>)
                {
                    FormatVcard(stringBuilder, model);
                }
            }
            else
            {
                var contact = context.Object as ContactModel;
                FormatVcard(stringBuilder, contact);
            }

            return response.WriteAsync(stringBuilder.ToString());
        }

        private static void FormatVcard(StringBuilder stringbuilder, ContactModel model)
        {
            stringbuilder.AppendLine("BEGIN:VCARD");
            stringbuilder.AppendLine("VERSION:4.0");
            stringbuilder.AppendLine($"N:{model.FirstName}; {model.LastName}");
            stringbuilder.AppendLine($"LN:{model.LastName}; {model.FirstName}");
            stringbuilder.AppendLine($"UID:{model.Id}\r\n");
            stringbuilder.AppendLine("END:VCARD");

        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(ContactModel).IsAssignableFrom(type)|| typeof(List<ContactModel>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

    }
}
