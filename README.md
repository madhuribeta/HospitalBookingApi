# 🏥 Hospital Booking API

A full-stack hospital appointment booking application built with **ASP.NET Core** (backend) and **Angular 18** (frontend).

## 📋 Features

- Browse hospitals (clinics)
- View doctors by hospital
- View available appointment slots per doctor
- Book an appointment slot

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| Backend | ASP.NET Core 8 Web API |
| Database | SQLite via Entity Framework Core |
| Frontend | Angular 18 (Standalone Components) |
| API Docs | Swagger UI |

## 📁 Project Structure

```
HospitalBookingApi/
├── HospitalBookingApi/        # ASP.NET Core Backend
│   ├── Controllers/           # API Controllers
│   ├── Models/                # Entity Models
│   ├── Data/                  # DbContext & Seed Data
│   └── Migrations/            # EF Core Migrations
└── HospitalBookingClient/     # Angular Frontend
    └── src/app/
        ├── components/        # UI Components
        ├── services/          # API Service
        └── models/            # TypeScript Models
```

## 🚀 Getting Started

### Backend

```bash
cd HospitalBookingApi
dotnet run
```

API runs at: `http://localhost:5237`  
Swagger UI: `http://localhost:5237/swagger`

### Frontend

```bash
cd HospitalBookingClient
npm install
npm start
```

App runs at: `http://localhost:4200`

## 🔌 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/clinics` | List all hospitals |
| GET | `/api/doctors` | List all doctors |
| GET | `/api/doctors/clinic/{id}` | Doctors by hospital |
| GET | `/api/appointmentslots/doctor/{id}` | Slots by doctor |
| POST | `/api/appointmentslots/book/{slotId}` | Book a slot |

## 📄 License

MIT
