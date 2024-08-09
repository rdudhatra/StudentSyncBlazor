using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentSyncBlazor.Core.Services.Interface;
using System.Security.Claims; 
using StudentSyncBlazor.Data.Data;
using StudentSyncBlazor.Data.Models;
using StudentSyncBlazor.Data.ResponseModel;

namespace StudentSync.Core.Services
{
    public class CourseFeeService : ICourseFeeService
    {
        private readonly StudentSyncDbContext _context;



        public CourseFeeService(StudentSyncDbContext context)
        {
            _context = context;
        }

        public List<CourseFee> GetAllCourseExamIds()
        {
            return _context.CourseFees.ToList();
        }


        public async Task<List<CourseFeeResponseModel>> GetAllCourseFeesAsync()
        {
            var courseFees = await _context.CourseFees
           .Select(courseFee => new CourseFeeResponseModel
                 {

                     Id = courseFee.Id,
                     TotalFees = courseFee.TotalFees,
                     DownPayment = courseFee.DownPayment,
                     NoofInstallment = courseFee.NoofInstallment,
                     InstallmentAmount = courseFee.InstallmentAmount,
                     Remarks = courseFee.Remarks,
                 
                 })
           .ToListAsync();

            return courseFees;
        }
        public async Task<CourseFee> GetCourseFeeByIdAsync(int id)
        {
            return await _context.CourseFees.FindAsync(id);
        }

        public async Task<int> AddCourseFeeAsync(CourseFee courseFee)
        {
            courseFee.CreatedDate = DateTime.UtcNow;
            _context.CourseFees.Add(courseFee);
            await _context.SaveChangesAsync();
            return courseFee.Id;
        }

            public async Task<int> UpdateCourseFeeAsync(CourseFee courseFee)
            {
                var existingCourseFee = await _context.CourseFees.FindAsync(courseFee.Id);
                if (existingCourseFee == null)
                    throw new ArgumentException("Course Fee not found");

                existingCourseFee.CourseId = courseFee.CourseId;
                existingCourseFee.TotalFees = courseFee.TotalFees;
                existingCourseFee.DownPayment = courseFee.DownPayment;
                existingCourseFee.NoofInstallment = courseFee.NoofInstallment;
                existingCourseFee.InstallmentAmount = courseFee.InstallmentAmount;
                existingCourseFee.Remarks = courseFee.Remarks;
                existingCourseFee.UpdatedBy = courseFee.UpdatedBy;
                existingCourseFee.UpdatedDate = DateTime.UtcNow;

                _context.CourseFees.Update(existingCourseFee);
                await _context.SaveChangesAsync();
                return existingCourseFee.Id;
            }

        public async Task<bool> DeleteCourseFeeAsync(int id)
        {
            var courseFee = await _context.CourseFees.FindAsync(id);
            if (courseFee == null)
            {
                throw new ArgumentException("Course Fee not found");
            }
            _context.CourseFees.Remove(courseFee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetTotalCourseFeesAsync()
        {
            return await _context.CourseFees.CountAsync(); // Assuming Amount is a property in CourseFees
        }
    }
}
