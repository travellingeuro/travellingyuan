using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace travellingyuan.Models
{
    [Preserve(AllMembers = true)]
    public partial class Mints
    {
        public Mints()
        {
            Notes = new HashSet<Notes>();
        }

        public int Id { get; set; }
        public string Mintcode { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Comments { get; set; }

        public ICollection<Notes> Notes { get; set; }
    }
}
