using System.Collections.Immutable;
using System.Text;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema;
using GqlPlus.Result;
using GqlPlus.Token;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

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

  private void GenerateCode(SourceProductionContext context, (ImmutableArray<AdditionalText> Left, GqlModelOptions Right) tuple)
  {
    (ImmutableArray<AdditionalText> array, GqlModelOptions? options) = tuple;

    if (array.IsDefaultOrEmpty || options is null) {
      return;
    }

    IServiceProvider services = new ServiceCollection()
      .AddCommonParsers()
      .AddSchemaParsers()
      .BuildServiceProvider();

    Parser<IGqlpSchema>.L schemaParser = services.GetRequiredService<Parser<IGqlpSchema>.D>();

    foreach (AdditionalText text in array) {
      string file = Path.GetFileNameWithoutExtension(text.Path);
      StringBuilder builder = new("// Generated from ");
      builder.AppendLine(text.Path);
      builder.AppendLine("\n/*");

      string? lines = text.GetText()?.ToString();
      if (lines is not null) {
        Tokenizer tokens = new(lines);

        IGqlpSchema ast = schemaParser.Parse(tokens, "Schema").Required();
        foreach (IGqlpDeclaration item in ast.Declarations) {
          builder.AppendLine(item.Label + " - " + item.Name);
        }
      }

      builder.AppendLine("*/\n");
      builder.AppendLine($"namespace {options.BaseNamespace}.Model_" + file + " {}");

      context.AddSource("Model_" + file + ".gen.cs", builder.ToString());
    }
  }
}
