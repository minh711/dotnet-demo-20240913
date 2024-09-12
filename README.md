# dotnet-demo-20240913

Navigate to the project folder

```sh
cd .\Demo13092024\    
```

## Setup

Install tool for code generator

```sh
dotnet tool install -g dotnet-aspnet-codegenerator  
```

Install package for code generator

```sh
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

Add controller using code generator

```sh
dotnet-aspnet-codegenerator -p . controller -name PlayersController -api -m Demo13092024.Db.Models.Player -dc CodeFirstDemoContext -outDir Controllers -namespace Demo13092024.Controllers
```

## Database

Add migration

```sh
dotnet ef migrations add InitialMigration -o Db/Migrations        
```

Update database

```sh
dotnet ef database update
```

## Build & Run

Build to check for errors

```sh
dotnet build
```

Run the project

```sh
dotnet run
```
