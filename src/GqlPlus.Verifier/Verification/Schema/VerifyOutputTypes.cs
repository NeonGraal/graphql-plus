using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyOutputTypes(
  IVerifyAliased<OutputDeclAst> aliased,
  IMerge<TypeParameterAst> mergeTypeParameters
) : AstObjectVerifier<OutputDeclAst, OutputFieldAst, OutputReferenceAst, OutputContext>(aliased, mergeTypeParameters)
{
  protected override void UsageValue(OutputDeclAst usage, OutputContext context)
  {
    var enumFields = usage.Fields
      .Where(f => !string.IsNullOrWhiteSpace(f.Type.EnumValue));

    foreach (var enumField in enumFields) {
      if (string.IsNullOrWhiteSpace(enumField.Type.Name)) {
        if (context.GetEnumValue(enumField.Type.EnumValue!, out var enumType)) {
          enumField.Type.Name = enumType!;
        } else {
          context.AddError(enumField, "Output Field Enum", $"Enum Value '{enumField.Type.EnumValue}' not defined");
        }
      } else {
        context.CheckEnumValue("Field", enumField.Type);
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

  protected override OutputContext MakeContext(OutputDeclAst usage, AstType[] aliased, ITokenMessages errors)
  {
    var validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (AstDescribed)p.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (AstDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, aliased.MakeEnumValues());
  }
}
