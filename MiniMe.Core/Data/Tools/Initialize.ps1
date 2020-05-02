Set-Location (Get-Item $PSScriptRoot).Parent.Parent.FullName

Remove-Item -Recurse -Force -ErrorAction Ignore ./Data/Migrations
dotnet ef migrations add InitialCreate -o ./Data/Migrations
