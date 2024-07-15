using System.Diagnostics.CodeAnalysis;

using GqlPlus.Modelling;

namespace GqlPlus.Resolving;

internal class TypesCollection(
  ITypesModeller types
) : Map<TypeKindModel>
  , IResolveContext
{
  internal IMap<BaseTypeModel> Types { get; } = new Map<BaseTypeModel>();
  internal ITokenMessages Errors { get; } = new TokenMessages();

  internal static TypesCollection WithBuiltins(ITypesModeller types)
  {
    TypesCollection typeKinds = new(types);

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

  public bool TryGetType<TModel>(string context, string? name, [NotNullWhen(true)] out TModel? model)
    where TModel : IModelBase
  {
    if (name is not null) {
      if (Types.TryGetValue(name, out BaseTypeModel? type) && type is TModel modelType) {
        model = modelType;
        return true;
      }

      Errors.Add(new TokenMessage(TokenKind.End, 0, 0, "", $"In {context} can't get model for type '{name}'"));
    }

    model = default;
    return false;
  }
}
