namespace Patient.Tests
{ 
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    using Patient.Web.Application.Queries;
    using Patient.Web.Application.Dtos;

    [TestClass]
    public class PatientTest
    {
        [TestMethod]
        public void GetAppoinmentsByPlace_SimpleAppointmentsData_ReturnsOneObject()
        {
            FakeRepository fakeRepository = new FakeRepository();

            IEnumerable<AppointmentDto> list = fakeRepository.GetAppointments();

            PatientsQueryHandler handler = new PatientsQueryHandler();

            int number = handler.GetAppoinmentsByPlace(list, "Gdanszczanka").Count();

            Assert.AreEqual(1, number, "In list should have been 1 obeject of place name Gdanszczanka", 1, number);
        }


        [TestMethod]
        public void GetPrescriptionsByYearOfExpiration_SimplePrescriptionData_ReturnsFiveObjects()
        {
            FakeRepository fakeRepository = new FakeRepository();

            IEnumerable<PrescriptionDto> list = fakeRepository.GetPrescriptions();

            PatientsQueryHandler handler = new PatientsQueryHandler();

            int number = handler.GetPrescriptionsByYearOfExpiration(list, 2021).Count();

            Assert.AreEqual(5, number, "In list should have been 5 obejects of prescription expire year 2021", 5, number);
        }
    }
}
