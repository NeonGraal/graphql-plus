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

internal sealed class DualDecoderGenerator
  : GenerateForObject<IGqlpDualField>
{
  protected override void Generate(IGqlpObject<IGqlpDualField> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);
}

internal sealed class DualEncoderGenerator
  : GenerateForObject<IGqlpDualField>
{
  protected override void Generate(IGqlpObject<IGqlpDualField> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, EncoderHeader, TypeMembers, ClassMember);
}
