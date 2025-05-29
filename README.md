# CareLinkBackend

To scaffold the database, navigate to the `Domain` directory and run the following command:

```bash
cd Domain
dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Username=user;Password=pass;Database=carelink" Npgsql.EntityFrameworkCore.PostgreSQL -o Entities --context-dir ../Infrastructure/Database --context DataContext --context-namespace Infrastructure.Database --namespace Domain --no-onconfiguring --force --no-pluralize
```