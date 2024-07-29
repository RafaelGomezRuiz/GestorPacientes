using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManager.Core.Application.Interfaces.Repositories;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddInfraestrutureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Services
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<IConsultingRoomService, ConsultingRoomService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<ILaboratoryTestService, LaboratoryTestService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<ILaboratoryResultService, LaboratoryResultService>();
            services.AddTransient<IAppointmentService, AppointmentService>();



            #endregion
        }

    }
}
