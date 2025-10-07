using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyOutputTypes(
  ObjectVerifierParams<IGqlpOutputObject, IGqlpOutputField> verifiers
) : AstObjectVerifier<IGqlpOutputObject, IGqlpOutputField>(TypeKind.Output, verifiers)
{
  protected override void UsageField(IGqlpOutputField field, IGqlpOutputObject usage, ObjectContext context)
  {
    base.UsageField(field, usage, context);

    foreach (IGqlpInputParam parameter in field.Params) {
      HashSet<TypeKind> inputKinds = [TypeKind.Input, .. context.FieldKinds.Where(k => k != TypeKind.Output)];

      CheckTypeRef(context, parameter.Type, "Param of " + usage.Name, inputKinds);
      context.CheckModifiers(parameter);
    }
  }
}
