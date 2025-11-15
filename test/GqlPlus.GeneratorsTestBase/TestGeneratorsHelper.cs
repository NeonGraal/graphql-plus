using System.Collections.Immutable;
using DiffEngine;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace GqlPlus;

public static class TestGeneratorsHelper
{
  static TestGeneratorsHelper()
    => DiffRunner.MaxInstancesToLaunch(20);

  public static GeneratorDriver Generate(this IIncrementalGenerator generator, string source, params Type[] types)
    => generator.Generate(source, [], types);

  public static GeneratorDriver Generate(this IIncrementalGenerator generator, string source, ImmutableArray<AdditionalText> additionalPaths)
    => generator.Generate(source, additionalPaths, [typeof(object)]);

  public static GeneratorDriver Generate(this IIncrementalGenerator generator, string source, ImmutableArray<AdditionalText> additionalPaths, IEnumerable<Type> types)
  {
    SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);

    IEnumerable<PortableExecutableReference> references = types.Select(type => MetadataReference.CreateFromFile(type.Assembly.Location));

    CSharpCompilation compilation = CSharpCompilation.Create(
        assemblyName: "Tests",
        syntaxTrees: [syntaxTree],
        references: references);

    GeneratorDriver driver = CSharpGeneratorDriver.Create(generator)
      .AddAdditionalTexts(additionalPaths);

    return driver.RunGenerators(compilation);
  }

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
