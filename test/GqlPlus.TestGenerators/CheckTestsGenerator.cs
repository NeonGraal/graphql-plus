using System;
using System.Collections.Immutable;
using System.Reflection.Metadata;
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
            return CreateCheckTestClass(containingClass, context.Attributes);
          }

          return new CheckTestsClass("", "", []);
        }
    );

    context.RegisterSourceOutput(simple, static (context, model) => {
      if (!string.IsNullOrWhiteSpace(model.TheClass)) {
        context.AddSource($"{model.TheClass}.g.cs", RenderPartialClass(model));
      }
    });
  }

  private static string RenderPartialClass(CheckTestsClass model)
  {
    StringBuilder sb = new();
    if (!string.IsNullOrWhiteSpace(model.TheNamespace)) {
      sb.AppendLine($"namespace {model.TheNamespace};");
    }

    sb.AppendLine("partial class " + model.TheClass + " {");
    foreach (IGrouping<string, CheckTestsMethod> methods in model.Methods.GroupBy(m => m.Name)) {
      if (methods.Count() == 1) {
        RenderMethod(methods.First(), methods.Key);
        continue;
      }

      foreach (IGrouping<string, CheckTestsMethod> properties in methods.GroupBy(m => m.Property)) {
        if (properties.Count() > 1) {
          throw new InvalidOperationException($"Multiple methods found with same name ('{methods.Key}') for same property '{properties.Key}'");
        }

        RenderMethod(properties.First(), properties.Key + "_" + methods.Key);
      }
    }

    sb.AppendLine("}");

    return sb.ToString();

    void RenderMethod(CheckTestsMethod method, string methodName)
    {
      sb.AppendLine(method.Parameters.Any() ? "  [Theory, RepeatData]" : "  [Fact]");
      sb.Append($"  public {method.Returns} {methodName}(");
      sb.Append(string.Join(", ", method.Parameters.Select(p => $"{p}")));
      sb.AppendLine(")");
      sb.Append($"    => {method.Property}.{method.Name}(");
      sb.Append(string.Join(", ", method.Parameters.Select(p => p.Name)));
      sb.AppendLine(");");
    }
  }

  private static CheckTestsClass CreateCheckTestClass(INamedTypeSymbol containingClass, ImmutableArray<AttributeData> attributes)
  {
    string theNamespace = containingClass.ContainingNamespace
      ?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted))
      ?? "";
    return new CheckTestsClass(
      theNamespace,
      containingClass.Name,
      attributes.SelectMany(CreateAttributeMethods));

    IEnumerable<CheckTestsMethod> CreateAttributeMethods(AttributeData attribute)
    {
      string propertyName = attribute.ConstructorArguments[0].Value?.ToString() ?? throw new ArgumentException("Must supply Target for CheckTestsFor");
      if (attribute.ConstructorArguments.Length >= 2) {
        ITypeSymbol? propertyType = attribute.ConstructorArguments[1].Value as ITypeSymbol;

        if (propertyType is null) {
          IPropertySymbol? propertySymbol = containingClass.GetMembers(propertyName).FirstOrDefault() as IPropertySymbol;
          propertyType = propertySymbol?.Type;
        }

        bool inherited = attribute.NamedArguments.Any(kv => kv.Key == "Inherited" && (bool)kv.Value.Value!);

        return CreateMethods(propertyName, propertyType, inherited);
      }

      return [];
    }

    IEnumerable<CheckTestsMethod> CreateMethods(string propertyName, ITypeSymbol? propertyType, bool inherited)
    {
      if (propertyType is null) {
        yield break;
      }

      foreach (IMethodSymbol method in propertyType.GetMembers().OfType<IMethodSymbol>()) {
        string returnsType = method.ReturnsVoid ? "void" : method.ReturnType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
        yield return new CheckTestsMethod(method.Name, returnsType, propertyName, method.Parameters.Select(CreateParameter));
      }

      if (!inherited) {
        yield break;
      }

      foreach (CheckTestsMethod method in propertyType.Interfaces.SelectMany(i => CreateMethods(propertyName, i, true))) {
        yield return method;
      }
    }
  }

  private static CheckTestsParameter CreateParameter(IParameterSymbol parameter)
    => new(parameter.Name, parameter.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat));

  private sealed class CheckTestsClass(string theNamespace, string theClass, IEnumerable<CheckTestsMethod> methods)
  {
    public string TheNamespace { get; } = theNamespace;
    public string TheClass { get; } = theClass;
    public ImmutableArray<CheckTestsMethod> Methods { get; } = [.. methods];
  }

  private sealed class CheckTestsMethod(string methodName, string returnsType, string propertyName, IEnumerable<CheckTestsParameter> parameters)
  {
    public string Name { get; } = methodName;
    public string Returns { get; } = returnsType;
    public string Property { get; } = propertyName;
    public ImmutableArray<CheckTestsParameter> Parameters { get; } = [.. parameters];
  }

  private sealed record CheckTestsParameter(string Name, string Type)
  {
    public override string ToString() => $"{Type} {Name}";
  }
}
