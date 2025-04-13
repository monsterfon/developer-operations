as # DevOps Evaluation Task

**Author:** Žiga Fon  
**Program:** Študent FRI MAG  
**Field:** Development Operations (DevOps)

## 🛠️ Overview

This repository contains the solution for the DevOps evaluation assignment. It includes:

1. My definition of DevOps.
2. A GitLab CI/CD pipeline for building and deploying a sample C# console application.
3. A local Docker environment simulating load balancing using HAProxy and Nginx.

---

## 📘 DevOps Definition

DevOps is a practice that bridges the gap between development and operations by automating the software lifecycle — from build, testing, and deployment, to monitoring. Tools like GitLab CI, Docker, and scripting languages (Bash, PowerShell, Python) are key in achieving this.

The main goals of DevOps include:
- Automated testing (unit, integration tests),
- Consistent builds through CI pipelines,
- Safe and reliable deployments (on-prem or cloud),
- Continuous monitoring and logging.

DevOps reduces human error, speeds up feature delivery, and enables fast reaction to user and market feedback.

---

## 🚀 C# Console Application with GitLab CI/CD

### 📂 Project Structure

- `MainProject/`
- `SubProject1/`
- `SubProject2/` (depends on SubProject1)
- `Tests/` (unit tests for each project)

> All projects use `ProjectReference` locally and `PackageReference` in the GitLab pipeline.

### 🔧 GitLab CI/CD Pipeline

The pipeline includes:
- Build step for all projects
- Running unit tests
- Packaging SubProject1 and SubProject2 as NuGet packages
- Optional: Deploying packages (if configured)

> Pipeline YAML file is located at `.gitlab-ci.yml`.

### 📈 Application Functionality

- Accepts a folder path with CT slice `.txt` files.
- Asynchronously loads slices and computes:
  - Min/Max value per slice (with row/column position)
  - Average value per slice
- Computes global min/max/average across all slices
- Outputs results in summary tables
- [Optional] Displays total processing time

---

## 🐳 Load Balancer Setup (Docker)

A test environment using Docker Compose simulates:

- **2x HAProxy** in High-Availability (HA) setup
- **3x Nginx** servers:
  - `Nginx1`: returns "Hello One"
  - `Nginx2`: returns "Hello Two"
  - `Nginx3`: returns "Hello Three"

> Note: Ensure Docker is set to Linux containers:
> - Right-click the Docker tray icon and choose "Switch to Linux containers…"

### 🧪 Evaluation Steps

1. Simulate failure of Nginx2 and verify traffic rerouting.
2. Simulate HAProxy primary failure and verify failover to secondary.

> Configurations are located under `docker/` directory. Use `docker-compose up` to run.


