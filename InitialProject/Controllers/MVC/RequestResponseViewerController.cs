using InitialProject.BusinessLayer.Interfaces;
using InitialProject.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace InitialProject.Controllers.MVC
{
    public class RequestResponseViewerController : Controller
    {
        private readonly IRequestResponseService _requestResponseService;

        public RequestResponseViewerController(IRequestResponseService requestResponseService)
        {
            _requestResponseService = requestResponseService;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _requestResponseService.GetAllLogsAsync();
            return View(logs);
        }

        public async Task<IActionResult> GetLogs()
        {
            var logs = await _requestResponseService.GetAllLogsAsync();
            var logDtos = logs.Select(log => new
            {
                log.Timestamp,
                log.RequestUrl,
                log.HttpMethod,
                log.RequestBody,
                ResponseBody = JsonFormatter.FormatJson(log.ResponseBody) // Ensure proper JSON formatting
            });
            return Json(logDtos);
        }
    }
}
