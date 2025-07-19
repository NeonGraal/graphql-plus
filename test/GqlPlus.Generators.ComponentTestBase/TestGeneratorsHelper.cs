using System.Collections.Immutable;
using DiffEngine;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;

namespace GqlPlus;

public static class TestGeneratorsHelper
{
  static TestGeneratorsHelper()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static GeneratorDriver Generate(this IIncrementalGenerator generator, ImmutableArray<AdditionalText> additionalPaths, AnalyzerConfigOptionsProvider? configOptions = null)
  {
    SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText("");

    IEnumerable<PortableExecutableReference> references =
    [MetadataReference.CreateFromFile(typeof(object).Assembly.Location)];

    CSharpCompilation compilation = CSharpCompilation.Create(
        assemblyName: "Tests",
        syntaxTrees: [syntaxTree],
        references: references);

    GeneratorDriver driver = CSharpGeneratorDriver.Create(generator)
      .AddAdditionalTexts(additionalPaths);

    if (configOptions is not null) {
      driver = driver.WithUpdatedAnalyzerConfigOptions(configOptions);
    }

    return driver.RunGenerators(compilation);
  }

  public static ImmutableArray<AdditionalText> AdditionalString(this string path, string text)
    => [new StringAdditionalText(path, text)];

  public static ImmutableArray<AdditionalText> AdditionalPaths(this IEnumerable<string> paths, string contents)
    => [.. paths.Select(path => new StringAdditionalText(path, contents))];

  private sealed class StringAdditionalText(string path, string contents)
    : AdditionalText
  {
    public override string Path => path;

    public override SourceText? GetText(CancellationToken cancellationToken = default)
      => SourceText.From(contents + Environment.NewLine);
  }
}
