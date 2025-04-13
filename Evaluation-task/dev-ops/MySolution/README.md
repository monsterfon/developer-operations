# MySolution Documentation

## Overview
This solution consists of three projects: a console application (`Main`) and two class libraries (`Subproject1` and `Subproject2`). The libraries are designed to be reusable components that can be referenced by the console application.

## Project Structure
```
MySolution
├── MySolution.sln
├── Main
│   ├── Main.csproj
│   └── Program.cs
├── Subproject1
│   ├── Subproject1.csproj
│   └── Class1.cs
├── Subproject2
│   ├── Subproject2.csproj
│   └── Class2.cs
└── README.md
```

## Building the Solution
To build the solution, you can use the following command in the terminal:

```
dotnet build MySolution.sln
```

### Local Builds
For local builds, the `Main` project references `Subproject1` and `Subproject2` using `ProjectReference`. This allows for easy development and testing of the libraries alongside the console application.

### CI Builds
In Continuous Integration (CI) environments, the libraries should be published as NuGet packages. To switch to `PackageReference`, modify the project files accordingly and ensure that the necessary CI/CD pipeline steps are in place to publish the packages.

## Running the Application
After building the solution, you can run the console application using the following command:

```
dotnet run --project Main/Main.csproj
```

## Additional Information
- Ensure that you have the .NET SDK installed on your machine.
- For more details on how to create and manage NuGet packages, refer to the official documentation.

## License
This project is licensed under the MIT License. See the LICENSE file for more information.