package codewavestudio.core;

import java.util.UUID;

public final class Code {
    private final UUID id = UUID.randomUUID();
    private final String name;
    private final double complexity;
    private final int keywordCount;

    public Code(String name, double complexity, int keywordCount) {
        if (name == null || name.isBlank()) {
            throw new IllegalArgumentException("name must not be null or blank");
        }
        if (complexity < 0) {
            throw new IllegalArgumentException("complexity must be non-negative");
        }
        if (keywordCount < 0) {
            throw new IllegalArgumentException("keywordCount must be non-negative");
        }
        this.name = name;
        this.complexity = complexity;
        this.keywordCount = keywordCount;
    }

    public UUID getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public double getComplexity() {
        return complexity;
    }

    public int getKeywordCount() {
        return keywordCount;
    }

    @Override
    public String toString() {
        return "Code{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", complexity=" + complexity +
                ", keywordCount=" + keywordCount +
                '}';
    }
}
