using PHE2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PHE2.Controllers.API
{
    public class AccountRoleController : Controller
    {
        private readonly AccountRoleService _accountRoleService;

        public AccountRoleController(AccountRoleService accountRoleService)
        {
            _accountRoleService = accountRoleService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetAll()
        {
            var result = _accountRoleService.GetAll();
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

        [HttpGet]
        [Route("{guid}")]
        public ActionResult GetByGuid(Guid guid)
        {
            var result = _accountRoleService.GetByGuid(guid);
            if (result is null)
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