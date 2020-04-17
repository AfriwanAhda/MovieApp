# Overview
- Create a web app
- Run SQL Server container images with Docker
- Add and scaffold a model
- Work with a database (CRUD)
- Add search and validation
- Create API


# SQL Server container images with Docker configuration on macOS & Linux

Pull the SQL Server 2019 Latest container image from Docker Hub:
```groovy
pod 'AfriwanLib'
```


Launch an instance of the Docker image that just downloaded:
```groovy
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<MyPassw>" -p 1433:1433 --name sql2 -d mcr.microsoft.com/mssql/server:2019-latest
```


To view our list Docker containers, use the docker ps command:
```groovy
docker ps -a
```


Run the docker container that created before:
```groovy
docker start sql2
```


Use the docker exec -it command to start an interactive bash shell inside running container:
```groovy
sudo docker exec -it sql2 "bash"
```


Once inside the container, connect locally with sqlcmd. Sqlcmd is not in the path by default, so you have to specify the full path:
```groovy
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "<MyPassword>”
```
If successful, we should get to a sqlcmd command prompt: 1>


Create a new database: 
```groovy
CREATE DATABASE MvcMovie
```


Query to return the name of all of the databases on server: 
```groovy
SELECT Name from sys.Databases
```


Type GO on a new line to execute the previous commands:  
```groovy
GO
```


