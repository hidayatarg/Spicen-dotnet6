### Docker MSSQL Server
Download docker image for sql server and activate it
```docker
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -e "MSSQL_PID=Express" -p 1433:1433 --name=spicendbsql -d mcr.microsoft.com/mssql/server:2019-latest
docker start spicendbsql

```

Update EFCore for the connection String
```csharp
add-migration inital

````

### Docker Containers Tricks
-   to list or check active containers `docker ps`
-   to list all containers `docker ps -a`
-   to start a container `docker start CONTAINER_ID`

### Migration
It will create the database with name of mentioned in API `AppSetting.json`



### Best Practices
Try catch are not used in controller there will be a middleware class to catch the exceptions.
