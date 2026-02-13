namespace CodewaveStudio.Core;

public class Wave
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Name { get; }

    public string Description { get; }

    public Wave(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Wave name must not be null or empty.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Wave description must not be null or empty.", nameof(description));
        }

        Name = name;
        Description = description;
    }
}
