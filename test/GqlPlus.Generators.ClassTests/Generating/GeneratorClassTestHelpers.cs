namespace GqlPlus.Generating;

internal static class GeneratorClassTestHelpers
{
  internal static void CheckForRequired(this GqlpGeneratorContext context, params string[] required)
  {
    string result = context.ToString();
    if (!string.IsNullOrWhiteSpace(result)) {
      TestContext.Current.AddAttachment(context.FileName, result);
    }

    result.ShouldSatisfyAllConditions([.. required
      .Where(static r => !string.IsNullOrWhiteSpace(r))
      .Select(ContainsAction)
      ]);
  }

  private static Action<string> ContainsAction(string required)
    => result => result.ShouldContain(required);
}
