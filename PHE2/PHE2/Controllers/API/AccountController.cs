
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PHE2.Services;
using System.Net;

namespace PHE2.Controllers.API
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetAll()
        {
            var result = _accountService.GetAll();
            if (result is null || !result.Any())
            {
                return Json(new
                {
                    Code = (int)HttpStatusCode.NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                Code = (int)HttpStatusCode.OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            }, JsonRequestBehavior.AllowGet);
        }
    }
}