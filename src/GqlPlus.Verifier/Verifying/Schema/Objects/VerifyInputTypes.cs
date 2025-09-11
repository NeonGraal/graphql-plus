using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyInputTypes(
  ObjectVerifierParams<IGqlpInputObject, IGqlpInputField, IGqlpInputAlternate, IGqlpInputArg> verifiers
) : AstObjectVerifier<IGqlpInputObject, IGqlpInputBase, IGqlpInputArg, IGqlpInputField, IGqlpInputAlternate>(verifiers)
{
  protected override void UsageField(IGqlpInputField field, IGqlpInputObject usage, EnumContext context)
  {
    base.UsageField(field, usage, context);

    context.AddError(
      field,
      "Input Field Default",
      $"'null' default requires Optional type, not '{field.ModifiedType}'",
      field.DefaultValue?.Value?.EnumValue == "Null.null"
        && !(field.Modifiers.LastOrDefault()?.ModifierKind == ModifierKind.Optional));
  }
}
