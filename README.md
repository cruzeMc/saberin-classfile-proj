## Overview

**ClassLibrary1** is a shared class library that provides the core domain models, data transfer objects (DTOs), mapping configurations, and repository/service interfaces for the Contact Manager application. It ensures consistency across the entire solution by centralizing:

- **Models:**  
  Database entities such as `Contact` and `Address`, which includes data annotations for validation.
- **DTOs:**  
  Data Transfer Objects (e.g., `ContactDTO` and `AddressDTO`) for communication between the API, UI, and business logic layers.

## Folder Structure

The project is organized as follows:
```
ClassLibrary1/
├── DTOs
│   ├── ContactDTO.cs - Contains the Data Transfer Object (DTO) for the Contact entity.
│   └── AddressDTO.cs - Contains the Data Transfer Object (DTO) for the Address entity.
└── Models
    ├── Contact.cs - Defines the Contact database model, including validation annotations eg. [Required].
    └── Address.cs - Defines the Address database model with validations and foreign key relationships.
 ```

## Setup Instructions

1. **Clone the Repository:**  
   ```bash
   git clone <repository-url>

2. **Navigate to the root directory:**
   ```bash
   cd {root directory}

3. **Restore Dependencies:**  
    ```bash
    dotnet restore

4. **Build the Project:**  
   ```bash
   dotnet build

5. **Run Tests:**  
   ```bash
   dotnet test