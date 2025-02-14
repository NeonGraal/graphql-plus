using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace GqlPlus;

[Generator(LanguageNames.CSharp)]
public class GqlModelGenerator : IIncrementalGenerator
{
  public void Initialize(IncrementalGeneratorInitializationContext context)
  {
    IncrementalValueProvider<ImmutableArray<string>> samples = context.AdditionalTextsProvider
                                .Select((text, token) => text.Path)
                                .Where(path => Path.GetExtension(path).Equals(".graphql+", StringComparison.OrdinalIgnoreCase))
                                .Collect();

    context.RegisterSourceOutput(samples, GenerateCode);
  }

  private void GenerateCode(SourceProductionContext context, ImmutableArray<string> array)
  {
    if (array.IsDefaultOrEmpty) {
      return;
    }
  }
}
