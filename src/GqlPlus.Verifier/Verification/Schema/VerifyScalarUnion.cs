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
      if (CheckReference(scalar.Name, reference, context, CheckTypeLabel)) {
        context.AddError(scalar, "Scalar Reference", $"'{reference.Name}' not defined");
      }
    }

    if (GetParentType(scalar.Name, scalar, context, out var parentType)) {
      CheckSelfReference(scalar.Name, parentType, context);
    }

    void CheckTypeLabel(string name, AstType type)
    {
      if (type.Label is not "Enum" and not "Scalar" and not "All") {
        context.AddError(scalar, "Scalar Reference", $"Type kind mismatch for {name}. Found {type?.Label}");
      }
    }
  }

  private static bool CheckReference(string name, ScalarReferenceAst reference, EnumContext context, Action<string, AstType>? checkType = null)
  {
    if (reference.Name == name) {
      context.AddError(reference, "Scalar Reference", $"'{name}' cannot refer to " + (checkType is null ? "self, even recursively" : "self"));
      return false;
    } else if (context.GetType(reference.Name, out var alternate) && alternate is AstType type) {
      if (type is AstScalar<ScalarReferenceAst> typeScalar) {
        CheckSelfReference(name, typeScalar, context);
      } else {
        checkType?.Invoke(reference.Name, type);
      }

      return false;
    }

    return true;
  }

  private static void CheckSelfReference(string name, AstScalar<ScalarReferenceAst> usage, EnumContext context)
  {
    foreach (var reference in usage.Items) {
      CheckReference(name, reference, context);
    }

    if (GetParentType(name, usage, context, out var parentType)) {
      CheckSelfReference(name, parentType, context);
    }
  }

  private static bool GetParentType(string name, AstScalar<ScalarReferenceAst> usage, EnumContext context, [NotNullWhen(true)] out AstScalar<ScalarReferenceAst>? parent)
  {
    parent = null;

    if (usage.Parent != name && context.GetType(usage.Parent, out var parentType) && parentType is AstScalar<ScalarReferenceAst> usageParent) {
      parent = usageParent;
    }

    return parent is not null;
  }
}
