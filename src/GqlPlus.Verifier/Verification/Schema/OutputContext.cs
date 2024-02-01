﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal record class OutputContext(
  IMap<AstDescribed> Types,
  ITokenMessages Errors,
  IMap<string> EnumValues
) : EnumContext(Types, Errors, EnumValues)
{

  internal override void CheckArgumentType<TReference>(TReference type)
  {
    if (type is OutputReferenceAst output) {
      if (string.IsNullOrWhiteSpace(output.EnumValue) && GetEnumValue(type.Name, out var enumType)) {
        output.EnumValue = type.Name;
        type.Name = enumType!;
      }

      if (!string.IsNullOrWhiteSpace(output.EnumValue)) {
        CheckEnumValue("Argument", output);
      }

      base.CheckArgumentType(type);
    }
  }

  internal void CheckEnumValue(string label, OutputReferenceAst output)
  {
    if (GetEnumType(output.Name, out var theType)) {
      if (!GetEnumValueType(theType, output.EnumValue ?? "", out var _)) {
        AddError(output, $"Output {label} Enum Value", $"'{output.EnumValue}' not a Value of '{output.Name}'");
      }
    } else {
      AddError(output, $"Output {label} Enum", $"'{output.Name}' is not an Enum type");
    }
  }
}
