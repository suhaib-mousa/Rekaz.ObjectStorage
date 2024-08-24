# Blob Storage Service Documentation

## Overview

The Blob Storage Service is a versatile system designed to store and retrieve data in various storage backends, such as Amazon S3, local file systems, databases, and optionally FTP. The service provides a consistent interface, allowing you to interact with these different storage types seamlessly.

### Key Features:
- Supports multiple storage backends (Amazon S3, Local Storage, Database, FTP).
- Configurable and extendable.
- Implements object-oriented principles for scalability and maintainability.

---

## Architecture and Design

### Core Concepts:

- **IBlobProvider**: The main interface for storing and retrieving blobs. Each storage backend implements this interface.
- **BlobProviderBase**: An abstract base class that provides shared functionality for all blob providers, such as handling streams.
- **BlobStorageService**: The service that interacts with the configured provider to save and retrieve blobs.
- **BlobStoringConfiguration**: Manages the configuration settings for different providers.

### Storage Backends:

#### 1. Local Storage
- **Description**: Stores files directly on the local file system of the server.
- **Path Calculation**: Utilizes a `BlobFilePathCalculator` to generate file paths where blobs are stored.
  
#### 2. Amazon S3
- **Description**: Interacts with Amazon S3 or S3-compatible services using HTTP requests.
- **Configuration**: Requires configuration of access keys, bucket name, and region to connect to the S3 service.

#### 3. Database
- **Description**: Stores blob data within a database, offering a centralized and persistent storage solution.
- **Implementation**:
  - **Provider**: The `DatabaseBlobProvider` class handles database interactions for blob storage.
  - **Functionality**:
    - **Saving Blobs**: Converts the blob's binary content into a byte array and saves it as a new entry in the database if it doesn't already exist.
    - **Retrieving Blobs**: Fetches blobs from the database using a unique identifier, returning the content as a `Stream`.
  - **Dependencies**:
    - **`IDatabaseBlobRepository`**: Interface for CRUD operations on blob data in the database.
  - **Error Handling**: Includes checks to prevent saving duplicate blobs and ensures data consistency.

#### 4. FTP (Bonus)
- **Description**: Utilizes the FluentFTP library to manage file operations over FTP.
- **Functionality**: Allows for file storage and retrieval using FTP protocols, making it flexible for remote file management.

### Extensibility:
The architecture is built with flexibility in mind. Each storage backend is configurable, and new backends can be added by implementing the `IBlobProvider` interface.

---

## Object-Oriented Principles and Design Patterns

### Key Principles:

1. **Abstraction**: The `IBlobProvider` interface and `BlobProviderBase` abstract the details of different storage mechanisms, making it easy to switch or extend the storage backends.
2. **Single Responsibility Principle**: Each class has a specific role, such as handling configuration, calculating paths, or managing storage.

### Design Patterns:

- **Strategy Pattern**: Used in the way different storage providers are interchangeable and configured dynamically.
- **Template Method Pattern**: The base class `BlobProviderBase` defines the skeleton for common operations while allowing derived classes to provide specific implementations.

---

## How to Use

### Prerequisites

Before starting the setup, ensure that your environment meets the following prerequisites:

