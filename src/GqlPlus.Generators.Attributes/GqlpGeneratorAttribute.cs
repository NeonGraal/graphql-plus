namespace GqlPlus;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public sealed class GqlpGeneratorAttribute(
  GqlpGeneratorType generatorType
) : Attribute
{
  public GqlpGeneratorType GeneratorType { get; } = generatorType;
}
