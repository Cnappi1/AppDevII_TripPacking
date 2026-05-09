If the project does not build due to missing NuGet packages:
1. Go to Tools -> NuGet Package Manager -> Package Manager Settings
2. Open Package Sources
3. Make sure the package source below exists and is enabled:
	nuget.org
	https://api.nuget.org/v3/index.json
4.Right click the solution and select Restore NuGet Packages
5.Rebuild solution