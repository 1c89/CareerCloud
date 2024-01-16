using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext:DbContext
    {

        //Applicants
        public DbSet<ApplicantEducationPoco> Applicant_Educations { get; set; }
        public DbSet<ApplicantJobApplicationPoco> Applicant_Job_Applications { get; set; }
        public DbSet<ApplicantProfilePoco> Applicant_Profiles { get; set; }
        public DbSet<ApplicantResumePoco> Applicant_Resumes { get; set; }
        public DbSet<ApplicantSkillPoco> Applicant_Skills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> Applicant_Work_History { get; set; }

        //Comapanies
        public DbSet<CompanyDescriptionPoco> Company_Descriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> Company_Job_Educations { get; set; }
        public DbSet<CompanyJobSkillPoco> Company_Job_Skills { get; set; }
        public DbSet<CompanyJobPoco> Company_Jobs { get; set; }
        public DbSet<CompanyJobDescriptionPoco> Company_Jobs_Descriptions { get; set; }
        public DbSet<CompanyLocationPoco> Company_Locations { get; set; }
        public DbSet<CompanyProfilePoco> Company_Profiles { get; set; }

        //Security
        public DbSet<SecurityLoginPoco> Security_Logins { get; set; }
        public DbSet<SecurityLoginsLogPoco> Security_Logins_Log { get; set; }
        public DbSet<SecurityLoginsRolePoco> Security_Logins_Roles { get; set; }
        public DbSet<SecurityRolePoco> Security_Roles { get; set; }

        //System
        public DbSet<SystemCountryCodePoco> System_Country_Codes { get; set; }
        public DbSet<SystemLanguageCodePoco> System_Language_Codes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            var connectionString = configuration.GetConnectionString("DataConnection");
            
            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //-------------------------------------------------------------
            //--------------------------SCHEMA-----------------------------
            //-------------------------------------------------------------

            #region dbSchema

            #region dbSchema.Applicant

            //Applicant_Educations

            modelBuilder.Entity<ApplicantEducationPoco>().HasKey(p => p.Id);

            modelBuilder.Entity<ApplicantEducationPoco>()
                         .Property(p => p.Id)
                         .IsRequired();

            modelBuilder.Entity<ApplicantEducationPoco>()
                        .Property(p => p.Major)
                        .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<ApplicantEducationPoco>()
                        .Property(p => p.CertificateDiploma)
                        .HasMaxLength(100);
            
            modelBuilder.Entity<ApplicantEducationPoco>()
                             .Property(e => e.TimeStamp)
                             .ValueGeneratedOnAddOrUpdate();

            //Applicant_Job_Applications
            modelBuilder.Entity<ApplicantJobApplicationPoco>().HasKey(p => p.Id);

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                         .Property(p => p.Id)
                         .IsRequired();
           
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                             .Property(e => e.TimeStamp)
                             .ValueGeneratedOnAddOrUpdate();

            //Applicant_Profiles
            modelBuilder.Entity<ApplicantProfilePoco>().HasKey(p => p.Id);

            modelBuilder.Entity<ApplicantProfilePoco>()
                         .Property(p => p.Id)
                         .IsRequired();
           
            modelBuilder.Entity<ApplicantProfilePoco>()
                             .Property(e => e.TimeStamp)
                             .ValueGeneratedOnAddOrUpdate();
            
            //Applicant_Resumes
            modelBuilder.Entity<ApplicantResumePoco>().HasKey(p => p.Id);
         
            modelBuilder.Entity<ApplicantResumePoco>()
                         .Property(p => p.Id)
                         .IsRequired();

            
            //Applicant_Skills
            modelBuilder.Entity<ApplicantSkillPoco>().HasKey(p => p.Id);

            modelBuilder.Entity<ApplicantSkillPoco>()
                         .Property(p => p.Id)
                         .IsRequired();
          
            modelBuilder.Entity<ApplicantSkillPoco>()
                             .Property(e => e.TimeStamp)
                             .ValueGeneratedOnAddOrUpdate();

            //Applicant_Work_History
            modelBuilder.Entity<ApplicantWorkHistoryPoco>().HasKey(p => p.Id);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                         .Property(p => p.Id)
                         .IsRequired();
            
            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                              .Property(e => e.TimeStamp)
                              .ValueGeneratedOnAddOrUpdate();
            #endregion

            #region dbSchema.CompanyTables
                       
            
            //Company_Descriptions
            modelBuilder.Entity<CompanyDescriptionPoco>().HasKey(p => p.Id);

            modelBuilder.Entity<CompanyDescriptionPoco>()
                          .Property(p => p.Id)
                          .IsRequired();
           
            modelBuilder.Entity<CompanyDescriptionPoco>()
                           .Property(e => e.TimeStamp)
                           .ValueGeneratedOnAddOrUpdate();

            //Company_Job_Educations
            modelBuilder.Entity<CompanyJobEducationPoco>().HasKey(p => p.Id);
 
            modelBuilder.Entity<CompanyJobEducationPoco>()
                         .Property(p => p.Id)
                         .IsRequired();
            modelBuilder.Entity<CompanyJobEducationPoco>()
                           .Property(e => e.TimeStamp)
                           .ValueGeneratedOnAddOrUpdate();
            //Company_Job_Skills
            modelBuilder.Entity<CompanyJobSkillPoco>().HasKey(p => p.Id);
        
            modelBuilder.Entity<CompanyJobSkillPoco>()
                                 .Property(e => e.TimeStamp)
                                 .ValueGeneratedOnAddOrUpdate();
            //Company_Jobs
            modelBuilder.Entity<CompanyJobPoco>().HasKey(p => p.Id);
         
            modelBuilder.Entity<CompanyJobPoco>()
                           .Property(e => e.TimeStamp)
                           .ValueGeneratedOnAddOrUpdate();
            //Company_Jobs_Descriptions
            modelBuilder.Entity<CompanyJobDescriptionPoco>().HasKey(p => p.Id);
           
            modelBuilder.Entity<CompanyJobDescriptionPoco>()
                           .Property(e => e.TimeStamp)
                           .ValueGeneratedOnAddOrUpdate();

            //Company_Locations
            modelBuilder.Entity<CompanyLocationPoco>().HasKey(p => p.Id);
           
            modelBuilder.Entity<CompanyLocationPoco>()
                            .Property(e => e.TimeStamp)
                            .ValueGeneratedOnAddOrUpdate();
            
            //Company_Profiles
            modelBuilder.Entity<CompanyProfilePoco>().HasKey(p => p.Id);

            modelBuilder.Entity<CompanyProfilePoco>()
                           .Property(e => e.TimeStamp)
                           .ValueGeneratedOnAddOrUpdate();
            #endregion

            #region dbSchema.SecurityTables
            

            //Security_Logins
            modelBuilder.Entity<SecurityLoginPoco>().HasKey(p => p.Id);
            
            modelBuilder.Entity<SecurityLoginPoco>()
                           .Property(e => e.TimeStamp)
                           .ValueGeneratedOnAddOrUpdate();
            //Security_Logins_Log
            modelBuilder.Entity<SecurityLoginsLogPoco>().HasKey(p => p.Id);
            
            //Security_Logins_Roles
            modelBuilder.Entity<SecurityLoginsRolePoco>().HasKey(p => p.Id);
            
            modelBuilder.Entity<SecurityLoginsRolePoco>()
                            .Property(e => e.TimeStamp)
                            .ValueGeneratedOnAddOrUpdate();

            //Security_Roles
            modelBuilder.Entity<SecurityRolePoco>().HasKey(p => p.Id);

            #endregion

            #region dbSchema.SystemTables
            //System_Country_Codes
            modelBuilder.Entity<SystemCountryCodePoco>().HasKey(p => p.Code);

            //System_Language_Codes
            modelBuilder.Entity<SystemLanguageCodePoco>().HasKey(p => p.LanguageID);

            #endregion

            #endregion

            //-------------------------------------------------------------
            //--------------------------RELATIONSHIPS----------------------
            //-------------------------------------------------------------

            #region Relations

            #region Relations.Company
            //Company
            modelBuilder.Entity<CompanyDescriptionPoco>()
                        .HasOne<SystemLanguageCodePoco>(cd => cd.SystemLanguageCode)
                        .WithMany(sl => sl.CompanyDescriptions)
                        .HasForeignKey(cd => cd.LanguageId);

            modelBuilder.Entity<CompanyLocationPoco>()
                        .HasOne<CompanyProfilePoco>(cl => cl.CompanyProfile)
                        .WithMany(cp => cp.CompanyLocations)
                        .HasForeignKey(cl => cl.Company);
         
            modelBuilder.Entity<CompanyLocationPoco>()
                           .HasOne<SystemCountryCodePoco>(scc => scc.SystemCountryCode)
                           .WithMany(cl => cl.CompanyLocations)
                           .HasForeignKey(scc => scc.CountryCode);

            modelBuilder.Entity<CompanyProfilePoco>()
                        .HasMany<CompanyDescriptionPoco>(cp => cp.CompanyDescriptions)
                        .WithOne(cd => cd.CompanyProfile)
                        .HasForeignKey(cd => cd.Company);

            modelBuilder.Entity<CompanyJobPoco>()
                        .HasMany<CompanyJobEducationPoco>(cj => cj.CompanyJobEducations)
                        .WithOne(cje => cje.CompanyJob)
                        .HasForeignKey(cje => cje.Job);

            modelBuilder.Entity<CompanyJobDescriptionPoco>()
                        .HasOne<CompanyJobPoco>(cjd => cjd.CompanyJob)
                        .WithMany(cj => cj.CompanyJobDescriptions)
                        .HasForeignKey(cjd => cjd.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                        .HasOne<CompanyProfilePoco>(cj => cj.CompanyProfile)
                        .WithMany(cp => cp.CompanyJobs)
                        .HasForeignKey(cj => cj.Company);

            modelBuilder.Entity<CompanyJobPoco>()
                        .HasMany<CompanyJobSkillPoco>(cj => cj.CompanyJobSkills)
                        .WithOne(cjs => cjs.CompanyJob)
                        .HasForeignKey(cjs => cjs.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                        .HasMany<ApplicantJobApplicationPoco>(cj => cj.ApplicantJobApplications)
                        .WithOne(ajap => ajap.CompanyJob)
                        .HasForeignKey(ajap => ajap.Job);

            #endregion

            #region Relations.Applicant
            //Applicant
            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                        .HasOne<ApplicantProfilePoco>(ajap => ajap.ApplicantProfile)
                        .WithMany(ap => ap.ApplicantJobApplications)
                        .HasForeignKey(ajap => ajap.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                        .HasMany<ApplicantSkillPoco>(asp => asp.ApplicantSkills)
                        .WithOne(ap => ap.ApplicantProfile)
                        .HasForeignKey(asp => asp.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                        .HasMany<ApplicantWorkHistoryPoco>(awh => awh.ApplicantWorkHistorys)
                        .WithOne(ap => ap.ApplicantProfile)
                        .HasForeignKey(awh => awh.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                         .HasMany<ApplicantResumePoco>(ar => ar.ApplicantResumes)
                         .WithOne(ap => ap.ApplicantProfile)
                         .HasForeignKey(ar => ar.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                         .HasMany<ApplicantEducationPoco>(ap => ap.ApplicantEducations)
                         .WithOne(ae => ae.ApplicantProfile)
                         .HasForeignKey(ae => ae.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                         .HasOne<SecurityLoginPoco>(ap => ap.SecurityLogins)
                         .WithMany(sl => sl.ApplicantProfiles)
                         .HasForeignKey(ap => ap.Login);
          
            modelBuilder.Entity<ApplicantProfilePoco>()
                         .HasOne<SystemCountryCodePoco>(ap => ap.SystemCountryCode)
                         .WithMany(scc => scc.ApplicantProfiles)
                         .HasForeignKey(ap => ap.Country);

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                         .HasOne<SystemCountryCodePoco>(awh => awh.SystemCountryCode)
                         .WithMany(scc => scc.ApplicantWorkHistory)
                         .HasForeignKey(awh => awh.CountryCode);
            #endregion

            #region Relations.Security

            //Security
            modelBuilder.Entity<SecurityRolePoco>()
                      .HasMany<SecurityLoginsRolePoco>(slr => slr.SecurityLoginsRoles)
                      .WithOne(sr => sr.SecurityRole)
                      .HasForeignKey(sr => sr.Role);

            modelBuilder.Entity<SecurityRolePoco>()
                      .HasMany<SecurityLoginsRolePoco>(slr => slr.SecurityLoginsRoles)
                      .WithOne(sr => sr.SecurityRole)
                      .HasForeignKey(sr => sr.Role);

            modelBuilder.Entity<SecurityLoginPoco>()
                      .HasMany<SecurityLoginsLogPoco>(sl => sl.SecurityLoginsLogs)
                      .WithOne(sll => sll.SecurityLogin)
                      .HasForeignKey(sll => sll.Login);

            modelBuilder.Entity<SecurityLoginPoco>()
                      .HasMany<SecurityLoginsRolePoco>(sl => sl.SecurityLoginsRoles)
                      .WithOne(slr => slr.SecurityLogin)
                      .HasForeignKey(slr => slr.Login);
            #endregion

            #endregion
        }

    }
}