namespace GqlPlus.Generating;

public class GeneratorClassTestBase
  : SubstituteBase
{
  internal readonly GqlpGeneratorContext Context = new("testPath", new("testNamespace.testClass", GqlpGeneratorType.Implementation), new("testNamespace"));

  internal static IGenerator<T> GFor<T>()
    where T : IGqlpError
    => A.Of<IGenerator<T>>();
}
