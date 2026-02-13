namespace CodewaveStudio.Core;

public class JfCode
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Nomen { get; }

    public double Complexitas { get; }

    public int NumerusVerborumClavis { get; }

    public JfCode(string nomen, double complexitas, int numerusVerborumClavis)
    {
        if (string.IsNullOrWhiteSpace(nomen))
        {
            throw new ArgumentException("Nomen must not be null or empty.", nameof(nomen));
        }

        if (complexitas < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(complexitas), "Complexitas must be non-negative.");
        }

        if (numerusVerborumClavis < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numerusVerborumClavis), "NumerusVerborumClavis must be non-negative.");
        }

        Nomen = nomen;
        Complexitas = complexitas;
        NumerusVerborumClavis = numerusVerborumClavis;
    }
}
