namespace GqlPlus.Generating.Objects;

internal sealed class DualInterfaceGenerator
  : GenerateForObject<IGqlpDualField>
{
  protected override void Generate(IGqlpObject<IGqlpDualField> ast, GqlpGeneratorContext context)
    => GenerateObjectInterfaces(ast, context);
}

internal sealed class DualModelGenerator
  : GenerateForObject<IGqlpDualField>
{
  protected override void Generate(IGqlpObject<IGqlpDualField> ast, GqlpGeneratorContext context)
    => GenerateObjectClasses(ast, context);
}
