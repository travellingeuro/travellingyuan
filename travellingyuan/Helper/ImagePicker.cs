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
                case 1:
					Image= ImageSource.FromResource("travellingyuan.Images.one.gif");
					break;
				case 2:
					Image = ImageSource.FromResource("travellingyuan.Images.two.gif");
					break;
				case 5:
					Image = ImageSource.FromResource("travellingyuan.Images.five.gif");
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
					Image = ImageSource.FromResource("travellingyuan.Images.hundred.gif");
					break;
				default:
					Image = ImageSource.FromResource("travellingyuan.Images.specimen.gif");
					break;
			}
			return Image;
		}
	}
}
