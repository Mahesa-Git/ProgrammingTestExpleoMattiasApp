# ProgrammingTestExpleoMattiasApp
 Testanswers for Expleo Stockholm AB by Mattias Hermansson Salmi ITHS .NET 2020
-----------------------------------------------------------------------------------------------------------------------
Instructions for building source code, executing application and run the two unit tests using the commandline (cmd.exe):
------------------------------------------------------------------------------------------------------------------------
*Launch cmd.exe

*Navigate to the directory of the repository: ProgrammingTestExpleoMattiasApp 

*Compile source code:
- Navigate to directory that ends with \ProgrammingTestExpleoMattias
- Use the command: dotnet build 
- Navigate to directory that ends with \ProgrammingTestExpleoMattias.UnitTests
- Use the command: dotnet build

*Execute application (console .NET core): 
- Contains Problem 3 followed by Problem 2. 
- Do this by navigating to the directory \ProgrammingTestExpleoMattias
- Use the command: dotnet run

*Run tests built using MSTest:
- The tests are developed to test the Anagram-method (Problem 1)
- Navigate to directory that ends with \ProgrammingTestExpleoMattias.UnitTests
- Use the command: dotnet test --logger "console;verbosity=detailed"
 