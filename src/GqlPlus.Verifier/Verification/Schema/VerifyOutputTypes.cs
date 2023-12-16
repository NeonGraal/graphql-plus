using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyOutputTypes(
  IVerifyAliased<OutputDeclAst> aliased
) : AstObjectTypesVerifier<OutputDeclAst, OutputFieldAst, OutputReferenceAst, OutputContext>(aliased)
{
  public override string Label => "Output";

  protected override void UsageValue(OutputDeclAst usage, OutputContext context)
  {
    var enumFields = usage.Fields
      .Where(f => !string.IsNullOrWhiteSpace(f.EnumValue));

    foreach (var enumField in enumFields) {
      if (context.GetType(enumField.Type.Name, out var type)) {
        if (type is EnumDeclAst enumDecl) {
          if (!enumDecl.HasValue(enumField.EnumValue!)) {
            context.AddError(enumField, $"Invalid Output Field Enum Value. '{enumField.EnumValue}' is not a Value of '{enumField.Type.Name}'");
          }
        } else {
          context.AddError(enumField, $"Invalid Output Field Enum. '{enumField.Type.Name}' is not an Enum type");
        }
      } else {
        if (context.GetEnumValue(enumField.EnumValue!, out var enumType)) {
          enumField.Type = new(enumField.At, enumType!);
        } else {
          context.AddError(enumField, $"Invalid Output Field Enum. Enum Value '{enumField.EnumValue}' not defined.");
        }
      }
    }

    base.UsageValue(usage, context);
  }

  protected override void CheckArgumentType(OutputReferenceAst type, OutputContext context)
  {
    if (context.GetEnumValue(type.Name, out var enumType)) {
      type.EnumValue = type.Name;
      type.Name = enumType!;
    }

    if (!string.IsNullOrWhiteSpace(type.EnumValue)
      && context.GetType(type.Name, out var theType)) {
      if (theType is EnumDeclAst enumDecl) {
        if (!enumDecl.HasValue(type.EnumValue!)) {
          context.AddError(type, $"Invalid Output Argument Enum Value. '{type.EnumValue}' is not a Value of '{type.Name}'");
        }
      } else {
        context.AddError(type, $"Invalid Output Argument Enum. '{type.Name}' is not an Enum type");
      }
    } else {
      base.CheckArgumentType(type, context);
    }
  }

  protected override OutputContext MakeContext(OutputDeclAst usage, IMap<AstType[]> byId, ITokenMessages errors)
  {
    var enumTypes = byId.Values
      .SelectMany(v => v.OfType<EnumDeclAst>())
      .Distinct().ToArray();

    var enumValues = enumTypes.SelectMany(e => e.Values.Select(v => (Value: v.Name, Type: e.Name)))
      .Distinct().ToMap(e => e.Value, e => e.Type);

    var validTypes = byId
      .Select(p => (Id: p.Key, Type: (AstDescribed)p.Value.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (AstDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, enumValues);
  }
}

internal record class OutputContext(IMap<AstDescribed> Types, ITokenMessages Errors, IMap<string> EnumValues)
  : UsageContext(Types, Errors)
{
  public bool GetEnumValue(string value, out string? type)
    => EnumValues.TryGetValue(value, out type);
}
