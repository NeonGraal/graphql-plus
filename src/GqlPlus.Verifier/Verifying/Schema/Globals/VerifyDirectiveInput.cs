using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyDirectiveInput(IVerifierRepository verifiers) : UsageVerifier<IGqlpSchemaDirective, UsageContext>(verifiers)
{
  protected override UsageContext MakeContext(IGqlpSchemaDirective usage, IGqlpType[] aliased, IMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IGqlpSchemaDirective usage, UsageContext context)
  {
    if (usage?.Parameter is null) {
      return;
    }

    string typeName = (usage.Parameter.Type.IsTypeParam ? "$" : "") + usage.Parameter.Type.Name;
    if (context.GetType(typeName, out IAstDescribed? type)) {
      context.AddError(usage.Parameter, "Directive Param", $"'{typeName}' is an Output type", type is IGqlpObject<IGqlpOutputField>);
    } else {
      context.AddError(usage.Parameter, "Directive Param", $"'{typeName}' not defined");
    }

    context.CheckModifiers(usage.Parameter);
  }
}
