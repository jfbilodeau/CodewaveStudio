using CodewaveStudio.Core;

namespace CodewaveStudio.Test;

public class StudioTests
{
    [Fact]
    public void AddWave_ShouldAddWaveToStudio()
    {
        // Arrange
        var studio = new Studio("Test Studio");
        var wave = new Wave("Wave 1", "Description 1");

        // Act
        studio.AddWave(wave);

        // Assert
        Assert.Single(studio.Waves);
        Assert.Contains(wave, studio.Waves);
    }

    [Fact]
    public void AddWave_ShouldThrowArgumentNullException_WhenWaveIsNull()
    {
        // Arrange
        var studio = new Studio("Test Studio");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => studio.AddWave(null));
    }

    [Fact]
    public void AddWave_ShouldAddMultipleWaves()
    {
        // Arrange
        var studio = new Studio("Test Studio");
        var wave1 = new Wave("Wave 1", "Description 1");
        var wave2 = new Wave("Wave 2", "Description 2");

        // Act
        studio.AddWave(wave1);
        studio.AddWave(wave2);

        // Assert
        Assert.Equal(2, studio.Waves.Count);
        Assert.Contains(wave1, studio.Waves);
        Assert.Contains(wave2, studio.Waves);
    }

    [Fact]
    public void RemoveWave_ShouldRemoveWaveFromStudio()
    {
        // Arrange
        var wave = new Wave("Wave 1", "Description 1");
        var studio = new Studio("Test Studio", new[] { wave });

        // Act
        var result = studio.RemoveWave(wave);

        // Assert
        Assert.True(result);
        Assert.Empty(studio.Waves);
    }

    [Fact]
    public void RemoveWave_ShouldReturnFalse_WhenWaveNotFound()
    {
        // Arrange
        var wave1 = new Wave("Wave 1", "Description 1");
        var wave2 = new Wave("Wave 2", "Description 2");
        var studio = new Studio("Test Studio", new[] { wave1 });

        // Act
        var result = studio.RemoveWave(wave2);

        // Assert
        Assert.False(result);
        Assert.Single(studio.Waves);
    }

    [Fact]
    public void RemoveWave_ShouldReturnFalse_WhenWaveIsNull()
    {
        // Arrange
        var studio = new Studio("Test Studio");

        // Act
        var result = studio.RemoveWave(null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void RemoveWaveById_ShouldRemoveWaveFromStudio()
    {
        // Arrange
        var wave = new Wave("Wave 1", "Description 1");
        var studio = new Studio("Test Studio", new[] { wave });

        // Act
        var result = studio.RemoveWaveById(wave.Id);

        // Assert
        Assert.True(result);
        Assert.Empty(studio.Waves);
    }

    [Fact]
    public void RemoveWaveById_ShouldReturnFalse_WhenIdNotFound()
    {
        // Arrange
        var wave = new Wave("Wave 1", "Description 1");
        var studio = new Studio("Test Studio", new[] { wave });
        var nonExistentId = Guid.NewGuid();

        // Act
        var result = studio.RemoveWaveById(nonExistentId);

        // Assert
        Assert.False(result);
        Assert.Single(studio.Waves);
    }

    [Fact]
    public void GetWaveById_ShouldReturnWave_WhenIdExists()
    {
        // Arrange
        var wave = new Wave("Wave 1", "Description 1");
        var studio = new Studio("Test Studio", new[] { wave });

        // Act
        var result = studio.GetWaveById(wave.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(wave, result);
    }

    [Fact]
    public void GetWaveById_ShouldReturnNull_WhenIdNotFound()
    {
        // Arrange
        var wave = new Wave("Wave 1", "Description 1");
        var studio = new Studio("Test Studio", new[] { wave });
        var nonExistentId = Guid.NewGuid();

        // Act
        var result = studio.GetWaveById(nonExistentId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ClearWaves_ShouldRemoveAllWaves()
    {
        // Arrange
        var wave1 = new Wave("Wave 1", "Description 1");
        var wave2 = new Wave("Wave 2", "Description 2");
        var studio = new Studio("Test Studio", new[] { wave1, wave2 });

        // Act
        studio.ClearWaves();

        // Assert
        Assert.Empty(studio.Waves);
    }

    [Fact]
    public void ClearWaves_ShouldHandleEmptyStudio()
    {
        // Arrange
        var studio = new Studio("Test Studio");

        // Act
        studio.ClearWaves();

        // Assert
        Assert.Empty(studio.Waves);
    }
}
