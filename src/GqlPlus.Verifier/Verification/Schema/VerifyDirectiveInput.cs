using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyDirectiveInput(
  IVerifyAliased<DirectiveDeclAst> aliased
) : UsageAliasedVerifier<DirectiveDeclAst, InputDeclAst, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(DirectiveDeclAst usage, IMap<InputDeclAst[]> byId, ITokenMessages errors)
    => MakeUsageContext(byId, errors);

  protected override void UsageValue(DirectiveDeclAst usage, UsageContext context)
  {
    foreach (var parameter in usage.Parameters) {
      if (!context.GetType(parameter.Input.TypeName, out var _)) {
        context.AddError(parameter, $"Invalid Directive Parameter. '{parameter.Input}' not defined");
      }
    }
  }
}
