namespace GqlPlus.Models;

public record class AliasedModel(
  string Name
) : NamedModel(Name)
  , IAliasedModel
{
  public string? Description { get; set; }
  public string[] Aliases { get; set; } = [];
}

public interface IAliasedModel
  : IDescribedModel
{
  string[] Aliases { get; }
}

public record class DescribedModel(
  string Name
) : NamedModel(Name)
  , IDescribedModel
{
  public string? Description { get; set; }
}

public interface IDescribedModel
  : INamedModel
{
  string? Description { get; }
}

public record class NamedModel(
  string Name
) : ModelBase
  , INamedModel
{ }

public interface INamedModel
  : IModelBase
{
  string Name { get; }
}
