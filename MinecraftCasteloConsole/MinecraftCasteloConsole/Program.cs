using Microsoft.EntityFrameworkCore;
using MinecraftCasteloConsole.Context;
using MinecraftCasteloConsole.Enums;
using MinecraftCasteloConsole.Models;

var calculadora = new Calculadora();

var tempoMadeira = calculadora.CalcularTempoConstrucao(TipoMaterial.Madeira, 1);
Console.WriteLine($"Tempo para construir castelo de madeira com 1 construtores: {tempoMadeira} horas");

var tempoOuro = calculadora.CalcularTempoConstrucao(TipoMaterial.Ouro, 2);
Console.WriteLine($"Tempo para construir castelo de ouro com 2 construtores: {tempoOuro} horas");

var tempoDiamante = calculadora.CalcularTempoConstrucao(TipoMaterial.Diamante, 5);
Console.WriteLine($"Tempo para construir castelo de diamante com 5 construtores: {tempoDiamante} horas");

using var db = new MinecraftContext();

// Note: Este exemplo cria o banco antes de rodar o app.
Console.WriteLine($"\nDatabase local: {db.DbPath}.");

Console.WriteLine("\nInserindo uma nova consulta no DB:");
db.Add(new Consulta
{
    MaterialUtilizado = TipoMaterial.Madeira.ToString(),
    QtdeConstrutores = 1,
    TempoGasto = tempoMadeira.ToString()
});
await db.SaveChangesAsync();

Console.WriteLine("\nLendo uma consulta");
var consulta = await db.Consultas
    .OrderBy(c => c.ConsultaId)
    .FirstOrDefaultAsync();

Console.WriteLine("\nID: " + consulta.ConsultaId);
Console.WriteLine("Tipo Material: " + consulta.MaterialUtilizado);
Console.WriteLine("Quantidade Construtores: " + consulta.QtdeConstrutores);
Console.WriteLine("Tempo Gasto: " + consulta.TempoGasto);

Console.WriteLine("\nDeletando a consulta...");
db.Remove(consulta);
await db.SaveChangesAsync();