using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyDirectiveInput(
  IVerifyAliased<IGqlpSchemaDirective> aliased
) : UsageVerifier<IGqlpSchemaDirective, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(IGqlpSchemaDirective usage, IGqlpType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IGqlpSchemaDirective usage, UsageContext context)
  {
    foreach (IGqlpInputParam parameter in usage.Params) {
      if (!context.GetType(parameter.Type.FullType, out IGqlpDescribed? _)) {
        context.AddError(parameter, "Directive Param", $"'{parameter.Type}' not defined");
      }

      context.CheckModifiers(parameter);
    }
  }
}
