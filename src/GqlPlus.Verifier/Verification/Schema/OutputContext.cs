using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal record class OutputContext(IMap<AstDescribed> Types, ITokenMessages Errors, IMap<string> EnumValues)
  : UsageContext(Types, Errors)
{
  public bool GetEnumValue(string value, out string? type)
    => EnumValues.TryGetValue(value, out type);

  internal override void CheckArgumentType<TReference>(TReference type)
  {
    if (type is OutputReferenceAst output) {
      if (GetEnumValue(type.Name, out var enumType)) {
        output.EnumValue = type.Name;
        type.Name = enumType!;
      }

      if (!string.IsNullOrWhiteSpace(output.EnumValue)
        && GetType(type.TypeName, out var theType)) {
        if (theType is EnumDeclAst enumDecl) {
          if (!enumDecl.HasValue(output.EnumValue!)) {
            AddError(type, "Output Argument Enum Value", $"'{output.EnumValue}' is not a Value of '{type.Name}'");
          }
        } else {
          AddError(type, "Output Argument Enum", $"'{type.Name}' is not an Enum type");
        }

        return;
      }
    }

    base.CheckArgumentType(type);
  }
}
