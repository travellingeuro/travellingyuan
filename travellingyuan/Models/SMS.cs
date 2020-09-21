using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace travellingyuan.Models
{
    [Preserve(AllMembers = true)]
    public partial class SMS
    {
        public SMS()
        {

        }

        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
    }
}
