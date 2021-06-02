dotnet ef migrations add "CreateDb" --project src\Common\Dotz.Fidelidade.Infrastructure --startup-project src\App\Dotz.Fidelidade.Api --output-dir Persistence\Migrations

dotnet ef database update --project src\Common\Dotz.Fidelidade.Infrastructure --startup-project src\App\Dotz.Fidelidade.Api