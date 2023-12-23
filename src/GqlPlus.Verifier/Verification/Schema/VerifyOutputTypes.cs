using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyOutputTypes(
  IVerifyAliased<OutputDeclAst> aliased
) : AstObjectVerifier<OutputDeclAst, OutputFieldAst, OutputReferenceAst, OutputContext>(aliased)
{
  protected override void UsageValue(OutputDeclAst usage, OutputContext context)
  {
    var enumFields = usage.Fields
      .Where(f => !string.IsNullOrWhiteSpace(f.Type.EnumValue));

    foreach (var enumField in enumFields) {
      if (context.GetType(enumField.Type.TypeName, out var type)) {
        if (type is EnumDeclAst enumDecl) {
          if (!enumDecl.HasValue(enumField.Type.EnumValue!)) {
            context.AddError(enumField, "Output Field Enum Value", $"'{enumField.Type.EnumValue}' is not a Value of '{enumField.Type.Name}'");
          }
        } else {
          context.AddError(enumField, "Output Field Enum Value", $"'{enumField.Type.Name}' is not an Enum type");
        }
      } else {
        if (context.GetEnumValue(enumField.Type.EnumValue!, out var enumType)) {
          enumField.Type.Name = enumType!;
        } else {
          context.AddError(enumField, "Output Field Enum", $"Enum Value '{enumField.Type.EnumValue}' not defined");
        }
      }
    }

    base.UsageValue(usage, context);
  }

  protected override void UsageField(OutputFieldAst field, OutputContext context)
  {
    foreach (var parameter in field.Parameters) {
      context.CheckType(parameter.Type);

      context.CheckModifiers(parameter);
    }

    base.UsageField(field, context);
  }

  protected override OutputContext MakeContext(OutputDeclAst usage, IMap<AstType[]> byId, ITokenMessages errors)
  {
    var enumTypes = byId.Values
      .SelectMany(v => v.OfType<EnumDeclAst>())
      .Distinct();

    var enumValues = enumTypes.SelectMany(e => e.Values.Select(v => (Value: v.Name, Type: e.Name)))
      .Distinct().ToMap(e => e.Value, e => e.Type);

    var validTypes = byId
      .Select(p => (Id: p.Key, Type: (AstDescribed)p.Value.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (AstDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, enumValues);
  }
}
