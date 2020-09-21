using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace travellingyuan.Services.Scan
{
    public interface IScanService
    {
        Task<string> GetSearchAsync();
    }
}
