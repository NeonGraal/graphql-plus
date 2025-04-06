namespace GqlPlus.Generating.Simple;

internal sealed class BooleanDomainGenerator
  : GenerateBaseDomain<IGqlpDomainTrueFalse>
{
  internal override void GenerateInterface(IGqlpDomain<IGqlpDomainTrueFalse> ast, GeneratorContext context)
    => context.AppendLine("  bool Value { get; set; }");
}
