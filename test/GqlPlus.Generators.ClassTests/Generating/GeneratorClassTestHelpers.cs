using System.Diagnostics.CodeAnalysis;
using GqlPlus.Structures;

namespace GqlPlus.Generating;

internal static class GeneratorClassTestHelpers
{
  internal static void CheckAll(this GqlpGeneratorContext context, params Action<string>[] checks)
  {
    string result = context.ToString();
    if (!string.IsNullOrWhiteSpace(result)) {
      TestContext.Current.AddAttachment(context.FileName, result);
    }

    result.ShouldSatisfyAllConditions(checks);
  }

  internal static void CheckFor(this GqlpGeneratorContext context, params ForType[] checks)
    => context.CheckAll([.. checks.Select(r => r(context.GeneratorOptions.GeneratorType))]);

  internal static void CheckForRequired(this GqlpGeneratorContext context, params Func<GqlpGeneratorType, string>[] required)
    => context.CheckAll([.. required
      .Select(r => r(context.GeneratorOptions.GeneratorType))
      .Where(static r => !string.IsNullOrWhiteSpace(r))
      .Select(ContainsAction)
      ]);

  internal static string MakeNullable(string contains)
  {
    int lastGt = contains.LastIndexOf('>');
    if (lastGt >= 0 && lastGt + 1 < contains.Length && contains[lastGt + 1] == ' ') {
      return contains[..(lastGt + 1)] + "?" + contains[(lastGt + 1)..];
    }

    int firstSpace = contains.IndexOf(' ', StringComparison.Ordinal);
    if (firstSpace > 0 && contains[firstSpace - 1] != '?') {
      return contains[..firstSpace] + "?" + contains[firstSpace..];
    }

    return contains;
  }

  private static Action<string> ContainsAction(string required)
    => result => result.ShouldContain(required);

  public static void EncoderForReturns<T>([NotNull] this IEncoderRepository repo, IEncoder<T> result)
    => repo.EncoderFor<T>().ReturnsForAnyArgs(result);
}

internal delegate Action<string> ForType(GqlpGeneratorType forType);
