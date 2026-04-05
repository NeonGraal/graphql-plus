namespace GqlPlus.Generating.Objects;

internal sealed class InputInterfaceGenerator
  : GenerateForObject<IGqlpInputField>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;

  protected override void Generate(IGqlpObject<IGqlpInputField> ast, GqlpGeneratorContext context)
    => GenerateObjectInterfaces(ast, context);
}

internal sealed class InputModelGenerator
  : GenerateForObject<IGqlpInputField>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;

  protected override void Generate(IGqlpObject<IGqlpInputField> ast, GqlpGeneratorContext context)
    => GenerateObjectClasses(ast, context);
}
