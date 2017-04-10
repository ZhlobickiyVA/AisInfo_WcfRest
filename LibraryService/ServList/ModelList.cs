using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryService
{



    public class ModelList
    {
        public ListKinder KinderList { get; set; }
        public ListEDV Listedv { get; set; }
        public ListOldLive Listoldlive { get; set; }
        public ListPayKinder Listpaykinder { get; set; }

        public ModelList()
        {
            KinderList = new ListKinder();
            Listedv = new ListEDV();
            Listoldlive = new ListOldLive();
            Listpaykinder = new ListPayKinder();
        }
    }
}