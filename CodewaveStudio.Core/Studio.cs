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

    /// <summary>
    /// Adds a wave to the studio.
    /// </summary>
    /// <param name="wave">The wave to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when wave is null.</exception>
    public void AddWave(Wave wave)
    {
        if (wave == null)
        {
            throw new ArgumentNullException(nameof(wave), "Wave must not be null.");
        }

        Waves.Add(wave);
    }

    /// <summary>
    /// Removes a wave from the studio.
    /// </summary>
    /// <param name="wave">The wave to remove.</param>
    /// <returns>True if the wave was removed, false otherwise.</returns>
    public bool RemoveWave(Wave wave)
    {
        if (wave == null)
        {
            return false;
        }

        return Waves.Remove(wave);
    }

    /// <summary>
    /// Removes a wave from the studio by its ID.
    /// </summary>
    /// <param name="id">The ID of the wave to remove.</param>
    /// <returns>True if the wave was removed, false otherwise.</returns>
    public bool RemoveWaveById(Guid id)
    {
        var wave = Waves.FirstOrDefault(w => w.Id == id);
        if (wave == null)
        {
            return false;
        }

        return Waves.Remove(wave);
    }

    /// <summary>
    /// Retrieves a wave by its ID.
    /// </summary>
    /// <param name="id">The ID of the wave to retrieve.</param>
    /// <returns>The wave if found, null otherwise.</returns>
    public Wave? GetWaveById(Guid id)
    {
        return Waves.FirstOrDefault(w => w.Id == id);
    }

    /// <summary>
    /// Clears all waves from the studio.
    /// </summary>
    public void ClearWaves()
    {
        Waves.Clear();
    }
}
