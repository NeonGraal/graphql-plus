using GqlPlus.Abstractions.Schema;

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
      string typeName = (parameter.Type.IsTypeParam ? "$" : "") + parameter.Type.Name;
      if (context.GetType(typeName, out IGqlpDescribed? type)) {
        context.AddError(parameter, "Directive Param", $"'{typeName}' is an Output type", type is IGqlpOutputObject);
      } else {
        context.AddError(parameter, "Directive Param", $"'{typeName}' not defined");
      }

      context.CheckModifiers(parameter);
    }
  }
}
