namespace GqlPlus.Generating.Simple;

internal abstract class DomainValueInterfaceGeneratorBase<TItem>(
  DomainKind kind
) : GenerateBaseDomain<TItem>(kind)
  where TItem : IAstDomainItem
{
  protected override void Generate(IAstDomain<TItem> ast, GqlpGeneratorContext context)
    => GenerateDomainInterface(ast, context);
}

internal abstract class DomainValueModelGeneratorBase<TItem>(
  DomainKind kind
) : GenerateBaseDomain<TItem>(kind)
  where TItem : IAstDomainItem
{
  protected override void Generate(IAstDomain<TItem> ast, GqlpGeneratorContext context)
    => GenerateDomainModel(ast, context);
}

internal abstract class DomainValueDecoderGeneratorBase<TItem>(
  DomainKind kind
) : GenerateBaseDomain<TItem>(kind)
  where TItem : IAstDomainItem
{
  protected override void Generate(IAstDomain<TItem> ast, GqlpGeneratorContext context)
    => GenerateDomainDecoder(ast, context);
}

internal abstract class DomainValueEncoderGeneratorBase<TItem>(
  DomainKind kind
) : GenerateBaseDomain<TItem>(kind)
  where TItem : IAstDomainItem
{
  protected override void Generate(IAstDomain<TItem> ast, GqlpGeneratorContext context)
    => GenerateDomainValueEncoder(ast, context);
}
