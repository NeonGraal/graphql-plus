namespace GqlPlus.Modelling.Simple;

internal class SimpleModeller
  : ModellerBase<IGqlpFieldKey, SimpleModel>
{
  protected override SimpleModel ToModel(IGqlpFieldKey ast, IMap<TypeKindModel> typeKinds)
    => ast.Number.HasValue ? SimpleModel.Num("", ast.Number.Value)
    : ast.Text is not null ? SimpleModel.Str("", ast.Text)
    : "Boolean".Equals(ast.EnumType, StringComparison.OrdinalIgnoreCase) ? SimpleModel.Bool("true".Equals(ast.EnumMember, StringComparison.OrdinalIgnoreCase))
    : ast.EnumType is not null ? SimpleModel.Enum(ast.EnumType, ast.EnumMember ?? "")
    : new();
}
