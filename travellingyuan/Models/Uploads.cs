using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace travellingyuan.Models
{
    [Preserve(AllMembers = true)]
    public partial class Uploads
    {
        public int NotesId { get; set; }
        public int UsersId { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Address { get; set; }
        public DateTime UploadDate { get; set; }
        public string Location { get; set; }
        public string Comments { get; set; }
        public string SerialNumber { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public Notes Notes { get; set; }
        public Users Users { get; set; }
    }

    public partial class ExtendedUploads
    {
        public string ItemImage { get; set; }
        public DateTime UploadDate { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
        public string Name { get; set; }
    }
}
