namespace GqlPlus.Models;

public record class AliasedModel(
  string Name
) : NamedModel(Name)
{
  public string? Description { get; set; }
  public string[] Aliases { get; set; } = [];
}

public record class DescribedModel(
  string Name
) : NamedModel(Name)
{
  public string? Description { get; set; }
}

public record class NamedModel(
  string Name
) : ModelBase
{ }
