using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace travellingyuan.Services.AddNote
{
    public interface IAddNoteService
    {
        Task<List<Models.Notes>> GetSearchAsync(string serialnumber);
        Task<List<Models.Uploads>> GetListUploads(string email);
        Task<List<Models.Mints>> GetMintCode(string code);
        Task<string> PostUpload(Models.Uploads uploads);
        Task<string> PostNote(Models.Notes note);

    }
}
