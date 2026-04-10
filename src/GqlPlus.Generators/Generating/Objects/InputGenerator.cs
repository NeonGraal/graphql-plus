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

internal sealed class InputDecoderGenerator
  : GenerateForObject<IGqlpInputField>
{
  protected override void Generate(IGqlpObject<IGqlpInputField> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);
}

internal sealed class InputEncoderGenerator
  : GenerateForObject<IGqlpInputField>
{
  protected override void Generate(IGqlpObject<IGqlpInputField> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, EncoderHeader, TypeMembers, ClassMember);
}
