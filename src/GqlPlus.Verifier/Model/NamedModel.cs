namespace GqlPlus.Verifier.Model;

public record class NamedModel(string Name)
{
  public string? Description { get; set; }
}
