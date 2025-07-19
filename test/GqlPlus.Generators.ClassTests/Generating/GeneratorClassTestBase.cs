namespace GqlPlus.Generating;

public class GeneratorClassTestBase
  : SubstituteBase
{
  internal readonly GeneratorContext Context = new("testPath", new("testNamespace"));

  internal static IGenerator<T> GFor<T>()
    where T : IGqlpError
    => A.Of<IGenerator<T>>();
}
