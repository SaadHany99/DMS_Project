# 🏥 Clinic Appointment System ⏰

Welcome to the **Clinic Appointment System** — your smart and simple solution to manage doctor schedules, patient appointments, and time slot validations in a clinic. 💡 Built with the power of **ASP.NET Core** and **SQL Server**, this project brings structure and ease to medical scheduling. 🎯

---

## 🚀 Features

✅ Manage doctors, patients, and their appointments  
✅ Assign working schedules for each doctor  
✅ Prevent double bookings with conflict checks  
✅ Error messages shown via sweet popup alerts 😍  
✅ Clean code using Repository & Service Patterns  
✅ Built ERD diagram for database relationships

---

## 🧠 How Time Slot Validation Works

When an appointment is created, the system checks:

1. **Doctor's availability** for the specific day & time.
2. If the time is **within working hours**.
3. If the slot is **already taken** by another appointment.

If any condition fails, the system gently says:  
> ❌ “Time slot is busy. Please choose another time.”  
using a beautiful popup! 🧃

---

## 🛠️ Tech Stack

- 🔹 ASP.NET Core 8 Web API
- 🔹 Entity Framework Core
- 🔹 SQL Server
- 🔹 Repository & Service Design Pattern
- 🔹 SweetAlert2 for popups 🍬

---


## 📦 How to Run

1. Clone the repo:
   ```bash
   git clone https://github.com/your-username/clinic-appointment-system.git
   cd clinic-appointment-system
