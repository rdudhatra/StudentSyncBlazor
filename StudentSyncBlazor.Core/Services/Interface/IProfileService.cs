using StudentSyncBlazor.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Core.Services.Interface
{
    public interface IProfileService
    {
        Task<ProfileViewModel> GetProfileAsync(string username);
        Task UpdateProfileAsync(ProfileViewModel model);
    }
}
