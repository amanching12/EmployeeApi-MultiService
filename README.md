# Employee API Multi-Service Application

## Overview
This project is a multi-service .NET Core (8.0) application using MongoDB as the database and Redis for caching. It is containerized with Docker and orchestrated using Docker Compose.

## Prerequisites
- **Docker 20.10 or later**: [Install Docker](https://docs.docker.com/get-docker/)
- **Docker Compose 1.27 or later**: [Install Docker Compose](https://docs.docker.com/compose/install/)

## Project Structure
- **Web Service**: A .NET Core 8.0 Web API that handles CRUD operations for employee data.
- **MongoDB Service**: A MongoDB database to store employee information.
- **Redis Service**: A Redis cache for optimized data access.

---

## Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/EmployeeApi-MultiService.git
cd EmployeeApi-MultiService
```

### 2. Build and Run the Multi-Service Application
- **You can use Docker Compose to build and run all services at once:**

```bash
docker-compose up --build
```

### 3. Access the Application
- **Once the containers are running, you can access the Web API at:**
```bash
http://localhost:8080
```

- **You can test API endpoints such as:**

```bash
GET /employees: Retrieve all employees.
POST /employees: Add a new employee.
GET /employees/{id}: Retrieve a specific employee by ID.
```

### 4. Pushing Docker Image to Docker Hub
- **To push your Docker image to Docker Hub:**

```bash

docker tag employeeapi:latest yourusername/employeeapi:v1
docker push yourusername/employeeapi:v1
```

### 5. Pulling and Running the Image from Docker Hub
- **You can pull the Docker image from Docker Hub and run it independently as a container:**

```bash

docker pull yourusername/employeeapi:v1
docker run -d -p 8080:80 yourusername/employeeapi:v1
```
### 6.Screenshots

<img width="1398" alt="Screenshot 2024-09-26 at 9 45 52 PM" src="https://github.com/user-attachments/assets/8a9c4eef-490e-454e-a4f1-ff13adc877be">
