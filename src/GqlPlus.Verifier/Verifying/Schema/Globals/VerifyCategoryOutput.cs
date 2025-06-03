using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyCategoryOutput(
  IVerifyAliased<IGqlpSchemaCategory> aliased
) : UsageVerifier<IGqlpSchemaCategory, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(IGqlpSchemaCategory usage, IGqlpType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IGqlpSchemaCategory usage, UsageContext context)
  {
    if (context.GetTyped(usage.Output.Name, out IGqlpOutputObject? output)) {
      context.AddError(usage, "Category Output", $"'{usage.Output.Name}' is a generic Output type", output.TypeParams.Any());
    } else {
      context.AddError(usage, "Category Output", $"'{usage.Output.Name}' not defined or not an Output type");
    }

    context.CheckModifiers(usage);
  }
}
