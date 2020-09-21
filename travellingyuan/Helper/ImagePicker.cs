using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xamarin.Forms;

namespace travellingyuan.Helper
{
	public class ImagePicker
	{
		public ImageSource Image { get; set; }
		public ImageSource Imagepicker(int value)
		{
			switch (value)
			{
                case 5:
					Image= ImageSource.FromResource("travellingyuan.Images.five.gif");
					break;
				case 10:
					Image = ImageSource.FromResource("travellingyuan.Images.ten.gif");
					break;
				case 20:
					Image = ImageSource.FromResource("travellingyuan.Images.twenty.gif");
					break;
				case 50:
					Image = ImageSource.FromResource("travellingyuan.Images.fifty.gif");
					break;
				case 100:
					Image = ImageSource.FromResource("travellingyuan.Images.onehundred.gif");
					break;
				case 200:
					Image = ImageSource.FromResource("travellingyuan.Images.twohundred.gif");
					break;
				case 500:
					Image = ImageSource.FromResource("travellingyuan.Images.binladen.gif");
					break;
				default:
					Image = ImageSource.FromResource("travellingyuan.Images.specimen.gif");
					break;
			}
			return Image;
		}
	}
}
