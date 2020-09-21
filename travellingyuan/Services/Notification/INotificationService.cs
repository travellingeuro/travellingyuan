using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace travellingyuan.Services.Notification
{
    public interface INotificationService
    {
        Task SendNotification(string serialnumber);
    }
}
