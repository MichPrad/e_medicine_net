INSERT INTO Places (Name, Street, HouseNumber, Town) VALUES ('Pomorski Urzad Zdrowia', 'Wolkowyska', '23/25', 'Gdansk')
INSERT INTO Places (Name, Street, HouseNumber, Town) VALUES ('Wojewodzki Osrodek Ochrony Zdrowia', 'Mysliwska', '18', 'Warszawa')
INSERT INTO Places (Name, Street, HouseNumber, Town) VALUES ('Samodzielny Publiczny Zaklad Opieki Zdrowotnej', 'Nowogrodzka', '80', 'Debki')
INSERT INTO Places (Name, Street, HouseNumber, Town) VALUES ('Przychodnia Lekarska', 'Traugutta', '15A', 'Katowice')
INSERT INTO Places (Name, Street, HouseNumber, Town) VALUES ('Gospody-Med','Gospody','7','Krakow')

INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (1, 1, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (1, 2, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (1, 3, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (2, 3, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (2, 2, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (3, 1, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (1, 8, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (3, 5, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (4, 3, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (4, 7, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (3, 6, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (6, 11, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (5, 9, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (5, 7, GETDATE(), GETDATE())
INSERT INTO Appointments (IdDoctor, IdPatient, StartDateOfTheVisit, EndDateOfTheVisit) VALUES (5, 11, GETDATE(), GETDATE())

INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (1,1)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (2,2)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (3,3)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (4,4)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (5,5)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (6,1)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (7,2)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (8,3)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (9,4)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (10,5)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (11,1)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (12,2)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (13,3)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (14,4)
INSERT INTO AppointmentPlace (AppointmentId, PlaceId) VALUES (15,5)