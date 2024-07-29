using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.Services;
using PatientManager.Core.Domain.Entities;
using PatientManager.Infraestructure.Persistence.Context;
using PatientManager.Infraestructure.Persistence.Repositories;

namespace PatientManager.Infraestructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services,IConfiguration configuration)
        {
            #region DbContext
            if (configuration.GetValue<bool>("UseIUnMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("PatientManagerInMemory"));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<ApplicationContext>(options =>
                                            options.UseSqlServer(connectionString, a => a.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region
                services.AddTransient<IUserRepository, UserRepository>();
                services.AddTransient<IConsultingRoomRepository, ConsultingRoomRepository>();
                services.AddTransient<IDoctorRepository, DoctorRepository>();
                services.AddTransient<ILaboratoryTestRepository, LaboratoryTestRepository>();
                services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<ILaboratoryResultRepository, LaboratoryResultPepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();

            #endregion
        }
    }
}
