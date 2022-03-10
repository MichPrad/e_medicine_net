namespace Patient.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Patient.Web;
    using Patient.Web.Application.Dtos;

    public class FakeRepository
    {
        public IEnumerable<AppointmentDto> appointments;
        public IEnumerable<PrescriptionDto> prescriptions;

        public FakeRepository()
        {
            this.appointments = new List<AppointmentDto>
            {
                new AppointmentDto() { Id=1, IdDoctor=1, IdPatient=1, StartDateOfTheVisit = DateTime.Now, EndDateOfTheVisit = DateTime.Now, Place = new PlaceDto() { Name = "Warszawianka" , Street = "Chopina",  HouseNumber = "2", Town = "Warszawa"} },
                new AppointmentDto() { Id=2, IdDoctor=1, IdPatient=2, StartDateOfTheVisit = DateTime.Now, EndDateOfTheVisit = DateTime.Now, Place = new PlaceDto() { Name = "Gdanszczanka" , Street = "Patrycjuszy",  HouseNumber = "62B", Town = "Gdansk"} },
                new AppointmentDto() { Id=3, IdDoctor=2, IdPatient=3, StartDateOfTheVisit = DateTime.Now, EndDateOfTheVisit = DateTime.Now, Place = new PlaceDto() { Name = "Dom Wroclawski" , Street = "Ujazdow",  HouseNumber = "200", Town = "Wroclaw"} },
                new AppointmentDto() { Id=4, IdDoctor=1, IdPatient=2, StartDateOfTheVisit = DateTime.Now, EndDateOfTheVisit = DateTime.Now, Place = new PlaceDto() { Name = "Szpital Poznanski" , Street = "Zielona",  HouseNumber = "64", Town = "Poznan"} },
                new AppointmentDto() { Id=5, IdDoctor=3, IdPatient=3, StartDateOfTheVisit = DateTime.Now, EndDateOfTheVisit = DateTime.Now, Place = new PlaceDto() { Name = "Dom Pomocy" , Street = "Apollo",  HouseNumber = "2A", Town = "Szalec"} }             
            };
            this.prescriptions = new List<PrescriptionDto>
            {
                new PrescriptionDto() { IdPrescription = 1, IdDoctor = 1 , IdPatient = 1, Date = DateTime.Now, DateOfExpiration = DateTime.Now, Medicines = new List<MedicineDto>() { new MedicineDto() { Id = 1 , Name = "Ibuprofen", DailyDose = 1} } },
                new PrescriptionDto() { IdPrescription = 2, IdDoctor = 1 , IdPatient = 3, Date = DateTime.Now, DateOfExpiration = DateTime.Now, Medicines = new List<MedicineDto>() { new MedicineDto() { Id = 2 , Name = "Magvit", DailyDose = 1} } },
                new PrescriptionDto() { IdPrescription = 3, IdDoctor = 2 , IdPatient = 2, Date = DateTime.Now, DateOfExpiration = DateTime.Now, Medicines = new List<MedicineDto>() { new MedicineDto() { Id = 3 , Name = "Silaurum", DailyDose = 2} } },
                new PrescriptionDto() { IdPrescription = 4, IdDoctor = 3 , IdPatient = 3, Date = DateTime.Now, DateOfExpiration = DateTime.Now, Medicines = new List<MedicineDto>() { new MedicineDto() { Id = 4 , Name = "Cerutin", DailyDose = 2} } },
                new PrescriptionDto() { IdPrescription = 5, IdDoctor = 2 , IdPatient = 3, Date = DateTime.Now, DateOfExpiration = DateTime.Now, Medicines = new List<MedicineDto>() { new MedicineDto() { Id = 5 , Name = "neo-agin", DailyDose = 4} } },
            };
        }

        public IEnumerable<AppointmentDto> GetAppointments()
        {
            return appointments;
        }

        public IEnumerable<PrescriptionDto> GetPrescriptions()
        {
            return prescriptions;
        }

    }
}