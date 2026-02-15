using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions;
using GqlPlus.Generating;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema;
using GqlPlus.Result;
using GqlPlus.Token;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using TypeKind = Microsoft.CodeAnalysis.TypeKind;

namespace GqlPlus;

[Generator(LanguageNames.CSharp), ExcludeFromCodeCoverage]
public class GqlpGenerator : IIncrementalGenerator
{
  public void Initialize(IncrementalGeneratorInitializationContext context)
  {
    IncrementalValuesProvider<GqlpGeneratorOptions> generatorOptions = context.SyntaxProvider
             .ForAttributeWithMetadataName("GqlPlus.GqlpGeneratorAttribute",
                 predicate: static (s, _) => true,
                 transform: static (ctx, _) => GetGeneratorOptions(ctx.SemanticModel, ctx.TargetNode, ctx.Attributes))
             .SelectMany((m, _) => m);

    IncrementalValueProvider<GqlpModelOptions> gqlModelOptions = context.AnalyzerConfigOptionsProvider.Select(MakeGqlModelOptions);

    IncrementalValueProvider<ImmutableArray<AdditionalText>> samples = context.AdditionalTextsProvider
                                .Where(text => Path.GetExtension(text.Path).Equals(".graphql+", StringComparison.OrdinalIgnoreCase))
                                .Collect();

    context.RegisterSourceOutput(generatorOptions.Combine(samples.Combine(gqlModelOptions)), GenerateCode);
  }

  private static IEnumerable<GqlpGeneratorOptions> GetGeneratorOptions(SemanticModel model, SyntaxNode node, ImmutableArray<AttributeData> attributes)
  {
    if (model.GetDeclaredSymbol(node) is not INamedTypeSymbol baseSymbol) {
      yield break;
    }

    string baseName = baseSymbol.ToString();
    GqlpBaseType baseType = baseSymbol.TypeKind switch {
      TypeKind.Class => GqlpBaseType.Class,
      TypeKind.Interface => GqlpBaseType.Interface,
      _ => GqlpBaseType.Other,
    };

    GqlpGeneratorType type = GqlpGeneratorType.None;
    string warning = string.Empty;
    foreach (AttributeData attribute in attributes) {
      foreach (TypedConstant argument in attribute.ConstructorArguments) {
        if (argument is {
          Kind: TypedConstantKind.Enum,
          Type.Name: nameof(GqlpGeneratorType),
          Value: not null
        }) {
          yield return new GqlpGeneratorOptions(baseName, baseType, (GqlpGeneratorType)argument.Value);
        } else if (argument is { Value: string typeString }
            && Enum.TryParse(typeString, out type)) {
          yield return new GqlpGeneratorOptions(baseName, baseType, type);
        }
      }
    }
  }

  private static GqlpModelOptions MakeGqlModelOptions(AnalyzerConfigOptionsProvider provider, CancellationToken _)
  {
    if (!provider.GlobalOptions.TryGetValue("build_property.GqlPlus_BaseNamespace", out string? baseNamespace)) {
      baseNamespace = "GqlPlus";
    }

    if (!provider.GlobalOptions.TryGetValue("build_property.GqlPlus_TypePrefix", out string? typePrefix)) {
      typePrefix = "Gqlp";
    }

    return new GqlpModelOptions(baseNamespace, typePrefix);
  }

  private void GenerateCode(
    SourceProductionContext sourceContext,
    (GqlpGeneratorOptions? Left,
      (ImmutableArray<AdditionalText> Left,
        GqlpModelOptions Right)) tuple)
  {
    (GqlpGeneratorOptions? generatorOptions, (ImmutableArray<AdditionalText> array, GqlpModelOptions? modelOptions)) = tuple;

    if (generatorOptions is null || modelOptions is null || array.IsDefaultOrEmpty) {
      string message = "Nothing to generate because:";
      if (generatorOptions is null) {
        message += " No generator options found.";
      }

      if (modelOptions is null) {
        message += " No model options found.";
      }

      if (array.IsDefaultOrEmpty) {
        message += " No .graphql+ files found.";
      }

      Diagnostic diagnostic = Diagnostic.Create(
                     new DiagnosticDescriptor(
                         "GQLP001",
                         "Nothing to generate",
                         message,
                         "GraphQl+",
                         DiagnosticSeverity.Info,
                         isEnabledByDefault: true), null);
      sourceContext.ReportDiagnostic(diagnostic);
      return;
    }

    IServiceProvider services = new ServiceCollection()
      .AddSingleton<ILoggerFactory, NullLoggerFactory>()
      .AddFieldObjectKinds()
      .AddCommonParsers()
      .AddSchemaParsers()
      .AddMergers()
      .AddGenerators()
      .BuildServiceProvider();

    Parser<IGqlpSchema>.L schemaParser = services.GetRequiredService<Parser<IGqlpSchema>.D>();
    IMerge<IGqlpSchema> schemaMerger = services.GetRequiredService<IMerge<IGqlpSchema>>();
    IGenerator<IGqlpSchema> schemaGenerator = services.GetRequiredService<IGenerator<IGqlpSchema>>();

    foreach (AdditionalText text in array) {
      string? lines = text.GetText()?.ToString();
      if (lines is null) {
        continue;
      }

      Tokenizer tokens = new(lines);
      IGqlpSchema parsed = schemaParser.Parse(tokens, "Schema").Required();
      IGqlpSchema merged = schemaMerger.Merge([parsed]).Single();

      GqlpGeneratorContext context = new(text.Path, generatorOptions, modelOptions);
      schemaGenerator.Generate(merged, context);
      string source = context.ToString();

      if (!string.IsNullOrWhiteSpace(source)) {
        sourceContext.AddSource(context.FileName, source);
      }

      foreach (IMessage error in merged.Errors) {
        LinePosition at = error is ITokenMessage token ? new(token.Line, token.Column) : default;
        Location location = Location.Create(text.Path, default, new(at, at));
        Diagnostic diagnostic = Diagnostic.Create(
                       new DiagnosticDescriptor(
                           "GQLP002",
                           error.Message,
                           error.Message,
                           "GraphQl+",
                           DiagnosticSeverity.Error,
                           isEnabledByDefault: true),
                       location);
        sourceContext.ReportDiagnostic(diagnostic);
      }
    }
  }
}
