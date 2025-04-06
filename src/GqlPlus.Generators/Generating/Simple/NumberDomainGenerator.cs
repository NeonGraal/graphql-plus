namespace GqlPlus.Generating.Simple;

internal sealed class NumberDomainGenerator
  : GenerateBaseDomain<IGqlpDomainRange>
{
  internal override void GenerateInterface(IGqlpDomain<IGqlpDomainRange> ast, GeneratorContext context)
    => context.AppendLine("  decimal Value { get; set; }");
}
