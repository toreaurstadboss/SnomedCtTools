# SnomedCtTools

Small .NET 10 library for validating SNOMED CT identifiers with the Verhoeff algorithm.

## Layout

- `Lib` contains the production library.
- `Tests` contains NUnit tests with FluentAssertions.

## Run the tests

```powershell
dotnet test SnomedCtTools.sln
```

In VS Code, use **Terminal: Run Task** and choose **Test solution**, or run the tests from the Testing view.

## Looking up Snomed CT codes online

There are multiple sites that offers browsing of Snomed Ct codes.

The CT Uk Browser is powerful in its presentation of not only Snomed Ct codes, but also their hierarchical relations to eachother and other relationships. 

https://termbrowser.nhs.uk/?

The Norwegian Snomed Ct browser offers a simplified search capability here : 
https://finnkode.helsedirektoratet.no/snomed/search

Each Snomed ct code opens up a more advanced search tool very similar to the Ct UK browser here : 

https://snowstorm.terminologi.helsedirektoratet.no/?perspective=full&conceptId1=188269007&edition=MAIN/SNOMEDCT-NO/2026-10-15&release=&languages=no,en



