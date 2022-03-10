namespace Doctor.Application.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Doctor.Application.Controller;
    using Doctor.Application.Model;
    using Doctor.Application.Utilities;

    [TestClass]
    public class ModelControllerTests
    {
        [TestMethod]
        public void LoadMedicalAppointmentsList_MedicalAppointmentsArray_ThereIsOnlyOneDoctorsAppointments()
        {
            IModel model = new Model(new EmptyEventDispatcher());

            int idDoctor = 1;

            model.IdDoctor = idDoctor;

            model.LoadMedicalAppointmentsList();

            int elementsInList = model.AppointmentList.Count;

            int elementsIdDoctor = model.AppointmentList.Where(app => app.IdDoctor == idDoctor).Count();

            Assert.AreEqual(elementsInList, elementsIdDoctor, "In list should have been {0} elements with ID Doctor {1}, not only {2}", elementsInList, idDoctor, elementsIdDoctor);
        }

        [TestMethod]
        public void LoadPrescriptionList_PrescriptionArray_ThereIsOnlyOneDoctorsPrescriptions()
        {
            IModel model = new Model(new EmptyEventDispatcher());

            int idDoctor = 1;

            model.IdDoctor = idDoctor;

            model.LoadPrescriptionList();

            int elementsInList = model.PrescriptionList.Count;

            int elementsIdDoctor = model.PrescriptionList.Where(app => app.IdDoctor == idDoctor).Count();

            Assert.AreEqual(elementsInList, elementsIdDoctor, "In list should have been {0} elements with ID Doctor {1}, not only {2}", elementsInList, idDoctor, elementsIdDoctor);
        }
    }
}
