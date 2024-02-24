using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Applicationn.IServices;
using System.Globalization;

namespace Shop.Api.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IPostService _postService;
        public DashboardController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet("ThongKeTheoTuan")]
        public IActionResult ThongKeTheoTuan()
        {
            var groupedResult = _postService
      .getAll()
      .Where(bv => bv.PostDate.HasValue && bv.PostDate.Value.Year == DateTime.Now.Year
                    && bv.PostDate.Value.Month == DateTime.Now.Month)
      .GroupBy(bv => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(bv.PostDate.Value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
      .Select(group => new
      {
          Week = group.Key,
          SoLuongBaiViet = group.Count(),
      })
      .OrderBy(item => item.Week)
      .ToList();
            var thongKe = new ThongKeTheoTuan();
            foreach (var item in groupedResult)
            {
                switch (item.Week)
                {
                    case 1:
                        thongKe.TuanMot = item.SoLuongBaiViet;
                        break;
                    case 2:
                        thongKe.TuanHai = item.SoLuongBaiViet;
                        break;
                    case 3:
                        thongKe.TuanBa = item.SoLuongBaiViet;
                        break;
                    case 4:
                        thongKe.TuanBon = item.SoLuongBaiViet;
                        break;
                }
            }
            return Ok(thongKe);
        }
        [HttpGet("ThongKeBaiViet")]
        public IActionResult ThongKeBaiViet()
        {
            var result = new ThongKeBaiViet()
            {
                BaiVietChuaDuyet = _postService.getAll().Count(x => x.IsStatus == false),
                TongBaiViet = _postService.getAll().Count()
            };
            return Ok(result);
        }
    }
}
