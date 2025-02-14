using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace GqlPlus;

[Generator(LanguageNames.CSharp)]
public class GqlModelGenerator : IIncrementalGenerator
{
  public void Initialize(IncrementalGeneratorInitializationContext context)
  {
    IncrementalValueProvider<ImmutableArray<AdditionalText>> samples = context.AdditionalTextsProvider
                                .Where(text => Path.GetExtension(text.Path).Equals(".graphql+", StringComparison.OrdinalIgnoreCase))
                                .Collect();

    context.RegisterSourceOutput(samples, GenerateCode);
  }

  private void GenerateCode(SourceProductionContext context, ImmutableArray<AdditionalText> array)
  {
    if (array.IsDefaultOrEmpty) {
      return;
    }

    foreach (AdditionalText text in array) {
      string file = Path.GetFileNameWithoutExtension(text.Path);
      StringBuilder builder = new("// Generated from ");
      builder.AppendLine(text.Path);
      builder.AppendLine("\n/*");

      TextLineCollection? lines = text.GetText()?.Lines;
      if (lines is not null) {
        foreach (TextLine line in lines) {
          builder.AppendLine(line.ToString());
        }
      }

      builder.AppendLine("*/\n");
      builder.AppendLine("namespace GqlPlus;");
      builder.AppendLine();
      builder.AppendLine("public class Model_" + file + " {}");

      context.AddSource("Model_" + file + ".gen.cs", builder.ToString());
    }
  }
}
