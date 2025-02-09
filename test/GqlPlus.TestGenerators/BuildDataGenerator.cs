using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace GqlPlus;

[Generator]
public class BuildDataGenerator : IIncrementalGenerator
{
  private const string BuildDataAttribute = @"
namespace GqlPlus;

[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public sealed class BuildDataAttribute(string segment) : Attribute
{
  public string Segment { get; } = segment;
}
";

  public void Initialize(IncrementalGeneratorInitializationContext context)
  {
    context.RegisterPostInitializationOutput(
      ctx => ctx.AddSource(
        "BuildDataAttribute.g.cs",
        SourceText.From(BuildDataAttribute, Encoding.UTF8)));
  }

  private sealed class TestDataSyntaxReceiver : ISyntaxReceiver
  {
    public List<string> Segments { get; set; } = [];

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
      if (syntaxNode is AttributeSyntax attributeSyntax
        && attributeSyntax.Name.ToString() == nameof(BuildDataAttribute)) {
        AttributeArgumentSyntax? segment = attributeSyntax.ArgumentList?.Arguments.FirstOrDefault();

        if (segment is not null) {
          Segments.Add(segment.ToString());
        }
      }
    }
  }
}
