using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/skakgun"),
                Headers =
    {
        { "x-rapidapi-key", "b7d12692e3msh1f3ad94cf6bbe2ap10af52jsn8e0f11eabc88" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersDto resultInstagramFollowersDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.v1 = resultInstagramFollowersDtos.following;
                ViewBag.v2 = resultInstagramFollowersDtos.followers;
            }


            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/profile?username=nesoruyonn"),
                Headers =
    {
        { "x-rapidapi-key", "b7d12692e3msh1f3ad94cf6bbe2ap10af52jsn8e0f11eabc88" },
        { "x-rapidapi-host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultTwitterFollowersDto resultTwitterFollowersDto = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
                ViewBag.v3 = resultTwitterFollowersDto.data.stats.following;
                ViewBag.v4 = resultTwitterFollowersDto.data.stats.followers;
            }

           
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tiktok-api23.p.rapidapi.com/api/user/info?uniqueId=skakgun"),
                Headers =
    {
        { "x-rapidapi-key", "b7d12692e3msh1f3ad94cf6bbe2ap10af52jsn8e0f11eabc88" },
        { "x-rapidapi-host", "tiktok-api23.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ResultTiktokFollowersDto resultTiktokFollowersDto = JsonConvert.DeserializeObject<ResultTiktokFollowersDto>(body3);
                ViewBag.v5 = resultTiktokFollowersDto.userInfo.stats.followingCount;
                ViewBag.v6 = resultTiktokFollowersDto.userInfo.stats.followerCount;
            }
            return View();
        }
    }
}
