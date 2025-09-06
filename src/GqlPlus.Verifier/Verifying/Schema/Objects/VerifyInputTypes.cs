﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyInputTypes(
  ObjectVerifierParams<IGqlpInputObject, IGqlpInputField, IGqlpInputAlternate, IGqlpInputArg> verifiers
) : AstObjectVerifier<IGqlpInputObject, IGqlpInputBase, IGqlpInputArg, IGqlpInputField, IGqlpInputAlternate, EnumContext>(verifiers)
{
  protected override EnumContext MakeContext(IGqlpInputObject usage, IGqlpType[] aliased, IMessages errors)
  {
    Map<IGqlpDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (IGqlpDescribed)p.First()))
      .Concat(usage.TypeParams.Select(p => (Id: "$" + p.Name, Type: (IGqlpDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors, aliased.MakeEnumValues());
  }

  protected override void UsageFields(IGqlpInputObject usage, EnumContext context)
  {
    base.UsageFields(usage, context);

    foreach (IGqlpInputField field in usage.ObjFields) {
      context.AddError(
        field,
        "Input Field Default",
        $"'null' default requires Optional type, not '{field.ModifiedType}'",
        field.DefaultValue?.Value?.EnumValue == "Null.null"
          && !(field.Modifiers.LastOrDefault()?.ModifierKind == ModifierKind.Optional));
    }
  }
}
