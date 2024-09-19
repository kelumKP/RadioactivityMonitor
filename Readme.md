# RadioactivityMonitor

This project monitors radiation levels and triggers alarms based on predefined thresholds.

## Prerequisites

- .NET 6.0 SDK or higher
- Visual Studio or a suitable IDE
- A command-line interface (CLI)

## Project Structure

- **RadioactivityMonitor.API**: Contains the API controllers and the main program.
- **RadioactivityMonitor.Application**: Contains application logic and service interfaces.
- **RadioactivityMonitor.Domain**: Contains domain models and business logic.
- **RadioactivityMonitor.Infrastructure**: Contains sensor implementations and data access logic.
- **RadioactivityMonitor.Tests**: Contains unit tests for the application.

## Compilation

1. Open the solution file (`RadioactivityMonitor.sln`) in Visual Studio or navigate to the project directory in CLI.

2. Restore the project dependencies by running:

   ```bash
   dotnet restore
3. Build the project:
	```bash
	dotnet build
## Running the Application

1. Navigate to the `RadioactivityMonitor.API` project directory:

	```bash
	cd RadioactivityMonitor.API
2. Run the application:
	```bash
	dotnet run
3. The application will start, and you can access the API at `http://localhost:5104/api/alarm/check`.

by accessing above URL via any browser or POSTMEN or Swaggger it can test this API

## Running Tests

To run the tests, navigate to the `RadioactivityMonitor.Tests` directory and execute:

  ```bash
  dotnet test