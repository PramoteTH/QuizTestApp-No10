# QuizTestApp

แอปพลิเคชันทดสอบข้อสอบ สร้างด้วย ASP.NET Core 9 + Vue 3

## Tech Stack

| ส่วน | เทคโนโลยี |
|------|-----------|
| Backend | ASP.NET Core 9, Entity Framework Core, SQLite |
| Frontend | Vue 3, Vite, Axios |
| Unit Test | MSTest, Moq |

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Node.js LTS](https://nodejs.org/)

## โครงสร้างโปรเจกต์

```
QuizTestApp-10/
├── backend/
│   ├── QuizTestApp.api/     # ASP.NET Core API
│   └── QuizTestApp.Tests/   # Unit Tests
└── frontend/                # Vue 3
```

## วิธีรัน

### 1. Backend

```bash
cd backend/QuizTestApp.api
dotnet run
```

API จะรันที่ `http://localhost:5130`

### 2. Frontend

```bash
cd frontend
npm install
npm run dev
```

Frontend จะรันที่ `http://localhost:5173`

### 3. Unit Tests

```bash
cd backend/QuizTestApp.Tests
dotnet test
```

## API Endpoints

| Method | Endpoint | คำอธิบาย |
|--------|----------|----------|
| GET | `/api/test-all` | ดึงผลสอบทั้งหมด |
| POST | `/api/submit-test` | ส่งคำตอบ |

### ตัวอย่าง Request: POST /api/submit-test

```json
{
  "name": "Tor",
  "answer1": 1,
  "answer2": 3
}
```

### ตัวอย่าง Response

```json
{
  "id": 1,
  "name": "Tor",
  "totalPoint": 2
}
```
