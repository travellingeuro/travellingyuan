﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace travellingyuan.Models
{
    [Preserve(AllMembers = true)]
    public partial class Users
    {
        public Users()
        {
            Uploads = new HashSet<Uploads>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public sbyte? EmailConfirmed { get; set; }
        public string Role { get; set; }
        public string Country { get; set; }
        public string Alias { get; set; }
        public sbyte? Keepmeinformed { get; set; }
        public sbyte? Keeplogged { get; set; }

        public ICollection<Uploads> Uploads { get; set; }

        internal void PostUsernew(List<Users> user)
        {
            throw new NotImplementedException();
        }
    }
}
