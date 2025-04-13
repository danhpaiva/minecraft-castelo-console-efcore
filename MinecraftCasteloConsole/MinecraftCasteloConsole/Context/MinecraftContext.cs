using Microsoft.EntityFrameworkCore;
using MinecraftCasteloConsole.Models;

namespace MinecraftCasteloConsole.Context;

public class MinecraftContext : DbContext
{
    public DbSet<Consulta> Consultas { get; set; }

    public string DbPath { get; }

    public MinecraftContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "database_mine.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
