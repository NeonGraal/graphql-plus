namespace GqlPlus.Generating;

public class GeneratorClassTestBase
  : SubstituteBase
{
  internal static GqlpGeneratorContext Context(
    GqlpBaseType baseType = GqlpBaseType.Class,
    GqlpGeneratorType generatorType = GqlpGeneratorType.Implementation
  ) => new("testPath", new("testNamespace.testClass", baseType, generatorType), new("testNamespace"));

  internal static IGenerator<T> GFor<T>()
    where T : IGqlpError
    => A.Of<IGenerator<T>>();
}
