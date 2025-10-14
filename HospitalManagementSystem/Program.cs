using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalManagementSystem
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public Doctor(int id, string name, string specialization)
        {
            Id = id;
            Name = name;
            Specialization = specialization;
        }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Patient(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }

    public class HospitalRoom
    {
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public List<Patient> Patients { get; set; }

        public HospitalRoom(int roomNumber, int capacity)
        {
            RoomNumber = roomNumber;
            Capacity = capacity;
            Patients = new List<Patient>();
        }

        public void AddPatient(Patient patient)
        {
            if (Patients.Count < Capacity)
            {
                Patients.Add(patient);
                Console.WriteLine($"Пацієнт {patient.Name} доданий у палату №{RoomNumber}");
            }
            else
            {
                Console.WriteLine($"Палата №{RoomNumber} переповнена! Неможливо додати пацієнта.");
            }
        }
    }

    public class MedicalRecord
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public MedicalRecord(Patient patient, Doctor doctor, DateTime date, string description)
        {
            Patient = patient;
            Doctor = doctor;
            Date = date;
            Description = description;
        }
    }

    public class Hospital
    {
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
        public List<HospitalRoom> Rooms { get; set; }
        public List<MedicalRecord> Records { get; set; }

        public Hospital()
        {
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
            Rooms = new List<HospitalRoom>();
            Records = new List<MedicalRecord>();
        }

        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
            Console.WriteLine($"Лікар {doctor.Name} ({doctor.Specialization}) доданий до системи");
        }

        public void RegisterPatient(Patient patient)
        {
            Patients.Add(patient);
            Console.WriteLine($"Пацієнт {patient.Name}, {patient.Age} років, зареєстрований");
        }

        public void CreateRoom(HospitalRoom room)
        {
            Rooms.Add(room);
            Console.WriteLine($"Палата №{room.RoomNumber} створена (місткість: {room.Capacity})");
        }

        public void HospitalizePatient(int patientId, int roomNumber)
        {
            Patient? patient = Patients.FirstOrDefault(p => p.Id == patientId);
            if (patient == null)
            {
                Console.WriteLine($"Пацієнт з ID {patientId} не знайдений!");
                return;
            }

            HospitalRoom? room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room == null)
            {
                Console.WriteLine($"Палата №{roomNumber} не знайдена!");
                return;
            }

            room.AddPatient(patient);
        }

        public void AddMedicalRecord(MedicalRecord record)
        {
            Records.Add(record);
            Console.WriteLine($"Медичний запис створено: {record.Patient.Name} -> {record.Doctor.Name}");
        }

        public List<MedicalRecord> GetPatientHistory(int patientId)
        {
            return Records.Where(r => r.Patient.Id == patientId).ToList();
        }

        public string GetStatistics()
        {
            int totalPatientsInRooms = Rooms.Sum(r => r.Patients.Count);

            return $"\n=== СТАТИСТИКА ЛІКАРНІ ===\n" +
                   $"Кількість лікарів: {Doctors.Count}\n" +
                   $"Кількість зареєстрованих пацієнтів: {Patients.Count}\n" +
                   $"Кількість палат: {Rooms.Count}\n" +
                   $"Кількість пацієнтів у палатах: {totalPatientsInRooms}\n" +
                   $"Кількість медичних записів: {Records.Count}\n";
        }
    }

    public class HospitalDemo
    {
        public void Run()
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

            Hospital hospital = new Hospital();

            Doctor doc1 = new Doctor(1, "Петренко Іван", "Хірург");
            Doctor doc2 = new Doctor(2, "Сидоренко Ольга", "Терапевт");
            Doctor doc3 = new Doctor(3, "Ковальчук Андрій", "Кардіолог");

            Patient p1 = new Patient(1, "Коваленко Тарас", 35);
            Patient p2 = new Patient(2, "Шевченко Марія", 28);
            Patient p3 = new Patient(3, "Бондаренко Олексій", 52);
            Patient p4 = new Patient(4, "Мельник Ірина", 45);

            HospitalRoom room101 = new HospitalRoom(101, 2);
            HospitalRoom room102 = new HospitalRoom(102, 1);
            HospitalRoom room201 = new HospitalRoom(201, 3);

            Console.WriteLine("--- ДОДАВАННЯ ЛІКАРІВ ---");
            hospital.AddDoctor(doc1);
            hospital.AddDoctor(doc2);
            hospital.AddDoctor(doc3);
            Console.WriteLine();

            Console.WriteLine("--- РЕЄСТРАЦІЯ ПАЦІЄНТІВ ---");
            hospital.RegisterPatient(p1);
            hospital.RegisterPatient(p2);
            hospital.RegisterPatient(p3);
            hospital.RegisterPatient(p4);
            Console.WriteLine();

            Console.WriteLine("--- СТВОРЕННЯ ПАЛАТ ---");
            hospital.CreateRoom(room101);
            hospital.CreateRoom(room102);
            hospital.CreateRoom(room201);
            Console.WriteLine();

            Console.WriteLine("--- ГОСПІТАЛІЗАЦІЯ ПАЦІЄНТІВ ---");
            hospital.HospitalizePatient(1, 101);
            hospital.HospitalizePatient(2, 101);
            hospital.HospitalizePatient(3, 102);
            hospital.HospitalizePatient(4, 101);
            hospital.HospitalizePatient(5, 101);
            hospital.HospitalizePatient(1, 999);
            Console.WriteLine();

            Console.WriteLine("--- СТВОРЕННЯ МЕДИЧНИХ ЗАПИСІВ ---");
            hospital.AddMedicalRecord(new MedicalRecord(p1, doc1, DateTime.Now.AddDays(-5), "Огляд після операції. Стан стабільний."));
            hospital.AddMedicalRecord(new MedicalRecord(p3, doc3, DateTime.Now.AddDays(-2), "Призначено ЕКГ та аналіз крові."));
            hospital.AddMedicalRecord(new MedicalRecord(p1, doc2, DateTime.Now, "Скарги на кашель. Призначено сироп."));
            Console.WriteLine();

            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ID 1 ---");
            var history = hospital.GetPatientHistory(1);
            if (history.Any())
            {
                foreach (var record in history)
                {
                    Console.WriteLine($"  Дата: {record.Date:dd.MM.yyyy}");
                    Console.WriteLine($"  Лікар: {record.Doctor.Name} ({record.Doctor.Specialization})");
                    Console.WriteLine($"  Опис: {record.Description}\n");
                }
            }
            else
            {
                Console.WriteLine("Історія хвороби для цього пацієнта порожня.");
            }

            Console.WriteLine(hospital.GetStatistics());
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            HospitalDemo demo = new HospitalDemo();
            demo.Run();

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}