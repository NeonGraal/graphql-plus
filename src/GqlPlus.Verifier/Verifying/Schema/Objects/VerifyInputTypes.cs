using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyInputTypes(
  ObjectVerifierParams<IGqlpInputField> verifiers
) : AstObjectVerifier<IGqlpInputField>(verifiers)
{
  protected override void UsageField(IGqlpInputField field, IGqlpObject<IGqlpInputField> usage, ObjectContext context)
  {
    base.UsageField(field, usage, context);

    context.AddError(
      field,
      "Input Field Default",
      $"'null' default requires Optional type, not '{field.ModifiedType}'",
      field.DefaultValue?.Value?.EnumValue?.EnumValue == "Null.null"
        && !(field.Modifiers.LastOrDefault()?.ModifierKind == ModifierKind.Optional));
  }
}
