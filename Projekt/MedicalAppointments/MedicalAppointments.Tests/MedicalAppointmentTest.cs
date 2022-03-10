namespace MedicalAppointments.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    using MedicalAppointments.Web.Application.Dtos;
    using MedicalAppointments.Web.Application.Mapper;

    [TestClass]
    public class MedicalAppointmentTest
    {
        [TestMethod]
        public void Mapper_SimpleData_ReturnsFiveDto()
        {
            FakeRepository fakeRepository = new FakeRepository();

            int count = fakeRepository.GetAppointments().Select(r => r.Map()).Count();

            Assert.AreEqual(20, count, "In list should have been 20 obejects", 20, count);

        }

        [Timeout(2000)]
        [TestMethod]
        public void Mapper_SimpleData_ReasonableTime()
        {
            FakeRepository fakeRepository = new FakeRepository();

            var result = fakeRepository.GetAppointments().Select(r => r.Map());
        }

        [TestMethod]
        public void Mapper_SimpleData_TypesEqual()
        {
            FakeRepository fakeRepository = new FakeRepository();

            var outcome = fakeRepository.GetAppointments().Select(r => r.Map());

            Assert.IsInstanceOfType(outcome, typeof(IEnumerable<AppointmentDto>), "Type of mapped object is not IEnumerable<AppointmentDto>");
        }

    }
}
