
using StudentSyncBlazor.Data.Models;
using StudentSyncBlazor.Data.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Core.Services.Interface
{
    public interface IBatchService 
    {
        Task<List<BatchResponseModel>> GetAllBatchesAsync();
        Task<Batch> GetBatchByIdAsync(int id);
        Task CreateBatchAsync(Batch batch);
        Task UpdateBatchAsync(Batch batch);
        Task DeleteBatchAsync(int id);
        List<Batch> GetAllBatchesIdsAsync();
        Task<int> GetTotalBatchesAsync();
         

    }
}
