using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travellingyuan.MarkupExtension
{
    [ContentProperty("ResourceID")]
    class EmbeddedImage : IMarkupExtension
    {
        public string ResourceID { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(ResourceID))
                return null;

            return ImageSource.FromResource(ResourceID);
        }
    }
}
