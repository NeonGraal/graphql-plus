namespace GqlPlus.Generating.Objects;

internal abstract class ObjectInterfaceGeneratorBase<TField>()
  : GenerateForObject<TField>
  where TField : IAstObjField
{
  protected override void Generate(IAstObject<TField> ast, GqlpGeneratorContext context)
    => GenerateObjectInterfaces(ast, context);
}

internal abstract class ObjectModelGeneratorBase<TField>()
  : GenerateForObject<TField>
  where TField : IAstObjField
{
  protected override void Generate(IAstObject<TField> ast, GqlpGeneratorContext context)
    => GenerateObjectClasses(ast, context);
}

internal abstract class ObjectDecoderGeneratorBase<TField>()
  : GenerateForObject<TField>
  where TField : IAstObjField
{
  protected override void Generate(IAstObject<TField> ast, GqlpGeneratorContext context)
    => GenerateObjectDecoder(ast, context);
}
