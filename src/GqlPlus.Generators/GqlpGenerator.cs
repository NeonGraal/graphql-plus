using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using GqlPlus;
using GqlPlus.Generating;
using GqlPlus.Merging;
using GqlPlus.Parsing;
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
    GqlpBaseType baseType = BaseTypeFromTypeKind(baseSymbol);

    foreach (AttributeData attribute in attributes) {
      foreach (TypedConstant argument in attribute.ConstructorArguments) {
        GqlpGeneratorType? type = MakeTypeFromArgument(argument);
        if (type is not null) {
          yield return new GqlpGeneratorOptions(baseName, baseType, type.Value);
        }
      }
    }
  }

  private static GqlpBaseType BaseTypeFromTypeKind(INamedTypeSymbol baseSymbol)
    => baseSymbol.TypeKind switch {
      TypeKind.Class => GqlpBaseType.Class,
      TypeKind.Interface => GqlpBaseType.Interface,
      _ => GqlpBaseType.Other,
    };

  private static GqlpGeneratorType? MakeTypeFromArgument(TypedConstant argument)
  {
    if (argument is {
      Kind: TypedConstantKind.Enum,
      Type.Name: nameof(GqlpGeneratorType),
      Value: not null
    }) {
      return (GqlpGeneratorType)argument.Value;
    } else if (argument is { Value: string typeString }
        && Enum.TryParse(typeString, out GqlpGeneratorType type)) {
      return type;
    }

    return null;
  }

  private static GqlpModelOptions MakeGqlModelOptions(AnalyzerConfigOptionsProvider provider, CancellationToken _)
  {
    string baseNamespace = GlobalOptionOrDefault(provider, "GqlPlus_BaseNamespace", "GqlPlus");
    string typePrefix = GlobalOptionOrDefault(provider, "GqlPlus_TypePrefix", "Gqlp");

    string includesBaseNameString = GlobalOptionOrDefault(provider, "GqlPlus_NamespaceIncludesBaseName", "true");
    bool namespaceIncludesBaseName = !bool.TryParse(includesBaseNameString, out bool includesBaseName) || includesBaseName;

    return new GqlpModelOptions(baseNamespace, typePrefix, namespaceIncludesBaseName);
  }

  private static string GlobalOptionOrDefault(AnalyzerConfigOptionsProvider provider, string key, string defaultValue)
    => provider.GlobalOptions.TryGetValue("build_property." + key, out string? value) ? value : defaultValue;

  private void GenerateCode(
    SourceProductionContext sourceContext,
    (GqlpGeneratorOptions? Left,
      (ImmutableArray<AdditionalText> Left,
        GqlpModelOptions Right)) tuple)
  {
    (GqlpGeneratorOptions? generatorOptions, (ImmutableArray<AdditionalText> array, GqlpModelOptions? modelOptions)) = tuple;

    if (generatorOptions is null || modelOptions is null || array.IsDefaultOrEmpty) {
      NothingToGenerate(sourceContext, generatorOptions, array, modelOptions);
      return;
    }

    IServiceProvider services = BuildGeneratorServices();

    Map<IAstSchema> schemas = ParseGraphQlPlusFiles(array, services);

    Generator<IAstSchema> schemaGenerator = services.GetRequiredService<IGeneratorRepository>().GeneratorFor<IAstSchema>();
    foreach (string path in schemas.Keys) {
      GqlpGeneratorContext context = CreatePathContext(generatorOptions, modelOptions, schemas, path);

      schemaGenerator.Generate(schemas[path], context);
      string source = context.ToString();

      if (!string.IsNullOrWhiteSpace(source)) {
        sourceContext.AddSource(context.FileName, source);
      }

      ReportSchemaGenerationErrors(sourceContext, schemas, path);
    }
  }

  private static GqlpGeneratorContext CreatePathContext(GqlpGeneratorOptions generatorOptions, GqlpModelOptions modelOptions, Map<IAstSchema> schemas, string path)
  {
    GqlpGeneratorContext context = new(path, generatorOptions, modelOptions);

    foreach (MapPair<IAstSchema> other in schemas) {
      if (other.Key != path) {
        context.AddTypes(other.Value.Declarations.ArrayOf<IAstType>());
      }
    }

    return context;
  }

  private static void ReportSchemaGenerationErrors(SourceProductionContext sourceContext, Map<IAstSchema> schemas, string path)
  {
    foreach (IMessage error in schemas[path].Errors) {
      LinePosition at = error is ITokenMessage token ? new(token.Line, token.Column) : default;
      Location location = Location.Create(path, default, new(at, at));
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

  private static ServiceProvider BuildGeneratorServices()
    => new ServiceCollection()
      .AddSingleton<ILoggerFactory, NullLoggerFactory>()
      .AddParsers(p => p
        .AddCommonParsers()
        .AddSchemaParsers())
      .AddMergers(b => b.AddSchemaMergers())
      .AddGenerators()
      .BuildServiceProvider();

  private static Map<IAstSchema> ParseGraphQlPlusFiles(ImmutableArray<AdditionalText> array, IServiceProvider services)
  {
    Map<IAstSchema> schemas = [];

    ParserOne<IAstSchema> schemaParser = services.GetRequiredService<IParserRepository>().ParserFor<IAstSchema>();
    MergerOne<IAstSchema> schemaMerger = services.GetRequiredService<IMergerRepository>().MergerFor<IAstSchema>();

    foreach (AdditionalText text in array) {
      string? lines = text.GetText()?.ToString();
      if (lines is null) {
        continue;
      }

      string path = Path.GetFullPath(text.Path);
      Tokenizer tokens = new(lines);
      IAstSchema parsed = schemaParser.Parse(tokens, "Schema").Required();
      schemas[path] = schemaMerger.Merge([parsed]).Single();
    }

    return schemas;
  }

  private static void NothingToGenerate(SourceProductionContext sourceContext, GqlpGeneratorOptions? generatorOptions, ImmutableArray<AdditionalText> array, GqlpModelOptions? modelOptions)
  {
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
  }
}
