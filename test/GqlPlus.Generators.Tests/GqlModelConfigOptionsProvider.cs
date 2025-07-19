using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace GqlPlus;

internal sealed class GqlModelConfigOptionsProvider : AnalyzerConfigOptionsProvider
{
  public override GqlModelConfigOptions GlobalOptions { get; }
    = new(new() { ["build_property.GqlPlus_BaseNamespace"] = "GqlTest" });

  public override GqlModelConfigOptions GetOptions(SyntaxTree tree)
    => GqlModelConfigOptions.Empty;
  public override GqlModelConfigOptions GetOptions(AdditionalText textFile)
    => GqlModelConfigOptions.Empty;
}

internal sealed class GqlModelConfigOptions(
  Map<string> values
) : AnalyzerConfigOptions
{
  public static GqlModelConfigOptions Empty { get; } = new([]);

  public override bool TryGetValue(string key, [NotNullWhen(true)] out string? value)
    => values.TryGetValue(key, out value);
}
