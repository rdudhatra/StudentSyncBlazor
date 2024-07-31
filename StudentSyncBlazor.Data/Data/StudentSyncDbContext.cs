using Microsoft.EntityFrameworkCore;
using StudentSyncBlazor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSyncBlazor.Data.Data
{
    public class StudentSyncDbContext : DbContext
    {

        public StudentSyncDbContext(DbContextOptions<StudentSyncDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Batch> Batches { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<CourseExam> CourseExams { get; set; }

        public virtual DbSet<CourseFee> CourseFees { get; set; }

        public virtual DbSet<CourseSyllabus> CourseSyllabi { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Enrollment> Enrollments { get; set; }

        public virtual DbSet<Inquiry> Inquiries { get; set; }

        public virtual DbSet<InquiryFollowUp> InquiryFollowUps { get; set; }

        public virtual DbSet<StudentAssessment> StudentAssessments { get; set; }

        public virtual DbSet<StudentAttendance> StudentAttendances { get; set; }

        public virtual DbSet<StudentInstallment> StudentInstallments { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserLogin> UserLogins { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .Property(u => u.Id)
               .ValueGeneratedOnAdd();
            // .HasKey(u => u.Id) // Ensure the key type is string


        }

        //Student Assessment sp

        // Save method
        public async Task SaveStudentAssessment(StudentAssessment studentAssessment)
        {
            try
            {
                await Database.ExecuteSqlRawAsync(
                    "EXEC dbo.CreateStudentAssessments @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8",
                    studentAssessment.AssessmentDate, studentAssessment.EnrollmentNo, studentAssessment.CourseExamId,
                    studentAssessment.ObtainedMarks, studentAssessment.Remarks, studentAssessment.CreatedBy,
                    studentAssessment.CreatedDate, studentAssessment.UpdatedBy, studentAssessment.UpdatedDate);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception("Error saving student assessment.", ex);
            }
        }
        // Update method

        public async Task UpdateStudentAssessment(StudentAssessment studentAssessment)
        {
            try
            {

                await Database.ExecuteSqlRawAsync("EXEC dbo.UpdateStudentAssessment @p0, @p1, @p2, @p3, @p4, @p5, @p6 , @p7",
                       studentAssessment.Id, studentAssessment.AssessmentDate, studentAssessment.EnrollmentNo, studentAssessment.CourseExamId,
                        studentAssessment.ObtainedMarks, studentAssessment.Remarks, studentAssessment?.UpdatedBy, studentAssessment?.UpdatedDate);

            }
            catch (Exception ex)
            {
                throw new Exception("Error saving update assessment.", ex);

            }
        }

        // Delete method
        public async Task DeleteStudentAssessment(int studentAssessmentId)
        {
            await Database.ExecuteSqlRawAsync($"EXEC dbo.DeleteStudentAssessments {studentAssessmentId}");
        }

        // GetAll method
        public async Task<List<StudentAssessment>> GetAllStudentAssessments()
        {
            return await StudentAssessments.ToListAsync(); // Ensure this returns data correctly
        }
        // GetById method
        public async Task<StudentAssessment> GetStudentAssessmentById(int id)
        {
            var studentAssessments = await StudentAssessments
                .FromSqlRaw("EXEC dbo.GetStudentAssessmentsById @p0", id)
                .AsNoTracking()
                .ToListAsync();

            return studentAssessments.FirstOrDefault();
        }
    }




}
