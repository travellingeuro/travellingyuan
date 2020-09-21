using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace travellingyuan.Helper
{
    class Checkvalue
    {

        private string message;
        public string Message { get => message; set => message = value; }

        public bool Checknumber(string serial)
        {
            if (serial is null)
            {
                Message = "Serial number cannot be empty";
                return false;
            }

            if (serial.Length != 12)
            {

                Message = "Serial Number must be 12 characters long and it must begin with a letter";
                return false;
            }

            if (!Checkfirstletter(serial))
            {
                Message = "Serial Number must begin with a letter";
                return false;
            }

            if (!Isfirstlettervalid(serial.ToUpper()))
            {
                Message = "Not a valid initial letter";
                return false;
            }
            if (!Isnumbervalid(serial))
            {
                Message = "Not a valid serial number. Check it again";
                return false;
            }
            return true;
        }

        public bool Checkfirstletter(string serial)
        {
            char firstletter = serial.ToCharArray().ElementAt(0);
            return char.IsLetter(firstletter) ? true : false;
        }

        public bool Isfirstlettervalid(string serial)
        {

            Dictionary<char, int> dict = new Dictionary<char, int>()
                                            {
                                            {'P',1},{'Y',1 } ,{'G',1},{'F',2}, {'X',2},{'E',3},
                                            {'N','3'},{'D',4},{'M',4},{'V',4},{'U',5},{'L',5},{'T',6},
                                            {'S',7},{'R',8},{'H',9},{'Z',9},{'W',3}
                                            };
            return dict.ContainsKey(serial.ToUpper().ToCharArray().ElementAt(0)) ? true : false;
        }

        public bool Isnumbervalid(string serial)
        {
            string serialupper = serial.ToUpper();
            var letter = new int();
            foreach (char x in serialupper)
            {
                if (char.IsLetter(x))
                {
                    letter = letter + (int)x;
                    serialupper = serialupper.TrimStart(x);
                }
            }
            var sum = serialupper.Sum(c => c - '0');
            int cheksum = sum + letter;
            return cheksum % 9 == 0 ? true : false;
        }
    }
}
