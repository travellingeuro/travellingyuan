using Syncfusion.SfMaps.XForms;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace travellingyuan.Controls
{
    [Preserve(AllMembers = true)]
    public class CustomMarker : MapMarker
    {
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public ImageSource Image { get; set; }
        public string Serial { get; set; }
    }

}

