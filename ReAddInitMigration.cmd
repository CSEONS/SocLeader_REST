cd ./SocLeader_REST
rmdir Migrations /s /q
dotnet-ef migrations add "Initial"
pause