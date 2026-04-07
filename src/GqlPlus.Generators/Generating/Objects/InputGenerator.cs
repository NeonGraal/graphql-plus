namespace GqlPlus.Generating.Objects;

internal sealed class InputInterfaceGenerator
  : GenerateForObject<IGqlpInputField>
{
  protected override void Generate(IGqlpObject<IGqlpInputField> ast, GqlpGeneratorContext context)
    => GenerateObjectInterfaces(ast, context);
}

internal sealed class InputModelGenerator
  : GenerateForObject<IGqlpInputField>
{
  protected override void Generate(IGqlpObject<IGqlpInputField> ast, GqlpGeneratorContext context)
    => GenerateObjectClasses(ast, context);
}
