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
      HashSet<TypeKind> inputKinds = context.FieldKinds;
      inputKinds.Remove(TypeKind.Output);
      inputKinds.Add(TypeKind.Input);

      CheckTypeRef(context, parameter.Type, " Param", inputKinds);
      context.CheckModifiers(parameter);
    }
  }
}
