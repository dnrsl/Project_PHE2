using PHE2.Contratcs;
using PHE2.Data;
using PHE2.DTOs.Users;
using PHE2.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace PHE2.Controllers.API
{
    public class UserProjectController : Controller
    {
        private readonly UserProjectService _userProjectService;
        public UserProjectController(UserProjectService userProjectService)
        {
            _userProjectService = userProjectService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetAll()
        {
            var result = _userProjectService.GetAll();
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
            var result = _userProjectService.GetByGuid(guid);
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