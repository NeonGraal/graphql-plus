using System.Diagnostics.CodeAnalysis;

using GqlPlus.Modelling;

namespace GqlPlus.Resolving;

internal class TypesContext(
  ITypesModeller types
) : Map<TypeKindModel>
  , ITypesContext
{
  internal IMap<IModelBase> Types { get; } = new Map<IModelBase>();
  public ITokenMessages Errors { get; } = new TokenMessages();
  IMap<TypeKindModel> ITypesContext.TypeKinds => this;

  internal static TypesContext WithBuiltins(ITypesModeller types)
  {
    TypesContext typeKinds = new(types);

    typeKinds.AddTypes(BuiltIn.Basic, TypeKindModel.Basic);
    typeKinds.AddTypes(BuiltIn.Internal, TypeKindModel.Internal);

    return typeKinds;
  }

  internal void AddTypes(IGqlpType[] asts, TypeKindModel kind)
  {
    foreach (IGqlpType ast in asts) {
      this[ast.Name] = kind;

      foreach (string alias in ast.Aliases) {
        TryAdd(alias, kind);
      }
    }

    foreach (IGqlpType ast in asts) {
      try {
        BaseTypeModel? model = types.TryModel(ast, this);
        if (model is not null) {
          Types[model.Name] = model;
          foreach (string alias in ast.Aliases) {
            Types.TryAdd(alias, model);
          }
        }
      } catch (InvalidOperationException) { }
    }
  }

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
    if (name is not null) {
      if (Types.TryGetValue(name, out IModelBase? type) && type is TModel modelType) {
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

public interface ITypesContext
  : IResolveContext
{
  IMap<TypeKindModel> TypeKinds { get; }
  ITokenMessages Errors { get; }
  void AddModels(IEnumerable<BaseTypeModel> models);
}
