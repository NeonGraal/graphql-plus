using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace GqlPlus;

public static class TestGeneratorsHelper
{
  public static Task Verify(string source, params string[] additionalPaths)
  {
    // Parse the provided string into a C# syntax tree
    SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);

    IEnumerable<PortableExecutableReference> references =
    [MetadataReference.CreateFromFile(typeof(object).Assembly.Location)];

    // Create a Roslyn compilation for the syntax tree.
    CSharpCompilation compilation = CSharpCompilation.Create(
        assemblyName: "Tests",
        syntaxTrees: [syntaxTree],
        references: references);

    // Create an instance of our EnumGenerator incremental source generator
    BuildDataGenerator generator = new();

    // The GeneratorDriver is used to run our generator against a compilation
    GeneratorDriver driver = CSharpGeneratorDriver.Create(generator)
      .AddAdditionalTexts([.. additionalPaths.Select(PathToText)]);

    // Run the source generator!
    driver = driver.RunGenerators(compilation);

    // Use verify to snapshot test the source generator output!
    return Verifier.Verify(driver);

    static AdditionalText PathToText(string path)
      => new StringAdditionalText(path);
  }

  private sealed class StringAdditionalText(string path)
    : AdditionalText
  {
    public override string Path => path;

    public override SourceText? GetText(CancellationToken cancellationToken = default)
      => SourceText.From(path + Environment.NewLine);
  }
}
