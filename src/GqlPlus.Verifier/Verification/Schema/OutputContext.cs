using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal record class OutputContext(
  IMap<AstDescribed> Types,
  ITokenMessages Errors,
  IMap<string> EnumValues
) : UsageContext(Types, Errors)
{
  internal bool GetEnumValue(string value, out string? type)
    => EnumValues.TryGetValue(value, out type);

  internal override void CheckArgumentType<TReference>(TReference type)
  {
    if (type is OutputReferenceAst output) {
      if (GetEnumValue(type.Name, out var enumType)) {
        output.EnumValue = type.Name;
        type.Name = enumType!;
      }

      if (!(string.IsNullOrWhiteSpace(output.EnumValue) || CheckEnumValue(output))) {
        AddError(type, "Output Argument Enum Value", $"'{output.EnumValue}' is not a Value of '{type.Name}'");
      }
    }

    base.CheckArgumentType(type);
  }

  internal bool CheckEnumValue(OutputReferenceAst output)
  {
    var enumType = output.Name!;
    while (GetType(enumType, out var theType)) {
      if (theType is EnumDeclAst enumDecl) {
        if (enumDecl.HasValue(output.EnumValue!)) {
          return true;
        }

        if (string.IsNullOrWhiteSpace(enumDecl.Parent)) {
          break;
        }

        enumType = enumDecl.Parent;
      } else {
        AddError(output, "Output Argument Enum", $"'{enumType}' is not an Enum type");
        break;
      }
    }

    return false;
  }
}
