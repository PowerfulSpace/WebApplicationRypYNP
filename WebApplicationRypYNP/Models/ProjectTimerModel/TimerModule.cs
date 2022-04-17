using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationRypYNP.Domain.Abstracts.Interfaces;

namespace WebApplicationRypYNP.Models.ProjectTimerModel
{
    public class TimerModule
    {
        private readonly IPayer _context;

        static Timer timer;
        int interval; //   86400000 24 часа
        static object synclock = new object();
        static bool sent = false;

        public TimerModule(IPayer context, int interval)
        {
            _context = context;
            this.interval = interval;           
        }

        public void Init()
        {
            timer = new Timer(new TimerCallback(SendEmail), null, 0, interval);
        }

        private void SendEmail(object obj)
        {
            lock (synclock)
            {
                DateTime dd = DateTime.Now;
                if (dd.Hour == 7 && dd.Minute == 0 && sent == false)
                {

                    _context.SendMessage();

                    sent = true;
                }
                else if (dd.Hour != 7 && dd.Minute != 0)
                {
                    sent = false;
                }
            }
        }
    }
}
