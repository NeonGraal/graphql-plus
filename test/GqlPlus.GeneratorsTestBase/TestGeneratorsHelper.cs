using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace GqlPlus;

public static class TestGeneratorsHelper
{
  public static GeneratorDriver Generate(this IIncrementalGenerator generator, string source, ImmutableArray<AdditionalText> additionalPaths)
  {
    SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);

    IEnumerable<PortableExecutableReference> references =
    [MetadataReference.CreateFromFile(typeof(object).Assembly.Location)];

    CSharpCompilation compilation = CSharpCompilation.Create(
        assemblyName: "Tests",
        syntaxTrees: [syntaxTree],
        references: references);

    GeneratorDriver driver = CSharpGeneratorDriver.Create(generator)
      .AddAdditionalTexts(additionalPaths);

    return driver.RunGenerators(compilation);
  }

  public static ImmutableArray<AdditionalText> AdditionalPaths(this IEnumerable<string> paths)
    => [.. paths.Select(static path => new StringAdditionalText(path))];

  private sealed class StringAdditionalText(string path)
    : AdditionalText
  {
    public override string Path => path;

    public override SourceText? GetText(CancellationToken cancellationToken = default)
      => SourceText.From(path + Environment.NewLine);
  }
}
