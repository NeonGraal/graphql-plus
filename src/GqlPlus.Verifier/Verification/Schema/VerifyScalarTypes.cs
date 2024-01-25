using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarTypes(
  IVerifyAliased<AstScalar> aliased
) : AstTypeVerifier<AstScalar, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(AstScalar usage, IMap<AstType[]> byId, ITokenMessages errors)
    => MakeUsageContext(byId, errors);

  protected override void UsageValue(AstScalar usage, UsageContext context)
  {
    if (usage.Kind == ScalarKind.Union && usage is AstScalar<ScalarReferenceAst> scalar) {
      CheckReferences(scalar, context);
    }
  }

  private static void CheckReferences(AstScalar<ScalarReferenceAst> usage, UsageContext context)
  {
    foreach (var reference in usage.Members) {
      if (reference.Name == usage.Name) {
        context.AddError(usage, "Scalar Reference", $"'{usage.Name}' cannot refer to self");
      } else if (context.GetType(reference.Name, out var alternate) && alternate is AstType type) {
        if (type is AstScalar<ScalarReferenceAst> scalar) {
          CheckSelfReference(usage.Name, scalar, context);
        } else if (type.Label is not "Enum" and not "Scalar" and not "All") {
          context.AddError(usage, "Scalar Reference", $"Type kind mismatch for {reference.Name}. Found {type?.Label}");
        }
      } else {
        context.AddError(usage, "Scalar Reference", $"'{reference.Name}' not defined");
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
