using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarrerTrack.Data;
using CarrerTrack.Data.Context;
using CareerTrack.Utils.Functionalities.BrokenLink;
using CareerTrack.Logging;
using System.Timers;

namespace CareerTrack.Utils
{
    class Program
    {
        static void Main(string[] args)
        {
            CareerTrackContext db = new CareerTrackContext();

            IBrokenLink brokenLink = new BrokenLink();

            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(60 * 60 * 1000 * 24);
                brokenLink.SetBrokenLinks(db.Articles);
            });
        }
    }
}
