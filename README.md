---

# Recruitment Process Management System

This is the backend API for a Recruitment Process Management System (RPMS), built with **ASP.NET Core**, **Entity Framework Core** and **MSSQL**. Untill now it creates job listings, and public job viewing, secured using JWT Bearer authentication [roles].

## Features

- **JWT Authentication:** API endpoints with **Bearer Tokens** with user roles (Recruiter, Admin, Candidate).
- **Role-Based Authorization:** only Recruiters can create job.
- **Job Listing:** Public read access to job listings.
- **Job Creation:** Create Job with basic details.
- **Database:** Using  **SQL Server** via Entity Framework Core.
- **API Documentation:** Using **Scalar**.

---

## Technology Stack

- **Framework:** .NET 8 (ASP.NET Core)
- **Language:** C\#
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Authentication:** JWT Bearer (via `Microsoft.AspNetCore.Authentication.JwtBearer`)
- **API Documentation:** Swagger/OpenAPI (via `Swashbuckle.AspNetCore` and `Scalar.AspNetCore`)

---

## Setup and Configuration

### 1\. Prerequisites

- .NET 8 SDK

### 2\. Database Configuration

Update the connection string in your `appsettings.json` (or environment variables) to point to your SQL Server instance.

**`appsettings.json` snippet:**

```json
"ConnectionStrings": {
  "AppDatabase": "Server=localhost,5050;Database=RPMSDatabase;User Id=sa;Password=Passw0rd123;MultipleActiveResultSets=True;TrustServerCertificate=True;"
}
```

### 3\. Running Migrations

After configuring the connection string, run the following commands to create the database schema:

```bash
# 1. using Microsoft.EntityFrameworkCore.Tools
update-database
```

The application will typically start on `https://localhost:7081`.

For scalar[Interactive Api] use `https://localhost:7081/scalar/`

---

## Authentication and Security

The API uses **JWT Bearer** tokens for authentication.


### Key Auth Endpoints (`/api/Auth`)

| Method | Endpoint                  | Description                                                    |
| :----- | :------------------------ | :------------------------------------------------------------- |
| `POST` | `/api/Auth/register`      | Register a new user (Candidate/Recruiter).                     |
| `POST` | `/api/Auth/login`         | Authenticate and receive **Auth Token** and **Refresh Token**. |
| `POST` | `/api/Auth/refresh-token` | Obtain a new Auth Token using a valid Refresh Token.           |
| `GET`  | `/api/Auth/auth-admin`    | **Requires `Admin` Role** and valid token.                     |

---

## API Endpoints

### 1\. Public Jobs Access (`/api/Jobs`)

This controller allows public read access to job listings.

| Method | Endpoint            | Description                                             | Auth Required |
| :----- | :------------------ | :------------------------------------------------------ | :------------ |
| `GET`  | `/api/Jobs`         | Retrieve a list of all current job postings.            | No            |
| `GET`  | `/api/Jobs/{jobID}` | Retrieve detailed information for a single job posting. | No            |

### 2\. Recruiter Job Management (`/api/Recruiters`)

This controller requires a valid JWT with the **`Recruiter`** role.
[for now it only takes very basic details for jobs. in next update would be full functionality.]

| Method   | Endpoint                      | Description                                   | Auth Required         |
| :------- | :---------------------------- | :-------------------------------------------- | :-------------------- |
| `POST`   | `/api/Recruiters/job`         | **Create** a new job posting.                 | **Yes (`Recruiter`)** |

---

## Testing

The included test file (`API.TESTS.http`) can be used to rapidly test all key endpoints, including successful job creation, DTO validation failures, and authorization checks.

1.  **Open** the `API.TESTS.http` file.
2.  **Replace** the placeholder `@token` variable with a freshly obtained Recruiter Auth Token.
3.  **Click** "Send Request" above each test block to execute.
