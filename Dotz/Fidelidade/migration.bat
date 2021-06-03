dotnet clean

docker exec -i dotz-fidelidade-db mysql -uroot -p123456  -e "DROP DATABASE FIDELIDADE;"

docker exec -i dotz-fidelidade-db mysql -uroot -p123456  -e "CREATE DATABASE FIDELIDADE;"

del /S /q .\src\Common\Dotz.Fidelidade.Infrastructure\Persistence\Migrations

dotnet ef migrations add "InitialCreate" --project src\Common\Dotz.Fidelidade.Infrastructure --startup-project src\App\Dotz.Fidelidade.Api --output-dir Persistence\Migrations

dotnet ef database update --project src\Common\Dotz.Fidelidade.Infrastructure --startup-project src\App\Dotz.Fidelidade.Api