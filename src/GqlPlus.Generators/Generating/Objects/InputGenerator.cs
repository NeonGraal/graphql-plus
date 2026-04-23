namespace GqlPlus.Generating.Objects;

internal sealed class InputInterfaceGenerator
  : GenerateForObject<IAstInputField>
{
  protected override void Generate(IAstObject<IAstInputField> ast, GqlpGeneratorContext context)
    => GenerateObjectInterfaces(ast, context);
}

internal sealed class InputModelGenerator
  : GenerateForObject<IAstInputField>
{
  protected override void Generate(IAstObject<IAstInputField> ast, GqlpGeneratorContext context)
    => GenerateObjectClasses(ast, context);
}

internal sealed class InputDecoderGenerator
  : GenerateForObject<IAstInputField>
{
  protected override void Generate(IAstObject<IAstInputField> ast, GqlpGeneratorContext context)
    => GenerateObjectDecoder(ast, context);
}

internal sealed class InputEncoderGenerator
  : GenerateForObject<IAstInputField>
{
  protected override void Generate(IAstObject<IAstInputField> ast, GqlpGeneratorContext context)
    => GenerateEncoderBlock(ast, context);
}
