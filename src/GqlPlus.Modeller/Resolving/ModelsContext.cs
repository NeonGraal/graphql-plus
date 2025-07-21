using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Resolving;

internal class ModelsContext
  : Map<TypeKindModel>
  , IModelsContext
{
  internal IMap<IModelBase> Types { get; } = new Map<IModelBase>();
  public IMessages Errors { get; } = Messages.New;
  IMap<TypeKindModel> IModelsContext.TypeKinds => this;

  public void AddModels(IEnumerable<BaseTypeModel> models)
  {
    foreach (BaseTypeModel model in models) {
      Types.Add(model.Name, model);

      foreach (string alias in model.Aliases) {
        Types.TryAdd(alias, model);
      }
    }
  }

  public bool TryGetType<TModel>(string label, string? name, [NotNullWhen(true)] out TModel? model, bool canError = true)
    where TModel : IModelBase
  {
    if (!name.IsWhiteSpace()) {
      if (Types.TryGetValue(name!, out IModelBase? type) && type is TModel modelType) {
        model = modelType;
        return true;
      }

      if (canError) {
        Errors.Add(new TokenMessage(TokenKind.End, 0, 0, "", $"In {label} can't get model for type '{name}'"));
      }
    }

    model = default;
    return false;
  }
}

public interface IModelsContext
  : IResolveContext
{
  IMap<TypeKindModel> TypeKinds { get; }
  IMessages Errors { get; }
  void AddModels(IEnumerable<BaseTypeModel> models);
}
