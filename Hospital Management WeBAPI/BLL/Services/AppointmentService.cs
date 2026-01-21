using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AppointmentService
    {
        DataAccessFactory factory;
        public AppointmentService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<AppointmentDTO> GetAllAppointments()
        {
            foreach (var app in factory.AppointmentData().GetAll())
            {
                AutoUpdateStatus(app.AppointmentId);
            }
            var data = factory.AppointmentData().GetAll();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<AppointmentDTO>>(data);
        }
        public AppointmentDTO Get(int id)

        {
            AutoUpdateStatus(id);
            var data = factory.AppointmentData().Get(id);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<AppointmentDTO>(data);
        }
        public bool Create(AppointmentDTO dto)
        {
           
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Appointment>(dto);
            return factory.AppointmentData().Create(data);


        }
        public bool Update(AppointmentDTO dto)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Appointment>(dto);
            return factory.AppointmentData().Update(data);

        }
        public bool Delete(int id)
        {
            return factory.AppointmentData().Delete(id);
        }
        public List<Patient> AdvanceFilter (int? doctorId, int? patientId, string? status)
        {
            var data = factory.AppointmentFeature().FilterBy(doctorId, patientId, status);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<Patient>>(data);
        }
        public bool Cancel(int id)
        {
            var appStatus = factory.AppointmentData().Get(id);

            if (appStatus == null)
            {return false;}

            appStatus.Status = "Cancelled";
            return factory.AppointmentData().Update(appStatus);
        }
        public bool Confirm(int id)
        {
            var appStatus = factory.AppointmentData().Get(id);

            if (appStatus == null)
            { return false; }

            appStatus.Status = "Confirmed";
            return factory.AppointmentData().Update(appStatus);
        }
        public bool AutoUpdateStatus(int id)
        {
           
            var appStatus = factory.AppointmentData().Get(id);
            if (appStatus == null) return false;

            DateTime appointmentDateTime = appStatus.AppointmentDate.ToDateTime(TimeOnly.Parse(appStatus.Time));

            if (DateTime.Now >= appointmentDateTime && appStatus.Status == "Confirmed")
               
            {
                appStatus.Status = "Completed";
                factory.AppointmentData().Update(appStatus);
                return true;
            }

            return false;
        }
        public string GetAppointmentAlertForPatient(int id)
        {
            var appointment = factory.AppointmentData().Get(id);
            if (appointment == null)
            
                return " Appointment not found";
            

            var now = DateTime.Now;
            string alert;

            if (appointment.Status == "Confirmed")
                
            {
                var AppTime = appointment.AppointmentDate.ToDateTime(TimeOnly.Parse(appointment.Time));
                var timeLeft =  AppTime- now;

                if (timeLeft.TotalMinutes <= 0)
                {
                    alert = "Your appointment time has passed";
                }
                else if (timeLeft.TotalMinutes <= 30)
                {
                    alert = "Your appointment starts in 30 minutes";
                }
                else if (timeLeft.TotalHours <= 24)
                {
                    alert = "Your appointment is tomorrow at" +AppTime;
                }
                else
                {
                    alert = " Appointment confirmed";
                }
            }
            else if (appointment.Status == "Pending")
            {
                alert = "Your appointment is waiting for confirmation";
            }
            else if (appointment.Status == "Cancelled")
            {
                alert = "This appointment has been cancelled. You can book again.";
            }
            else
            {
                alert = "Appointment status unknown";
            }

            return alert;
        }

    }
}
