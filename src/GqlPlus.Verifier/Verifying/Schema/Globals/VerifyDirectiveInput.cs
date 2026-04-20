using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyDirectiveInput(IVerifierRepository verifiers) : UsageVerifier<IAstSchemaDirective, UsageContext>(verifiers)
{
  protected override UsageContext MakeContext(IAstSchemaDirective usage, IAstType[] aliased, IMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IAstSchemaDirective usage, UsageContext context)
  {
    if (usage?.Parameter is null) {
      return;
    }

    string typeName = (usage.Parameter.Type.IsTypeParam ? "$" : "") + usage.Parameter.Type.Name;
    if (context.GetType(typeName, out IAstDescribed? type)) {
      context.AddError(usage.Parameter, "Directive Param", $"'{typeName}' is an Output type", type is IAstObject<IAstOutputField>);
    } else {
      context.AddError(usage.Parameter, "Directive Param", $"'{typeName}' not defined");
    }

    context.CheckModifiers(usage.Parameter);
  }

  internal static VerifyDirectiveInput Factory(IVerifierRepository v) => new(v);
}
