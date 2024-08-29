Before starting the project, put the following file into the project directory:

appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "MainSettings": {
    "MongoDatabase": {
      "DBName": "dbname",
      "DBServer": "mongodb://127.0.0.1:27017"
    }
    }
}
```
```csharp
/*
"DBName": "dbname" = database name
"DBServer": "mongodb://127.0.0.1:27017" = server ip
*/
```
