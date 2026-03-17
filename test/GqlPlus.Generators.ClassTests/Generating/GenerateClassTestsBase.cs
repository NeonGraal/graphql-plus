namespace GqlPlus.Generating;

public class GenerateClassTestsBase
  : SubstituteBase
{
  internal const string TestPrefix = "tst";

  internal static GqlpGeneratorContext Context(
    GqlpBaseType baseType = GqlpBaseType.Class,
    GqlpGeneratorType generatorType = GqlpGeneratorType.Model
  ) => new("testPath",
    new("testNamespace.testClass", baseType, generatorType),
    new("testNamespace", TestPrefix, true));

  internal void SkipBuiltInTypes(params string[] typeNames)
  {
    string[] builtIn = [.. typeNames.Intersect(BuiltIn.Internal.Concat(BuiltIn.Basic).SelectMany(t => t.NameAndAliases()))];

    this.SkipIf(builtIn.Length > 0, $"The following built-in types were included in the test: {string.Join(", ", builtIn)}");
  }

  internal static IGenerator<T> GFor<T>()
    where T : IGqlpError
    => A.Of<IGenerator<T>>();
}
