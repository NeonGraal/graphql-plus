using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarUnion(
  IMerge<ScalarReferenceAst> members
) : AstScalarVerifier<ScalarReferenceAst>(members)
{
  protected override void VerifyScalar(AstScalar<ScalarReferenceAst> scalar, EnumContext context)
  {
    foreach (var reference in scalar.Items) {
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

    if (GetParentType(scalar.Name, scalar, context, out var parentType)) {
      CheckSelfReference(scalar.Name, parentType, context);
    }
  }

  private static void CheckSelfReference(string name, AstScalar<ScalarReferenceAst> usage, UsageContext context)
  {
    foreach (var reference in usage.Items) {
      if (reference.Name == name) {
        context.AddError(usage, "Scalar Reference", $"'{name}' cannot refer to self, even recursively via {usage.Name}");
      } else if (context.GetType(reference.Name, out var alternate) && alternate is AstScalar<ScalarReferenceAst> scalar) {
        CheckSelfReference(name, scalar, context);
      }
    }

    if (GetParentType(name, usage, context, out var parentType)) {
      CheckSelfReference(name, parentType, context);
    }
  }

  private static bool GetParentType(string name, AstScalar<ScalarReferenceAst> usage, UsageContext context, [NotNullWhen(true)] out AstScalar<ScalarReferenceAst>? parent)
  {
    parent = null;

    if (usage.Parent != name && context.GetType(usage.Parent, out var parentType) && parentType is AstScalar<ScalarReferenceAst> usageParent) {
      parent = usageParent;
    }

    return parent is not null;
  }
}
