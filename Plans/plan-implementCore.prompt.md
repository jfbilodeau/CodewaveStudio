## Plan: Core Studio Domain Models

We will add immutable-by-constructor domain classes for `Studio` and `Wave` in the Core project, using `Guid` IDs with field initializers, and `List<Wave>` to preserve order. Names and descriptions will be required (non-null/empty). We will either replace the placeholder `Class1` or add new files and remove it, keeping the Core namespace conventions. This keeps the model simple and ready for later use by the app, web, or persistence layers.

**Steps**
1. Define `Wave` in a new file under Core (e.g., [CodewaveStudio.Core/Wave.cs](CodewaveStudio.Core/Wave.cs)) with `Guid` ID field initializer, required `Name`, required `Description`, and constructor validation for non-null/empty.
2. Define `Studio` in a new file under Core (e.g., [CodewaveStudio.Core/Studio.cs](CodewaveStudio.Core/Studio.cs)) with `Guid` ID field initializer, required `Name`, and `List<Wave>` for ordered waves; constructor validates `Name` and copies the input list (or initializes to empty).
3. Remove the placeholder `Class1` or repurpose it by replacing its contents with one of the new domain classes, keeping namespace `CodewaveStudio.Core` consistent with [CodewaveStudio.Core/Class1.cs](CodewaveStudio.Core/Class1.cs#L1-L6).

**Verification**
- Build the solution or Core project: `dotnet build`.
- Optional: add quick unit tests later to validate constructor guards and ordering.

**Decisions**
- Use `Guid` IDs via field initializer (per your preference) to ensure unique identifiers without caller involvement.
- Enforce non-null/empty `Name` and `Description`.
- Use `List<Wave>` to preserve ordering; constructors will defensively copy to keep instances effectively immutable.
