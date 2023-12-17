using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarTypes(
  IVerifyAliased<ScalarDeclAst> aliased
) : AstTypeVerifier<ScalarDeclAst, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(ScalarDeclAst usage, IMap<AstType[]> byId, ITokenMessages errors)
    => MakeUsageContext(byId, errors);

  protected override void UsageValue(ScalarDeclAst usage, UsageContext context)
  {
    if (usage.Kind != ScalarKind.Union) {
      return;
    }

    foreach (var reference in usage.References) {
      if (reference.Name == usage.Name) {
        context.AddError(usage, "Scalar Reference", $"'{usage.Name}' cannot refer to self");
      } else if (context.GetType(reference.Name, out var alternate) && alternate is AstType type) {
        if (type is ScalarDeclAst scalar) {
          CheckSelfReference(usage.Name, scalar, context);
        } else if (type.Label is not "Enum") {
          context.AddError(usage, "Scalar Reference", $"Type kind mismatch for {reference.Name}. Found {type?.Label}");
        }
      } else {
        context.AddError(usage, "Scalar Reference", $"'{reference.Name}' not defined");
      }
    }
  }

  private static void CheckSelfReference(string name, ScalarDeclAst usage, UsageContext context)
  {
    foreach (var reference in usage.References) {
      if (reference.Name == name) {
        context.AddError(usage, "Scalar Reference", $"'{name}' cannot refer to self, even recursively via {usage.Name}");
      } else if (context.GetType(reference.Name, out var alternate) && alternate is ScalarDeclAst scalar) {
        CheckSelfReference(name, scalar, context);
      }
    }
  }
}
