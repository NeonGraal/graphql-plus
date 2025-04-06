namespace GqlPlus.Generating.Simple;

internal sealed class StringDomainGenerator
  : GenerateBaseDomain<IGqlpDomainRegex>
{
  internal override void GenerateInterface(IGqlpDomain<IGqlpDomainRegex> ast, GeneratorContext context)
    => context.AppendLine("  string Value { get; set; }");
  internal override void GenerateClass(IGqlpDomain<IGqlpDomainRegex> domain, GeneratorContext context)
  {
    context.AppendLine("  string _value;");
    context.AppendLine("  string Value { get => _value; set => CheckAndSet(value); }");
  }
}
