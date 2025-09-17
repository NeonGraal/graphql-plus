using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyInputTypes(
  ObjectVerifierParams<IGqlpInputObject, IGqlpInputField, IGqlpInputAlternate> verifiers
) : AstObjectVerifier<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>(verifiers)
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
