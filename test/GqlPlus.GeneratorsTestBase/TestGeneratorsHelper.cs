using System.Collections.Immutable;
using Basic.Reference.Assemblies;
using DiffEngine;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;
using Shouldly;

namespace GqlPlus;

public static class TestGeneratorsHelper
{
  static TestGeneratorsHelper()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static GeneratorDriver Generate(this IIncrementalGenerator generator, string source, params Type[] types)
    => generator.Generate(source, [], types, addNet20: true);

  public static GeneratorDriver Generate(
    this IIncrementalGenerator generator,
    string source,
    ImmutableArray<AdditionalText> additionalPaths,
    AnalyzerConfigOptionsProvider? configOptions = null)
    => generator.Generate(source, additionalPaths, [typeof(object)], configOptions);

  public static GeneratorDriver Generate(
    this IIncrementalGenerator generator,
    string source,
    ImmutableArray<AdditionalText> additionalPaths,
    IEnumerable<Type> types,
    AnalyzerConfigOptionsProvider? configOptions = null,
    bool addNet20 = false)
  {
    SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source, path: "{testString}");

    if (!addNet20) {
      types = types.Append(typeof(object));
    }

    IEnumerable<PortableExecutableReference> references = types.Select(type => MetadataReference.CreateFromFile(type.Assembly.Location));

    if (addNet20) {
      references = references.Concat(ReferenceAssemblies.NetStandard20);
    }

    CSharpCompilation compilation = CSharpCompilation.Create(
        assemblyName: "Tests",
        syntaxTrees: [syntaxTree],
        references: references);

    IEnumerable<Diagnostic> diagnostics = compilation.GetDiagnostics();

    Diagnostic[] errors = [.. diagnostics
      .Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error && !s_ignoreErrors.Contains(diagnostic.Id))];

    errors.ShouldBeEmpty();

    GeneratorDriver driver = CSharpGeneratorDriver.Create(generator)
      .AddAdditionalTexts(additionalPaths);

    if (configOptions is not null) {
      driver = driver.WithUpdatedAnalyzerConfigOptions(configOptions);
    }

    return driver.RunGenerators(compilation);
  }

  private static readonly HashSet<string> s_ignoreErrors = ["CS0535", "CS5001", "CS0246"];

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
