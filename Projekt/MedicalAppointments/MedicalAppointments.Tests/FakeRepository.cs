namespace MedicalAppointments.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MedicalAppointments.Domain;

    public class FakeRepository
    {
        public IEnumerable<Appointment> appointments;

        public FakeRepository()
        {
            this.appointments = new List<Appointment>
            {
                new Appointment(1, 1, 1, DateTime.Now, DateTime.Now, new Place(1, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
                new Appointment(2, 1, 2, DateTime.Now, DateTime.Now, new Place(2, "Gdanski Osrodek", "Schuberta", "68", "Gdansk")),
                new Appointment(3, 2, 1, DateTime.Now, DateTime.Now, new Place(1, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
                new Appointment(4, 1, 3, DateTime.Now, DateTime.Now, new Place(3, "Wroclawski Osrodek", "Tamka", "112", "Wroclaw")),
                new Appointment(5, 2, 3, DateTime.Now, DateTime.Now, new Place(1, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
                new Appointment(6, 1, 1, DateTime.Now, DateTime.Now, new Place(4, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
                new Appointment(7, 1, 2, DateTime.Now, DateTime.Now, new Place(5, "Gdanski Osrodek", "Schuberta", "68", "Gdansk")),
                new Appointment(8, 2, 1, DateTime.Now, DateTime.Now, new Place(6, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
                new Appointment(9, 1, 3, DateTime.Now, DateTime.Now, new Place(7, "Wroclawski Osrodek", "Tamka", "112", "Wroclaw")),
                new Appointment(10, 2, 3, DateTime.Now, DateTime.Now, new Place(8, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
                new Appointment(11, 1, 1, DateTime.Now, DateTime.Now, new Place(9, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
                new Appointment(12, 1, 2, DateTime.Now, DateTime.Now, new Place(10, "Gdanski Osrodek", "Schuberta", "68", "Gdansk")),
                new Appointment(13, 2, 1, DateTime.Now, DateTime.Now, new Place(11, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
                new Appointment(14, 1, 3, DateTime.Now, DateTime.Now, new Place(12, "Wroclawski Osrodek", "Tamka", "112", "Wroclaw")),
                new Appointment(15, 2, 3, DateTime.Now, DateTime.Now, new Place(13, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
                new Appointment(16, 1, 1, DateTime.Now, DateTime.Now, new Place(14, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
                new Appointment(17, 1, 2, DateTime.Now, DateTime.Now, new Place(15, "Gdanski Osrodek", "Schuberta", "68", "Gdansk")),
                new Appointment(18, 2, 1, DateTime.Now, DateTime.Now, new Place(16, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
                new Appointment(19, 1, 3, DateTime.Now, DateTime.Now, new Place(17, "Wroclawski Osrodek", "Tamka", "112", "Wroclaw")),
                new Appointment(20, 2, 3, DateTime.Now, DateTime.Now, new Place(18, "Warszawski Osrodek", "Chopina", "12", "Warszawa")),
            };
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return appointments;
        }

    }
}
