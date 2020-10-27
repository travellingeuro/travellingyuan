using System;
using System.Collections.Generic;
using System.Text;

namespace travellingyuan.Helper
{
    public class MintPicker
    {
        public string Name { get; set; }

        public string Picker(int value)
        {
            switch (value)
            {
                case 1:
                    Name = "Beijing";
                    break;
                case 2:
                    Name = "Shanghai";
                    break;
                case 3:
                    Name = "Chengdu";
                    break;
                case 4:
                    Name = "Shijiazhuang";
                    break;
                case 5:
                    Name = "Nanchang";
                    break;
                default:
                    Name = "Not Defined";
                    break;
            }
            return Name;
        }
    }
}
