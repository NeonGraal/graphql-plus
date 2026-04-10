using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyInputTypes(IVerifierRepository verifiers)
  : AstObjectVerifier<IAstInputField>(verifiers, TypeKind.Input)
{
  protected override void UsageField(IAstInputField field, IAstObject<IAstInputField> usage, ObjectContext context)
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
