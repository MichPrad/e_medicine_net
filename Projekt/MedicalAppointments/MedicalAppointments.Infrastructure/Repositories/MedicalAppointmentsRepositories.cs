namespace MedicalAppointments.Infrastructure.Repositories
{
    using Dapper;
    using MedicalAppointments.Domain;
    using MedicalAppointments.Domain.Services;
    using MedicalAppointments.Domain.Template;
    using Prescription.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class MedicalAppointmentsRepositories : IMedicalAppointmentsRepository
    {
        public string connString;

        public MedicalAppointmentsRepositories() 
        {
            string Server = Environment.GetEnvironmentVariable("Server");
            string Database = Environment.GetEnvironmentVariable("Database");
            string User = Environment.GetEnvironmentVariable("User");
            string Password = Environment.GetEnvironmentVariable("Password");

            connString = $@"Server={Server};Database={Database};User={User};Password={Password}";
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            const string getAddedRowIdQueryQuery = @"SELECT CAST(SCOPE_IDENTITY() as int)";

            using (var dbConnection = new SqlConnection(connString))
            {

                string name = appointment.Place.Name;

                string doesPlaceExist = $@"SELECT * FROM Places P WHERE P.Name ='{name}'";

                var places = await dbConnection.QueryAsync<Place>(doesPlaceExist);


                int placeId = 0;

                if (places.Count() != 0)
                {
                    placeId = places.First().Id;
                }


                dbConnection.Open();

                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {

                        const string insertAppointmentQuery = @"INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit,EndDateOfTheVisit) VALUES (@idDoctor,@idPatient,@startDateOfTheVisit,@endDateOfTheVisit);";

                        int appointmentId = await dbConnection.QueryFirstAsync<int>(insertAppointmentQuery + ";" + getAddedRowIdQueryQuery, new { idDoctor = appointment.IdDoctor, idPatient = appointment.IdPatient, startdateOfTheVisit = appointment.StartDateOfTheVisit, endDateOfTheVisit = appointment.EndDateOfTheVisit }, transaction);


                        if (placeId == 0)
                        {
                            const string insertPlaceQuery = @"INSERT INTO Places (Name, Street, HouseNumber, Town) VALUES (@name,@street,@houseNumber,@town);";
                            placeId = await dbConnection.QueryFirstAsync<int>(insertPlaceQuery + ";" + getAddedRowIdQueryQuery, new { name = appointment.Place.Name, street = appointment.Place.Street, houseNumber = appointment.Place.HouseNumber, town = appointment.Place.Town }, transaction);
                        }



                        const string insertAppointmentPlaceQuery = @"INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (@appointmentId,@placeId);";

                        await dbConnection.QueryAsync(insertAppointmentPlaceQuery, new { appointmentId = appointmentId, placeId = placeId }, transaction);

                        transaction.Commit();

                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {

            using (var dbConnection = new SqlConnection(connString))
            {

                const string selectAppointmentPlaceQuery = @"SELECT * FROM AppointmentPlace";

                var appointmentPlaces = (await dbConnection.QueryAsync(selectAppointmentPlaceQuery)).Select(x => new { AppointmentId = x.AppointmentId, PlaceId = x.PlaceId });

                const string selectAppointmentsQuery = @"SELECT * FROM Appointments";

                var appointments = await dbConnection.QueryAsync<Appointment>(selectAppointmentsQuery);

                const string selecPlacesQuery = @"SELECT * FROM Places";

                var places = await dbConnection.QueryAsync<Place>(selecPlacesQuery);

                foreach (var appointment in appointments)
                {
                    var placeIdForAppointment = appointmentPlaces.Where(x => x.AppointmentId == appointment.Id).Select(x => x.PlaceId);
                    var placeForAppointment = places.Where(x => placeIdForAppointment.Contains(x.Id));

                    foreach (var place in placeForAppointment)
                    {
                        appointment.AddPlace(place);
                    }
                }

                return appointments;
            }
        }

        public async Task DeleteAppointmentAsync(int appointmentId)
        {
            using (var dbConnection = new SqlConnection(connString))
            {
                dbConnection.Open();
                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        string deleteQuery = $@"DELETE FROM Appointments  WHERE Id = {appointmentId}";
                        await dbConnection.ExecuteAsync(deleteQuery, transaction: transaction);
                        transaction.Commit();

                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        public async Task<IEnumerable<Appointment>> GetAllDoctorAppointmentsAsync(int idDoctor)
        {
            using (var dbConnection = new SqlConnection(connString))
            {


                string selectAppointmentsQuery = $@"SELECT * FROM Appointments A WHERE A.IdDoctor ={idDoctor} AND month (StartDateOfTheVisit) - month(getdate()) <=1";


                var appointments = await dbConnection.QueryAsync<Appointment>(selectAppointmentsQuery);

                const string selectAppointmentPlaceQuery = @"SELECT * FROM AppointmentPlace";

                var appointmentPlaces = (await dbConnection.QueryAsync(selectAppointmentPlaceQuery)).Select(x => new { AppointmentId = x.AppointmentId, PlaceId = x.PlaceId });


                const string selecPlacesQuery = @"SELECT * FROM Places";

                var places = await dbConnection.QueryAsync<Place>(selecPlacesQuery);



                foreach (var appointment in appointments)
                {
                    var placeIdForAppointment = appointmentPlaces.Where(x => x.AppointmentId == appointment.Id).Select(x => x.PlaceId);
                    var placeForAppointment = places.Where(x => placeIdForAppointment.Contains(x.Id));

                    foreach (var place in placeForAppointment)
                    {
                        appointment.AddPlace(place);
                    }
                }

                return appointments;

            }
        }


        public async Task<IEnumerable<Appointment>> GetTodaysDoctorAppointmentsAsync(int idDoctor)
        {
            using (var dbConnection = new SqlConnection(connString))
            {


                string selectAppointmentsQuery = $@"SELECT * FROM Appointments A WHERE A.IdDoctor ={idDoctor}AND A.StartDateOfTheVisit > getdate()-1 AND A.StartDateOfTheVisit < getdate()+1 AND DAY(A.StartDateOfTheVisit) = DAY(getdate())";


                var appointments = await dbConnection.QueryAsync<Appointment>(selectAppointmentsQuery);


                const string selectAppointmentPlaceQuery = @"SELECT * FROM AppointmentPlace";

                var appointmentPlaces = (await dbConnection.QueryAsync(selectAppointmentPlaceQuery)).Select(x => new { AppointmentId = x.AppointmentId, PlaceId = x.PlaceId });


                const string selecPlacesQuery = @"SELECT * FROM Places";

                var places = await dbConnection.QueryAsync<Place>(selecPlacesQuery);



                foreach (var appointment in appointments)
                {
                    var placeIdForAppointment = appointmentPlaces.Where(x => x.AppointmentId == appointment.Id).Select(x => x.PlaceId);
                    var placeForAppointment = places.Where(x => placeIdForAppointment.Contains(x.Id));

                    foreach (var place in placeForAppointment)
                    {
                        appointment.AddPlace(place);
                    }
                }

                return appointments;
            }
        }


        public async Task<IEnumerable<Appointment>> GetClosestAppointmentsAsync(int idPatient)
        {
            using (var dbConnection = new SqlConnection(connString))
            {


                string selectAppointmentsQuery = $@"SELECT * FROM Appointments A WHERE A.IdPatient ={idPatient} AND A.StartDateOfTheVisit >= getdate()-1 AND A.StartDateOfTheVisit <= getdate()+14";


                var appointments = await dbConnection.QueryAsync<Appointment>(selectAppointmentsQuery);


                const string selectAppointmentPlaceQuery = @"SELECT * FROM AppointmentPlace";

                var appointmentPlaces = (await dbConnection.QueryAsync(selectAppointmentPlaceQuery)).Select(x => new { AppointmentId = x.AppointmentId, PlaceId = x.PlaceId });


                const string selecPlacesQuery = @"SELECT * FROM Places";

                var places = await dbConnection.QueryAsync<Place>(selecPlacesQuery);



                foreach (var appointment in appointments)
                {
                    var placeIdForAppointment = appointmentPlaces.Where(x => x.AppointmentId == appointment.Id).Select(x => x.PlaceId);
                    var placeForAppointment = places.Where(x => placeIdForAppointment.Contains(x.Id));

                    foreach (var place in placeForAppointment)
                    {
                        appointment.AddPlace(place);
                    }
                }

                return appointments;
            }
        }

        public async Task<IEnumerable<Appointment>> GetAllPatientAppointmentsAsync(int idPatient)
        {
            using (var dbConnection = new SqlConnection(connString))
            {


                string selectAppointmentsQuery = $@"SELECT * FROM Appointments A WHERE A.IdPatient ={idPatient} ";

                var appointments = await dbConnection.QueryAsync<Appointment>(selectAppointmentsQuery);


                const string selectAppointmentPlaceQuery = @"SELECT * FROM AppointmentPlace";

                var appointmentPlaces = (await dbConnection.QueryAsync(selectAppointmentPlaceQuery)).Select(x => new { AppointmentId = x.AppointmentId, PlaceId = x.PlaceId });


                const string selecPlacesQuery = @"SELECT * FROM Places";

                var places = await dbConnection.QueryAsync<Place>(selecPlacesQuery);



                foreach (var appointment in appointments)
                {
                    var placeIdForAppointment = appointmentPlaces.Where(x => x.AppointmentId == appointment.Id).Select(x => x.PlaceId);
                    var placeForAppointment = places.Where(x => placeIdForAppointment.Contains(x.Id));

                    foreach (var place in placeForAppointment)
                    {
                        appointment.AddPlace(place);
                    }
                }

                return appointments;

            }
        }

    }
}
