namespace GqlPlus.Verifier.Model;

public record class AliasedModel(string Name) : NamedModel(Name)
{
  public string[] Aliases { get; set; } = [];
}
