using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarUnion
  : AstScalarVerifier<ScalarReferenceAst>
{
  protected override void VerifyScalar(AstScalar<ScalarReferenceAst> scalar, UsageContext context)
  {
    base.VerifyScalar(scalar, context);

    foreach (var reference in scalar.Members) {
      if (reference.Name == scalar.Name) {
        context.AddError(scalar, "Scalar Reference", $"'{scalar.Name}' cannot refer to self");
      } else if (context.GetType(reference.Name, out var alternate) && alternate is AstType type) {
        if (type is AstScalar<ScalarReferenceAst> typeScalar) {
          CheckSelfReference(scalar.Name, typeScalar, context);
        } else if (type.Label is not "Enum" and not "Scalar" and not "All") {
          context.AddError(scalar, "Scalar Reference", $"Type kind mismatch for {reference.Name}. Found {type?.Label}");
        }
      } else {
        context.AddError(scalar, "Scalar Reference", $"'{reference.Name}' not defined");
      }
    }
  }

  private static void CheckSelfReference(string name, AstScalar<ScalarReferenceAst> usage, UsageContext context)
  {
    foreach (var reference in usage.Members) {
      if (reference.Name == name) {
        context.AddError(usage, "Scalar Reference", $"'{name}' cannot refer to self, even recursively via {usage.Name}");
      } else if (context.GetType(reference.Name, out var alternate) && alternate is AstScalar<ScalarReferenceAst> scalar) {
        CheckSelfReference(name, scalar, context);
      }
    }
  }
}
