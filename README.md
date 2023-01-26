
# Title and Desription 

Test task for Modsen company . Simple CRUD-Api for work with events using ASP.Net, C#, MS Server and jwt-bearer authentification.
## Run Locally

Clone the project

```bash
  git clone https://github.com/Hovanella/ModsenTask
```

Go to the project directory

```bash
  cd ModsenTask/ModsenTask
```

Set your connection string to MS Server in "ConnectionStrings/DefaultConnection" inside appsettings.json    

`"ConnectionStrings": {
    "DefaultConnection": "Data Source=<ServerName>;Initial Catalog=<CatalogName>;User=<UserName>;Password=<Password>;TrustServerCertificate=True;Integrated Security=False;"
  }`

Create Database using CLI 

```bash
dotnet ef database update --project ModsenTask.csproj --startup-project ModsenTask.csproj --context ModsenTask.Data.DataContext --configuration Debug 20230125094809_Initial

```

Start the server

```bash
  dotnet run --project .\ModsenTask.csproj --launch-profile modsen_task
```

Go to swagger page 

<https://localhost:7212/swagger/index.html>


## Operations

For Anonymous
- Register and login as Organizers
- Get all events list and event by id

For Organizers
- Create a new event
- Delete and update own events


