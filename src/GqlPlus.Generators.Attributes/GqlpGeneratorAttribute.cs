namespace GqlPlus;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
public sealed class GqlpGeneratorAttribute(
  GqlpGeneratorType generatorType
) : Attribute
{
  public GqlpGeneratorType GeneratorType { get; } = generatorType;
}
