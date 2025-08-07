using System.Collections.Immutable;
using System.Globalization;
using System.Reflection;
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

  public static GeneratorDriver Generate(
    this IIncrementalGenerator generator,
    string source,
    ImmutableArray<AdditionalText> additionalPaths,
    AnalyzerConfigOptionsProvider? configOptions = null)
  {
    SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);

    IEnumerable<PortableExecutableReference> references = [
      MetadataReference.CreateFromFile(Assembly.Load("netstandard, Version=2.0.0.0").Location),
      MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location),
      MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
      MetadataReference.CreateFromFile(typeof(GqlpGeneratorAttribute).Assembly.Location)
      ];

    CSharpCompilation compilation = CSharpCompilation.Create(
        assemblyName: "Tests",
        syntaxTrees: [syntaxTree],
        references: references);

    Diagnostic[] diagnostics = [.. compilation.GetDiagnostics().Where(d => d.Id != "CS5001")];

    if (diagnostics.Length > 0) {
      throw new InvalidOperationException(
        "Compilation failed with the following diagnostics:\n" +
        string.Join("\n", diagnostics.Select(d => $"{d.Id}: {d.GetMessage(CultureInfo.InvariantCulture)}")));
    }

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
