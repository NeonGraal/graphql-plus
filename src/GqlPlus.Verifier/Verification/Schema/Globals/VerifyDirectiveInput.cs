using GqlPlus.Verifier.Ast.Schema.Globals;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema.Globals;

internal class VerifyDirectiveInput(
  IVerifyAliased<DirectiveDeclAst> aliased
) : UsageVerifier<DirectiveDeclAst, InputDeclAst, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(DirectiveDeclAst usage, InputDeclAst[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(DirectiveDeclAst usage, UsageContext context)
  {
    foreach (var parameter in usage.Parameters) {
      if (!context.GetType(parameter.Type.FullName, out var _)) {
        context.AddError(parameter, "Directive Parameter", $"'{parameter.Type}' not defined");
      }
    }
  }
}
