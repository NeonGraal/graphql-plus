namespace GqlPlus.Modelling.Simple;

internal class SimpleModeller
  : ModellerBase<IGqlpFieldKey, SimpleModel>
{
  protected override SimpleModel ToModel(IGqlpFieldKey ast, IMap<TypeKindModel> typeKinds)
    => ast switch {
      null => throw new ModelTypeException<IGqlpFieldKey>("Null ast"),
      { Number: not null } => SimpleModel.Num("", ast.Number.Value),
      { Text: not null } when !string.IsNullOrEmpty(ast.Text)
        => SimpleModel.Str("", ast.Text),
      { EnumType: not null } when "Boolean".Equals(ast.EnumType, StringComparison.OrdinalIgnoreCase)
        => SimpleModel.Bool("", "true".Equals(ast.EnumLabel, StringComparison.OrdinalIgnoreCase)),
      { EnumLabel: not null } when !string.IsNullOrWhiteSpace(ast.EnumLabel)
        => SimpleModel.Enum(ast.EnumType ?? "", ast.EnumLabel),
      _ => new("")
    };
}
