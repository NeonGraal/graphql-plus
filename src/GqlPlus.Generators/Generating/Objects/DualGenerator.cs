namespace GqlPlus.Generating.Objects;

internal sealed class DualInterfaceGenerator
  : GenerateForObject<IGqlpDualField>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;

  protected override void Generate(IGqlpObject<IGqlpDualField> ast, GqlpGeneratorContext context)
    => GenerateObjectInterfaces(ast, context);
}

internal sealed class DualModelGenerator
  : GenerateForObject<IGqlpDualField>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;

  protected override void Generate(IGqlpObject<IGqlpDualField> ast, GqlpGeneratorContext context)
    => GenerateObjectClasses(ast, context);
}
