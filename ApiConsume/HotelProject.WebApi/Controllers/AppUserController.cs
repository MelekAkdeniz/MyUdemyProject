using HotelProject.BusinessLayer.Abstract;
using HotelProject.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public IActionResult UserListWithWorkLocation()
        {
            var values = _appUserService.TUserListWithWorkLocation()
        .Select(y => new AppUserWorkLocationViewModel
        {
            Name = y.Name,
            Surname = y.Surname,
            WorkLocationID = y.WorkLocationID,
            WorkLocationName = y.WorkLocation.WorkLocationName,
            City = y.City,
            Country = y.Country,
            Gender = y.Gender,
            ImageUrl = y.ImageUrl
        }).ToList();

            return Ok(values);
        }
    }
}