1. **.NET 8 SDK Installed**  
   .NET 8 is required to build and run the application. Make sure it is installed on your system. You can check the version by running:
   ```bash
   dotnet --version
   ```
   If not installed, download and install the SDK from the [official .NET website](https://dotnet.microsoft.com/).

2. **ABP Framework 8.2.1**  
   The project requires the ABP Framework version 8.2.1. Ensure all necessary packages are updated to this version. You can install or update the packages via NuGet:
   ```bash
   dotnet add package Volo.Abp --version 8.2.1
   ```

These prerequisites ensure that your environment is compatible with the latest features and performance improvements provided by both .NET 8 and ABP 8.2.1.

For setting up object storage and configuring the blob storage options, the process involves selecting and configuring one storage provider at a time, depending on your requirements. Here’s a detailed breakdown of how to handle this:

### 1. **Configuring Blob Storage Providers**

In the `ObjectStorageWebModule` class, under the `ConfigureBlobStorage()` method, you’ll see different blob storage configurations commented out. You can choose one provider to configure and uncomment the relevant section while commenting out or removing others.

#### Example:
```csharp
private void ConfigureBlobStorage()
{
    Configure<BlobStoringOptions>(options =>
    {
        // Example for configuring local storage:
        options.Configuration.UseLocalStorage(f =>
        {
            f.BasePath = Path.Combine(Directory.GetCurrentDirectory(), "Documents");
        });

        // Example for configuring AWS S3:
        //options.Configuration.UseAws(aws =>
        //{
        //    aws.AccessKeyId = "YOUR_ACCESS_KEY";
        //    aws.SecretAccessKey = "YOUR_SECRET_KEY";
        //    aws.BucketName = "YOUR_BUCKET";
        //    aws.Region = "YOUR_REGION";
        //    aws.Container = "YOUR_CONTAINER";
        //});

        // Example for configuring FTP:
        //options.Configuration.UseFTP(f =>
        //{
        //    f.ServerAddress = "YOUR_SERVER_ADDRESS";
        //    f.Port = 21; // YOUR_PORT
        //    f.Username = "YOUR_USERNAME";
        //    f.Password = "YOUR_PASSWORD";
        //    f.RootPath = @"YOUR_ROOT_PATH";
        //});
    });
}
```
Here, you can only have **one** configuration active at a time. If you decide to switch from local storage to AWS, for instance, you must first comment out the local storage configuration and then uncomment and configure the AWS section.

### 2. **Using `DependsOn` Attribute**

To ensure the correct modules are loaded, the `DependsOn` attribute in the module class needs to include only the relevant dependencies. For example:

- If you’re using local storage:
```csharp
[DependsOn(
    typeof(BlobStoringLocalStorageModule),
    typeof(BlobStoringModule)
    // Other relevant modules...
)]
public class ObjectStorageApplicationContractsModule : AbpModule
{
    // Module implementation...
}
```

- If you’re switching to AWS:
```csharp
[DependsOn(
    typeof(BlobStoringAwsModule),
    typeof(BlobStoringModule)
    // Other relevant modules...
)]
public class ObjectStorageApplicationContractsModule : AbpModule
{
    // Module implementation...
}
```

Remember to **replace** the previous module with the new one to avoid conflicts.

### 3. **Configuring the Database**

If you need to store blobs with the database provider, configure the database in the `ConfigureDatabase()` method in `OnModelCreating` of `ObjectStorageDbContext`:

```csharp
builder.ConfigureDatabase();
```

Ensure to do the following:

1. **Enable** the following modules:
   - `ObjectStorageDomainModule`
   - `ObjectStorageDomainSharedModule`
   - `ObjectStorageEntityFrameworkCoreModule`

2. **Comment out** any other storage modules (e.g., Local Storage, Amazon S3, FTP) that you are not using.

3. Add the `UseDatabase` in the `ObjectStorageWebModule` class, under the `ConfigureBlobStorage()` method, comment out or remove the others:
```csharp
private void ConfigureBlobStorage()
{
     Configure<BlobStoringOptions>(options =>
    {
        options.Configuration.UseDatabase();
    });
}
```
> Note: Should run the `Rekaz.ObjectStorage.DbMigrator.csproj` to apply the migrations of the database provider.

## For authentication

Portal Access:
1. You can easily log in using the username `admin` and the password `1q2w3E*`. And go to `/swagger/index.html`.
2. Navigate to `ObjectFile`:
   ![image](https://github.com/user-attachments/assets/4dfcb83f-1d4f-4c05-8fb4-a6b39cd45751)
   
For external Access:
You can use the postman for instance and firstly call the following API:
![image](https://github.com/user-attachments/assets/970b300a-39ca-460d-8cc5-d151f5cf5077)
then will you get the `access_token`.

Add this token as a Bearer token in the Authorization header for ObjectFile API calls.

### Summary
- Choose one blob storage provider to configure at a time and comment out or remove the others.
- Update the `DependsOn` attribute to include the correct module corresponding to the chosen provider.
- If switching storage providers, ensure you replace the old configuration with the new one.
- Only configure one approach for database integration at a time to avoid conflicts.
