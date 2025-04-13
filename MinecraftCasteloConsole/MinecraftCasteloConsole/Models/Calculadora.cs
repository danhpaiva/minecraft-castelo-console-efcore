using MinecraftCasteloConsole.Enums;

namespace MinecraftCasteloConsole.Models;

public class Calculadora
{
    public double CalcularTempoConstrucao(TipoMaterial material, int numeroConstrutores)
    {
        if (numeroConstrutores <= 0)
        {
            throw new ArgumentException("O número de construtores deve ser maior que zero.");
        }

        double tempoBaseHoras = material switch
        {
            TipoMaterial.Madeira => 100,
            TipoMaterial.Ouro => 50,
            TipoMaterial.Diamante => 25,
            _ => throw new ArgumentException("Tipo de material inválido.")
        };

        double tempoFinalHoras = tempoBaseHoras;

        // Aplica a redução pela metade para cada construtor adicional
        for (int i = 1; i < numeroConstrutores; i++)
        {
            tempoFinalHoras /= 2;
        }

        return tempoFinalHoras;
    }
}
