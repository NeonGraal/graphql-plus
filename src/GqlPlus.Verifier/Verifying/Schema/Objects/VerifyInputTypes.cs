using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyInputTypes(
  IVerifyAliased<IGqlpInputObject> aliased,
  IMerge<IGqlpInputField> fields,
  IMerge<IGqlpAlternate<IGqlpInputBase>> mergeAlternates,
  ILoggerFactory logger
) : AstObjectVerifier<IGqlpInputObject, IGqlpInputField, IGqlpInputBase, UsageContext>(aliased, fields, mergeAlternates, logger)
{
  protected override UsageContext MakeContext(IGqlpInputObject usage, IGqlpType[] aliased, ITokenMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors);
  }

  protected override void UsageField(IGqlpInputField field, UsageContext context)
  {
    base.UsageField(field, context);

    if (field.DefaultValue?.Value?.EnumValue == "Null.null" && !(field.Modifiers.LastOrDefault()?.ModifierKind == ModifierKind.Optional)) {
      context.AddError(field, "Input Field Default", $"'null' default requires Optional type, not '{field.ModifiedType}'");
    }
  }
}
