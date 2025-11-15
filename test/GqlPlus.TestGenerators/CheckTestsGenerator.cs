using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace GqlPlus;

[Generator]
public class CheckTestsGenerator
  : IIncrementalGenerator
{
  public void Initialize(IncrementalGeneratorInitializationContext context)
  {
    IncrementalValuesProvider<CheckTestsClass> simple = context
      .SyntaxProvider
      .ForAttributeWithMetadataName(
        fullyQualifiedMetadataName: "GqlPlus." + nameof(CheckTestsForAttribute),
        predicate: static (syntaxNode, cancellationToken) => syntaxNode is ClassDeclarationSyntax,
        transform: static (context, cancellationToken) => {
          if (context.TargetSymbol is INamedTypeSymbol containingClass) {
            // Note: this is a simplified example. You will also need to handle the case where the type is in a global namespace, nested, etc.
            string theNamespace = containingClass.ContainingNamespace
              ?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted))
              ?? "";
            return new CheckTestsClass(
              theNamespace,
              containingClass.Name,
              CreateCheckTestsMethods(context.Attributes));
          }

          return new CheckTestsClass("", "", []);
        }
    );

    context.RegisterSourceOutput(simple, static (context, model) => {
      StringBuilder sb = new();

      if (string.IsNullOrEmpty(model.TheClass) || string.IsNullOrEmpty(model.TheNamespace)) {
        sb.AppendLine($"// NS: {model.TheNamespace} CLS: {model.TheClass}");
        context.AddSource($"{model.TheClass}.g.cs", sb.ToString());
        return;
      }

      sb.AppendLine($"namespace {model.TheNamespace};");
      sb.AppendLine("partial class " + model.TheClass + " {");
      foreach (CheckTestsMethod method in model.Methods) {
        sb.AppendLine("// Method: " + method.Name);
      }

      sb.AppendLine("}");
      context.AddSource($"{model.TheClass}.g.cs", sb.ToString());
    });
  }

  private static IEnumerable<CheckTestsMethod> CreateCheckTestsMethods(ImmutableArray<AttributeData> attributes)
  {
    foreach (AttributeData attribute in attributes) {
      yield return new CheckTestsMethod("", "", []);
    }
  }

  private sealed class CheckTestsClass(string theNamespace, string theClass, IEnumerable<CheckTestsMethod> methods)
  {
    public string TheNamespace { get; } = theNamespace;
    public string TheClass { get; } = theClass;
    public ImmutableArray<CheckTestsMethod> Methods { get; } = [.. methods];
  }

  private sealed class CheckTestsMethod(string name, string property, IEnumerable<CheckTestsParameter> parameters)
  {
    public string Name { get; } = name;
    public string Property { get; } = property;
    public ImmutableArray<CheckTestsParameter> Parameters { get; } = [.. parameters];
  }

  private sealed record CheckTestsParameter(string Name, string Type);
}
