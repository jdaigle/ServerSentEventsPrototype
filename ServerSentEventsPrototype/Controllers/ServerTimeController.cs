using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ServerSentEventsPrototype.Controllers
{
    public class ServerTimeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            long lastEventID = 0;
            var lastEventIDPresent = long.TryParse(Request.Headers["Last-Event-ID"], out lastEventID);

            Response.ContentType = "text/event-stream";
            Response.Flush();

            await Task.Delay(5000);

            var currentdate = DateTime.UtcNow;
            while (currentdate.AddSeconds(10) > DateTime.UtcNow)
            {
                lastEventID++;
                var now = DateTime.UtcNow;
                Response.Write("event: serverTime\n");
                Response.Write(string.Format("id: {0}\n", lastEventID.ToString()));
                Response.Write(string.Format("data: {0} - {1}\n", now.ToString("HH:mm:ss", CultureInfo.InvariantCulture), lastEventID.ToString()));
                Response.Write("\n");
                Response.Flush();
                await Task.Delay(1000);
            }
            return Content("");
        }
    }
}