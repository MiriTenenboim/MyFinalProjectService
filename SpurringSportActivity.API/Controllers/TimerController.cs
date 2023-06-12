//using SpurringSportActivity.Common.DTO;
//using SpurringSportActivity.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Cors;
//using System.Collections.Concurrent;
//using System.Threading.Tasks;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace SpurringSportActivity.API.Controllers
//{
//    [EnableCors("_myAllowSpecificOrigins")]
//    [Route("api/[controller]")]
//    [ApiController]

//    public class TimerController : ControllerBase
//    {
//        private readonly IPublicPointService _publicPointService;

//        private static ConcurrentDictionary<string, Task<string>> timers = new ConcurrentDictionary<string, Task<string>>();
//        int totalSeconds;

//        public TimerController(IPublicPointService publicPointService)
//        {
//            _publicPointService = publicPointService;
//        }

//        [HttpGet]
//        [Route("api/Timer/start")]
//        public OkObjectResult StartTimer(DateTime date)
//        {
//            string timerId = GetUniqueTimerId();

//            totalSeconds = CalculateDifferenceInSeconds(DateTime.Today, date);

//            Task<string> timerTask = StartTimerAsync(timerId);

//            timers.TryAdd(timerId, timerTask);

//            return Ok(totalSeconds);
//        }

//        [HttpGet("timerId")]
//        //[Route("api/timer/status/{timerId}")]
//        public ObjectResult GetTimerStatus(string timerId)
//        {
//            if (timers.TryGetValue(timerId, out Task<string> timerTask))
//            {
//                if (timerTask.IsCompleted)
//                {
//                    // Remove the completed timer task from the collection
//                    timers.TryRemove(timerId, out _);

//                    return Ok("Timer completed.");
//                }

//                return Ok("Timer is running.");
//            }

//            return Ok("problem");
//        }

//        // חישוב הפרש בשניות בין תאריכים
//        private int CalculateDifferenceInSeconds(DateTime date1, DateTime date2)
//        {
//            TimeSpan timeSpan = date2 - date1;
//            int differenceInSeconds = (int)timeSpan.TotalSeconds;

//            return differenceInSeconds;
//        }


//        private async Task<string> StartTimerAsync(string timerId)
//        {
//            await Task.Delay(totalSeconds); // Simulate a 5-second timer 

//            return _publicPointService.AddPublicPointAsync()
//            }

//        private string GetUniqueTimerId()
//        {
//            return Guid.NewGuid().ToString("N");
//        }
//    }
//}
