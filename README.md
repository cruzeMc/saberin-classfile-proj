## Overview

**ClassLibrary1** is a shared class library that provides the core domain models, data transfer objects (DTOs), mapping configurations, and repository/service interfaces for the Contact Manager application. It ensures consistency across the entire solution by centralizing:

- **Models:**  
  Domain entities such as `Contact` and `Address`, which include data annotations for validation.
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
    ├── Contact.cs - Defines the Contact domain model, including validation attributes.
    └── Address.cs - Defines the Address domain model with validation and foreign key relationships.

 ```

## Setup Instructions

1. **Clone the Repository:**  
   Clone the repository to your local machine:
   ```bash
   git clone <repository-url>

2. **Restore Dependencies:**  
   From the solution root, run 
    ```bash
          dotnet restore

3. **Build the Project:**  
   Navigate to the ClassLibrary1 directory and build the project:  
   ```bash
   dotnet build ClassLibrary1/ClassLibrary1.csproj

4. **Run Tests:**  
   If tests are provided (e.g., for mapping configurations or model validations), navigate to the test project folder and run:
   ```bash
   dotnet test

