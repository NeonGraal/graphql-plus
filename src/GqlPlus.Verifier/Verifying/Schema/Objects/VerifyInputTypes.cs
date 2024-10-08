﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyInputTypes(
  IVerifyAliased<IGqlpInputObject> aliased,
  IMerge<IGqlpInputField> fields,
  IMerge<IGqlpInputAlternate> mergeAlternates,
  ILoggerFactory logger
) : AstObjectVerifier<IGqlpInputObject, IGqlpInputBase, IGqlpInputArg, IGqlpInputField, IGqlpInputAlternate, UsageContext>(aliased, fields, mergeAlternates, logger)
{
  protected override UsageContext MakeContext(IGqlpInputObject usage, IGqlpType[] aliased, ITokenMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParams.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors);
  }

  protected override void UsageField(IGqlpInputField field, UsageContext context)
  {
    base.UsageField(field, context);

    context.AddError(
      field,
      "Input Field Default",
      $"'null' default requires Optional type, not '{field.ModifiedType}'",
      field.DefaultValue?.Value?.EnumValue == "Null.null"
        && !(field.Modifiers.LastOrDefault()?.ModifierKind == ModifierKind.Optional));
  }
}
