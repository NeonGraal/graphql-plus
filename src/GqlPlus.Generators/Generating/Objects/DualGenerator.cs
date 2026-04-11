using GqlPlus.Ast.Schema;

namespace GqlPlus.Generating.Objects;

internal sealed class DualInterfaceGenerator
  : GenerateForObject<IAstDualField>
{
  protected override void Generate(IAstObject<IAstDualField> ast, GqlpGeneratorContext context)
    => GenerateObjectInterfaces(ast, context);
}

internal sealed class DualModelGenerator
  : GenerateForObject<IAstDualField>
{
  protected override void Generate(IAstObject<IAstDualField> ast, GqlpGeneratorContext context)
    => GenerateObjectClasses(ast, context);
}

internal sealed class DualDecoderGenerator
  : GenerateForObject<IAstDualField>
{
  protected override void Generate(IAstObject<IAstDualField> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, DecoderHeader, TypeMembers, ClassMember);
}

internal sealed class DualEncoderGenerator
  : GenerateForObject<IAstDualField>
{
  protected override void Generate(IAstObject<IAstDualField> ast, GqlpGeneratorContext context)
    => GenerateBlock(ast, context, EncoderHeader, TypeMembers, ClassMember);
}
