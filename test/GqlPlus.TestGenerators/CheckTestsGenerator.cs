using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GqlPlus;

[Generator]
public class CheckTestsGenerator
  : IIncrementalGenerator
{
  public void Initialize(IncrementalGeneratorInitializationContext context)
  {
    IncrementalValuesProvider<CheckTestsClass> checkTests = context
      .SyntaxProvider
      .ForAttributeWithMetadataName(
        fullyQualifiedMetadataName: "GqlPlus." + nameof(CheckTestsAttribute),
        predicate: static (syntaxNode, cancellationToken) => syntaxNode is PropertyDeclarationSyntax,
        transform: static (context, cancellationToken) => {
          if (context.TargetSymbol is IPropertySymbol forProperty) {
            return CreateCheckTestProperty(forProperty, context.Attributes);
          }

          return new CheckTestsClass("", "", "", []);
        }
    );

    IncrementalValuesProvider<CheckTestsClass> combined = checkTests.Collect()
      .SelectMany((pair, cancellationToken)
        => pair.GroupBy(c => c.TheClass + c.TypeArguments)
          .Select(g => g.Aggregate((l, r) => l.AddMethods(r.Methods))));

    context.RegisterSourceOutput(combined, static (context, model) => {
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

    sb.Append("partial class " + model.TheClass);
    if (!string.IsNullOrWhiteSpace(model.TypeArguments)) {
      sb.Append("<" + model.TypeArguments + ">");
    }

    sb.AppendLine(" {");
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
      if (method.StartLine is not null) {
        sb.AppendLine($"#line {method.StartLine} \"{method.FilePath}\"");
      }

      sb.AppendLine(method.Parameters.Any() ? "  [Theory, RepeatData]" : "  [Fact]");
      sb.Append($"  public {method.Returns} {methodName}(");
      sb.Append(string.Join(", ", method.Parameters.Select(p => $"{p}")));
      sb.AppendLine(")");
      sb.Append($"    => {method.Property}.{method.Name}(");
      sb.Append(string.Join(", ", method.Parameters.Select(p => p.Name)));
      sb.AppendLine(");");
    }
  }

  private static CheckTestsClass CreateCheckTestProperty(IPropertySymbol forProperty, ImmutableArray<AttributeData> attributes)
  {
    return new CheckTestsClass(forProperty.ContainingType, attributes.SelectMany(CreateAttributeMethods));

    IEnumerable<CheckTestsMethod> CreateAttributeMethods(AttributeData attribute)
    {
      if (attribute.ConstructorArguments.Length >= 1) {
        return CreateMethods(forProperty.Name, forProperty, attribute, 0);
      }

      return [];
    }
  }

  private static IEnumerable<CheckTestsMethod> CreateMethods(string propertyName, IPropertySymbol? propertySymbol, AttributeData attribute, int typeArg)
  {
    ITypeSymbol? propertyType = attribute.ConstructorArguments[typeArg].Value as ITypeSymbol;

    if (propertyType is null) {
      propertyType = propertySymbol?.Type;
    } else {
      if (propertyType is INamedTypeSymbol namedType && namedType.IsUnboundGenericType) {
        if (propertySymbol?.Type is INamedTypeSymbol namedProperty) {
          propertyType = namedProperty.AllInterfaces
            .FirstOrDefault(i => SymbolEqualityComparer.Default.Equals(i.ConstructUnboundGenericType(), namedType));
        }
      }
    }

    FileLinePositionSpan? propertyLocation = propertySymbol?.Locations.FirstOrDefault()?.GetLineSpan();
    bool inherited = attribute.NamedArguments.Any(kv => kv.Key == "Inherited" && (bool)kv.Value.Value!);
    return CreateMethods(propertyName, propertyLocation, propertyType, inherited);
  }

  private static IEnumerable<CheckTestsMethod> CreateMethods(string propertyName, FileLinePositionSpan? propertyLocation, ITypeSymbol? propertyType, bool inherited)
  {
    if (propertyType is null) {
      yield break;
    }

    IMethodSymbol[] methods = [.. propertyType.GetMembers()
      .OfType<IMethodSymbol>()
      .Where(m => m.MethodKind == MethodKind.Ordinary && !m.IsStatic)];
    foreach (IMethodSymbol method in methods) {
      yield return new CheckTestsMethod(method, propertyName, propertyLocation);
    }

    if (!inherited && methods.Length > 0) {
      yield break;
    }

    foreach (CheckTestsMethod method in propertyType.Interfaces.SelectMany(i => CreateMethods(propertyName, propertyLocation, i, inherited))) {
      yield return method;
    }
  }

  private sealed class CheckTestsClass
  {
    public string TheNamespace { get; }
    public string TheClass { get; }
    public string TypeArguments { get; }
    public ImmutableArray<CheckTestsMethod> Methods { get; }

    public CheckTestsClass(INamedTypeSymbol containingClass, IEnumerable<CheckTestsMethod> methods)
    {
      TheNamespace = containingClass.ContainingNamespace
        ?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted))
        ?? "";
      TheClass = containingClass.Name;
      TypeArguments = string.Join(", ", containingClass.TypeArguments
        .Select(ta => ta.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)));
      Methods = [.. methods];
    }

    public CheckTestsClass(string theNamespace, string theClass, string typeArguments, IEnumerable<CheckTestsMethod> methods)
    {
      TheNamespace = theNamespace;
      TheClass = theClass;
      TypeArguments = typeArguments;
      Methods = [.. methods];
    }

    public CheckTestsClass AddMethods(IEnumerable<CheckTestsMethod> methods)
      => new(TheNamespace, TheClass, TypeArguments, Methods.Concat(methods));
  }

  private sealed class CheckTestsMethod(IMethodSymbol method, string propertyName, FileLinePositionSpan? propertyLocation)
  {
    public string Name { get; } = method.Name;
    public string Returns { get; }
      = method.ReturnsVoid ? "void" : method.ReturnType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
    public string Property { get; } = propertyName;
    public ImmutableArray<CheckTestsParameter> Parameters { get; }
      = [.. method.Parameters.Select(CreateParameter)];
    public string? FilePath { get; } = propertyLocation?.Path;
    public int? StartLine { get; } = propertyLocation?.StartLinePosition.Line;

    private static CheckTestsParameter CreateParameter(IParameterSymbol parameter)
      => new(parameter.Name, parameter.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat));
  }

  private sealed record CheckTestsParameter(string Name, string Type)
  {
    public override string ToString() => $"{Type} {Name}";
  }
}
