namespace GqlPlus.Models;

public record class ModelBase
  : IModelBase
{
  private string? _tag;

  internal virtual string Tag => _tag ??= GetType().TypeTag();

  string IModelBase.Tag => Tag;
}

public interface IModelBase
{
  string Tag { get; }
}
