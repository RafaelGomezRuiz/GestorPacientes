using Microsoft.EntityFrameworkCore;
using PatientManager.Core.Domain.Entities;
using StockApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PatientManager.Infraestructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext( DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<ConsultingRoom> ConsultingRooms { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<LaboratoryResult> LaboratoryResults { get; set; }
        public DbSet<LaboratoryTest> LaboratoryTests { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created =DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultUser";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            #region Tables
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<ConsultingRoom>().ToTable("ConsultingRooms");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<LaboratoryTest>().ToTable("LaboratoryTests");
            modelBuilder.Entity<LaboratoryResult>().ToTable("LaboratoryResults");
            #endregion

            #region PrimaryKeys
            modelBuilder.Entity<User>().HasKey(user=>user.Id);
            modelBuilder.Entity<Doctor>().HasKey(doctor => doctor.Id);
            modelBuilder.Entity<ConsultingRoom>().HasKey(consultingRoom => consultingRoom.Id);
            modelBuilder.Entity<Patient>().HasKey(patient => patient.Id);
            modelBuilder.Entity<Appointment>().HasKey(appointment => appointment.Id);
            modelBuilder.Entity<LaboratoryTest>().HasKey(laboratoryTest => laboratoryTest.Id);
            modelBuilder.Entity<LaboratoryResult>().HasKey(laboratoryResult => laboratoryResult.Id);
            #endregion

            #region Relationships
            modelBuilder.Entity<ConsultingRoom>()
                .HasMany<User>(consultingRoom => consultingRoom.Users)
                .WithOne(user => user.ConsultingRoom)
                .HasForeignKey(user => user.ConsultingRoomId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<ConsultingRoom>()
                .HasMany<Doctor>(consultingRoom => consultingRoom.Doctors)
                .WithOne(doctor => doctor.ConsultingRoom)
                .HasForeignKey(doctor => doctor.ConsultingRoomId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ConsultingRoom>()
           .HasMany<LaboratoryTest>(consultingRoom => consultingRoom.LaboratoryTests)
           .WithOne(LaboratoryT => LaboratoryT.ConsultingRoom)
           .HasForeignKey(LaboratoryT => LaboratoryT.ConsultingRoomId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ConsultingRoom>()
            .HasMany<Patient>(consultingRoom => consultingRoom.Patients)
            .WithOne(patient => patient.ConsultingRoom)
            .HasForeignKey(patient => patient.ConsultingRoomId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ConsultingRoom>()
           .HasMany<Patient>(consultingRoom => consultingRoom.Patients)
           .WithOne(patient => patient.ConsultingRoom)
           .HasForeignKey(patient => patient.ConsultingRoomId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LaboratoryTest>()
           .HasMany<LaboratoryResult>(LabT => LabT.LaboratoryResults)
           .WithOne(LabR => LabR.LaboratoryTest)
           .HasForeignKey(LabR => LabR.LaboratoryTestId)
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Patient>()
           .HasMany<Appointment>(patient => patient.Appointments)
           .WithOne(appointment => appointment.Patient)
           .HasForeignKey(appointment => appointment.PatientId)
           .OnDelete(DeleteBehavior.NoAction);

            //docotor a appointment
            modelBuilder.Entity<Doctor>()
           .HasMany<Appointment>(doctor => doctor.Appointments)
           .WithOne(appointment => appointment.Doctor)
           .HasForeignKey(appointment => appointment.DoctorId)
           .OnDelete(DeleteBehavior.NoAction);

            //LaboratoryResult a appointment
            modelBuilder.Entity<Appointment>()
           .HasMany<LaboratoryResult>(appointment => appointment.LaboratoryResults)
           .WithOne(LabR => LabR.Appointment)
           .HasForeignKey(LabR => LabR.AppointmentId)
           .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Properties
            #region User
            modelBuilder.Entity<User>()
                .Property(user => user.Name).IsRequired().HasMaxLength(100);
                modelBuilder.Entity<User>()
                .Property(user => user.LastName).IsRequired().HasMaxLength(100);
                modelBuilder.Entity<User>()
                .Property(user => user.Email).IsRequired().HasMaxLength(100);
                modelBuilder.Entity<User>()
                .Property(user => user.UserName).IsRequired().HasMaxLength(100);
                modelBuilder.Entity<User>()
                .Property(user => user.Password).IsRequired().HasMaxLength(100);
                modelBuilder.Entity<User>()
                .Property(user => user.UserType).IsRequired().HasMaxLength(10);
                modelBuilder.Entity<User>()
                .Property(user => user.ConsultingRoomId).IsRequired();
            #endregion
                #region Doctor
                modelBuilder.Entity<Doctor>()
                .Property(doctor => doctor.Name).IsRequired().HasMaxLength(100);
                modelBuilder.Entity<Doctor>()
                .Property(doctor => doctor.LastName).IsRequired().HasMaxLength(100);
                modelBuilder.Entity<Doctor>()
                .Property(doctor => doctor.Email).IsRequired().HasMaxLength(100);
                modelBuilder.Entity<Doctor>()
                .Property(doctor => doctor.PhoneNumber).IsRequired().HasMaxLength(20);
                modelBuilder.Entity<Doctor>()
                .Property(doctor => doctor.IdCard).IsRequired().HasMaxLength(25);
                modelBuilder.Entity<Doctor>()
                .Property(doctor => doctor.Photo);
            #endregion
            #region ConsultingRoom
            modelBuilder.Entity<ConsultingRoom>()
            .Property(consultingRoom => consultingRoom.Name).IsRequired().HasMaxLength(100);
            
            #endregion

            #endregion
        }
    }
}
