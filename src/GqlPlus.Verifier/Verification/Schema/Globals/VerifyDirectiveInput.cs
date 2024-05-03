using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Verification.Schema.Globals;

internal class VerifyDirectiveInput(
  IVerifyAliased<DirectiveDeclAst> aliased
) : UsageVerifier<DirectiveDeclAst, InputDeclAst, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(DirectiveDeclAst usage, InputDeclAst[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(DirectiveDeclAst usage, UsageContext context)
  {
    foreach (Ast.Schema.ParameterAst parameter in usage.Parameters) {
      if (!context.GetType(parameter.Type.FullName, out Ast.Schema.AstDescribed? _)) {
        context.AddError(parameter, "Directive Parameter", $"'{parameter.Type}' not defined");
      }
    }
  }
}
