using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo1.Models;

namespace WebApiDemo1.Controllers
{
    [Route("api/contact")]
    public class ContactController: Controller
    {
    [HttpGet("")]
    [Authorize(Roles ="admin")]
    public List<ContactModel> Get()
        {
            return new List<ContactModel>
            {
                new ContactModel{Id=1 , FirstName="Arda",LastName="Bilecan"},
                new ContactModel{Id=2 , FirstName="Mesut",LastName="Yılmaz"},
                new ContactModel{Id=3 , FirstName="Hakan",LastName="kaya"}
            };
        }
    }
}
