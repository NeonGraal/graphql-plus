using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyCategoryOutput(IVerifierRepository verifiers) : UsageVerifier<IAstSchemaCategory, UsageContext>(verifiers)
{
  protected override UsageContext MakeContext(IAstSchemaCategory usage, IAstType[] aliased, IMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IAstSchemaCategory usage, UsageContext context)
  {
    if (context.GetTyped(usage.Output.Name, out IAstObject<IAstOutputField>? output)) {
      context.AddError(usage, "Category Output", $"'{usage.Output.Name}' is a generic Output type", output.TypeParams.Any());
    } else {
      context.AddError(usage, "Category Output", $"'{usage.Output.Name}' not defined or not an Output type");
    }

    context.CheckModifiers(usage);
  }
}
