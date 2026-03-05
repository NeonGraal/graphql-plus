namespace GqlPlus.Generating;

public class GenerateClassTestsBase
  : SubstituteBase
{
  internal const string TestPrefix = "tst";

  internal static GqlpGeneratorContext Context(
    GqlpBaseType baseType = GqlpBaseType.Class,
    GqlpGeneratorType generatorType = GqlpGeneratorType.Model
  ) => new("testPath", new("testNamespace.testClass", baseType, generatorType), new("testNamespace", TestPrefix));

  internal static IGenerator<T> GFor<T>()
    where T : IGqlpError
    => A.Of<IGenerator<T>>();
}
