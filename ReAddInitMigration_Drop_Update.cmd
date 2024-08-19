cd ./SocLeader_REST
rmdir Migrations /s /q
echo Y|dotnet-ef database drop
dotnet-ef migrations add "Initial"
dotnet-ef database update
pause