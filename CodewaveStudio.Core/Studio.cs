namespace CodewaveStudio.Core;

public class Studio
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Name { get; }

    public List<Wave> Waves { get; }

    public Studio(string name, IEnumerable<Wave>? waves = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Studio name must not be null or empty.", nameof(name));
        }

        Name = name;
        Waves = waves is null ? new List<Wave>() : new List<Wave>(waves);

        if (Waves.Contains(null))
        {
            throw new ArgumentException("Waves collection must not contain null entries.", nameof(waves));
        }
    }
}
