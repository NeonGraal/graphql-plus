using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyOutputTypes(IVerifierRepository verifiers)
  : AstObjectVerifier<IGqlpOutputField>(verifiers, TypeKind.Output)
{
  protected override void UsageField(IGqlpOutputField field, IGqlpObject<IGqlpOutputField> usage, ObjectContext context)
  {
    base.UsageField(field, usage, context);

    if (field.Parameter is null) {
      return;
    }

    HashSet<TypeKind> inputKinds = [TypeKind.Input, .. context.FieldKinds.Where(k => k != TypeKind.Output)];

    CheckTypeRef(context, field.Parameter.Type, "Param of " + usage.Name, inputKinds);
    context.CheckModifiers(field.Parameter);
  }
}
