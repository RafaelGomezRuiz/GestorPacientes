using AutoMapper;
using PatientManager.Core.Application.Enums;
using PatientManager.Core.Application.ViewModels.Appointment;
using PatientManager.Core.Application.ViewModels.ConsultingRoom;
using PatientManager.Core.Application.ViewModels.Doctor;
using PatientManager.Core.Application.ViewModels.LaboratoryResult;
using PatientManager.Core.Application.ViewModels.LaboratoryTest;
using PatientManager.Core.Application.ViewModels.Patient;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Domain.Entities;

namespace PatientManager.Core.Application.Mappings
{
    public class GeneralProfile :Profile
    {
        public GeneralProfile()
        {
            CreateMap<User, UserViewModel>()
                .ReverseMap()
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<User, SaveUserViewModel>()
                .ForMember(destino=>destino.ConfirmPassword, otp => otp.Ignore())
                .ForMember(destino => destino.ConsultingRoomName, otp => otp.Ignore())
                .ReverseMap()
                .ForMember(destino => destino.ConsultingRoom, otp => otp.Ignore())
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<ConsultingRoom, ConsultingRoomViewModel>()
                .ReverseMap()
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<ConsultingRoom, SaveConsultingRoomViewModel>()
                .ReverseMap()
                .ForMember(destino => destino.Users, otp => otp.Ignore())
                .ForMember(destino => destino.Doctors, otp => otp.Ignore())
                .ForMember(destino => destino.LaboratoryTests, otp => otp.Ignore())
                .ForMember(destino => destino.Patients, otp => otp.Ignore())
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());
            
            CreateMap<Doctor, DoctorViewModel>()
                .ReverseMap()
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<Doctor, SaveDoctorViewModel>()
                .ForMember(destino => destino.File, otp => otp.Ignore())
                .ReverseMap()
                .ForMember(destino => destino.ConsultingRoom, otp => otp.Ignore())
                .ForMember(destino => destino.Appointments, otp => otp.Ignore())
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<LaboratoryTest, LaboratoryTestViewModel>()
                .ReverseMap()
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<LaboratoryTest, SaveLaboratoryTestViewModel>()
                .ReverseMap()
                .ForMember(destino => destino.ConsultingRoom, otp => otp.Ignore())
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<LaboratoryResult, LaboratoryResultViewModel>()
                .ForMember(destino => destino.PatientName, otp => otp.Ignore())
                .ForMember(destino => destino.IdCard, otp => otp.Ignore())
                .ForMember(destino => destino.TestName, otp => otp.Ignore())

                .ReverseMap()
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<LaboratoryResult, SaveLaboratoryResultViewModel>()
                .ReverseMap()
                .ForMember(destino => destino.Appointment, otp => otp.Ignore())
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<Patient, PatientViewModel>()
                .ReverseMap()
                .ForMember(destino => destino.Appointments, otp => otp.Ignore())
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<Patient, SavePatientViewModel>()
                .ForMember(destino => destino.File, otp => otp.Ignore())
                .ReverseMap()
                .ForMember(destino => destino.ConsultingRoom, otp => otp.Ignore())
                .ForMember(destino => destino.LaboratoryResults, otp => otp.Ignore())
                .ForMember(destino => destino.Appointments, otp => otp.Ignore())
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<Appointment, AppointmentViewModel>()
                .ForMember(destino => destino.PatientName, otp => otp.Ignore())
                .ForMember(destino => destino.DoctorName, otp => otp.Ignore())

                .ReverseMap()
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());

            CreateMap<Appointment, SaveAppointmentViewModel>()
                .ForMember(destino => destino.Patients, otp => otp.Ignore())
                .ForMember(destino => destino.Doctors, otp => otp.Ignore())
                .ForMember(destino => destino.LaboratoryTestIds, otp => otp.Ignore())

                .ReverseMap()
                .ForMember(destino => destino.LaboratoryResults, otp => otp.Ignore())
                .ForMember(destino => destino.ConsultingRoom, otp => otp.Ignore())
                .ForMember(destino => destino.Patient, otp => otp.Ignore())
                .ForMember(destino => destino.Doctor, otp => otp.Ignore())
                .ForMember(destino => destino.Created, otp => otp.Ignore())
                .ForMember(destino => destino.CreatedBy, otp => otp.Ignore())
                .ForMember(destino => destino.LastModified, otp => otp.Ignore())
                .ForMember(destino => destino.LastModifiedBy, otp => otp.Ignore());
        }
    }
}
