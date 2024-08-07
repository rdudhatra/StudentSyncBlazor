﻿using StudentSyncBlazor.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Core.Services.Interface
{
    public interface IInquiryFollowUpService
    {
        Task<IList<InquiryFollowUp>> GetAllInquiryFollowUpsAsync();
        Task<InquiryFollowUp> GetInquiryFollowUpByIdAsync(int id);
        Task AddInquiryFollowUpAsync(InquiryFollowUp inquiryFollowUp);
        Task UpdateInquiryFollowUpAsync(InquiryFollowUp inquiryFollowUp);
        Task DeleteInquiryFollowUpAsync(int id);

        Task<int> GetTotalInquiryFollowUpAsync();

    }
}
