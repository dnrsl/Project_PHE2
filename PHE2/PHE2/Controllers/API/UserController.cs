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
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("")]
        public ActionResult GetAll()
        {
            var result = _userService.GetAll();
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
            var result = _userService.GetByGuid(guid);
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

        [HttpPost]
        [Route("create")]
        public ActionResult Create(NewUserDto newUserDto)
        {
            var result = _userService.Create(newUserDto);
            if (result is null)
            {
                return Json(new
                {
                    Code = (int)HttpStatusCode.InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Error retrieve from database"
                });
            }
            return Json(new
            {
                Code = (int)HttpStatusCode.OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Success retrieve data",
                Data = result
            });

        }
    }
}