using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyOutputTypes(
  IVerifyAliased<OutputDeclAst> aliased,
  IMerge<OutputFieldAst> mergeFields,
  IMerge<AstAlternate<OutputBaseAst>> mergeAlternates,
  ILoggerFactory logger
) : AstObjectVerifier<OutputDeclAst, OutputFieldAst, OutputBaseAst, OutputContext>(aliased, mergeFields, mergeAlternates, logger)
{
  protected override void UsageValue(OutputDeclAst usage, OutputContext context)
  {
    IEnumerable<OutputFieldAst> enumFields = usage.Fields
      .Where(f => !string.IsNullOrWhiteSpace(f.Type.EnumValue));

    foreach (OutputFieldAst? enumField in enumFields) {
      if (string.IsNullOrWhiteSpace(enumField.Type.Name)) {
        if (context.GetEnumValue(enumField.Type.EnumValue!, out string? enumType)) {
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
    foreach (InputParameterAst parameter in field.Parameters) {
      context.CheckType(parameter.Type, " Parameter");

      context.CheckModifiers(parameter);
    }

    base.UsageField(field, context);
  }

  protected override OutputContext MakeContext(OutputDeclAst usage, IGqlpType[] aliased, ITokenMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, aliased.MakeEnumValues());
  }
}
