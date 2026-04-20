using GqlPlus.Ast.Schema;
using GqlPlus.Modelling;

namespace GqlPlus.Resolving;

internal class TypesContext(
  IModeller<IAstType, BaseTypeModel> types
) : ModelsContext
{
  internal static TypesContext WithBuiltins(IModeller<IAstType, BaseTypeModel> types)
  {
    TypesContext typeKinds = new(types);

    typeKinds.AddTypes(BuiltIn.Basic, TypeKindModel.Basic);
    typeKinds.AddTypes(BuiltIn.Internal, TypeKindModel.Internal);

    return typeKinds;
  }

  internal void AddTypes(IAstType[] asts, TypeKindModel kind)
  {
    foreach (IAstType ast in asts) {
      this[ast.Name] = kind;

      foreach (string alias in ast.Aliases) {
        TryAdd(alias, kind);
      }
    }

    foreach (IAstType ast in asts) {
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
}
