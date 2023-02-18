using BuildingBlocks.Persistence.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Persistence.MsSQL;
public class MsSQLDatabaseContext : DatabaseContextBase {
    public const String MsSQL_CONNECTION_STRING = "MsSQLConnectionString";
    public MsSQLDatabaseContext(DbContextOptions options) : base(options) { }
}