namespace GqlPlus.Generating.Objects;

internal sealed class InputInterfaceGenerator()
  : ObjectInterfaceGeneratorBase<IAstInputField>;

internal sealed class InputModelGenerator()
  : ObjectModelGeneratorBase<IAstInputField>;

internal sealed class InputDecoderGenerator()
  : ObjectDecoderGeneratorBase<IAstInputField>;

internal sealed class InputEncoderGenerator
  : ObjectEncoderGeneratorBase<IAstInputField>
{
  protected override void Generate(IAstObject<IAstInputField> ast, GqlpGeneratorContext context)
  { }
}
