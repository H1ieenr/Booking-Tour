# 🚀 Booking Tour Platform

A modern Tour Booking system built with **Microservices** architecture, following **DDD (Domain-Driven Design)** and **CQRS** patterns.

## 📌 Project Overview
This project aims to build a scalable and maintainable platform for booking travel tours. It demonstrates professional software engineering practices in the .NET ecosystem.

## 🛠 Tech Stack
* **Backend:** .NET 10 (Web API)
* **Architecture:** Microservices, Clean Architecture
* **Design Patterns:** DDD, CQRS with **MediatR**
* **Database:** SQL Server (Database-per-service)
* **Frontend:** Angular
* **DevOps:** Docker, Docker Compose

## 🔄 System Workflow (CQRS)
The system separates Read and Write operations to optimize performance and scalability:
* **Command (Write):** Client → API → MediatR → CommandHandler → Domain Logic → DB.
* **Query (Read):** Client → API → MediatR → QueryHandler → DTOs → UI.

## 🚦 Project Status
* [x] Project Structure (DDD layers)
* [x] Initial Tour/Booking API Demos
* [ ] Identity Service (Auth)
* [ ] Event Bus integration (RabbitMQ)

