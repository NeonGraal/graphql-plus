using System.Collections.Immutable;
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

namespace GqlPlus;

[Generator(LanguageNames.CSharp)]
public class GqlModelGenerator : IIncrementalGenerator
{
  public void Initialize(IncrementalGeneratorInitializationContext context)
  {
    IncrementalValueProvider<GqlModelOptions> gqlModelOptions = context.AnalyzerConfigOptionsProvider.Select(MakeGqlModelOptions);

    IncrementalValueProvider<ImmutableArray<AdditionalText>> samples = context.AdditionalTextsProvider
                                .Where(text => Path.GetExtension(text.Path).Equals(".graphql+", StringComparison.OrdinalIgnoreCase))
                                .Collect();

    context.RegisterSourceOutput(samples.Combine(gqlModelOptions), GenerateCode);
  }

  private static GqlModelOptions MakeGqlModelOptions(AnalyzerConfigOptionsProvider provider, CancellationToken _)
  {
    if (!provider.GlobalOptions.TryGetValue("build_property.GqlPlus_BaseNamespace", out string? baseNamespace)) {
      baseNamespace = "GqlPlus";
    }

    return new GqlModelOptions(baseNamespace);
  }

  private void GenerateCode(SourceProductionContext sourceContext, (ImmutableArray<AdditionalText> Left, GqlModelOptions Right) tuple)
  {
    (ImmutableArray<AdditionalText> array, GqlModelOptions? options) = tuple;

    if (array.IsDefaultOrEmpty || options is null) {
      return;
    }

    IServiceProvider services = new ServiceCollection()
      .AddSingleton<ILoggerFactory, NullLoggerFactory>()
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

      GeneratorContext context = new(text.Path, options);
      schemaGenerator.Generate(merged, context);

      sourceContext.AddSource("Model_" + context.File + ".gen.cs", context.ToString());
      foreach (IMessage error in merged.Errors) {
        LinePosition at = error is ITokenMessage token ? new(token.Line, token.Column) : default;
        Location location = Location.Create(text.Path, default, new(at, at));
        Diagnostic diagnostic = Diagnostic.Create(
                       new DiagnosticDescriptor(
                           "GQLP001",
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
