namespace GqlPlus.Models;

public record class ModelBase
  : IModelBase
{
  private string? _tag;

  internal virtual string Tag => _tag ??= GetType().TypeTag();
}

#pragma warning disable CA1040 // Avoid empty interfaces
public interface IModelBase
{ }
