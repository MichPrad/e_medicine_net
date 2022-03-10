curl -X POST "https://localhost:44381/AddAppointment" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"idDoctor\":1,\"idPatient\":1,\"startDateOfTheVisit\":\"2021-04-18T15:33:05.080Z\",\"endDateOfTheVisit\":\"2021-04-18T15:33:05.080Z\",\"place\":{\"name\":\"string1\",\"street\":\"string2\",\"houseNumber\":\"string3\",\"town\":\"string4\"}}"

pause