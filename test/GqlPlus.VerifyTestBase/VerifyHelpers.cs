using System.Runtime.CompilerServices;

namespace GqlPlus;

public static class VerifyHelpers
{
  public static VerifySettings CheckAutoVerify(this VerifySettings settings)
  {
    ArgumentNullException.ThrowIfNull(settings);

    if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("GQLPLUS_AUTOVERIFY"))) {
      settings.AutoVerify();
    }

    return settings;
  }

  public static Task AttachAndVerify(
    this string result,
    string name,
    VerifySettings settings,
    [CallerFilePath] string sourceFile = "")
  {
    TestContext.Current.AddAttachment(name, result);

    return Verify(result, settings, sourceFile);
  }

  public static Task AttachAndVerify(
      this IEnumerable<string> result,
      string name,
      VerifySettings settings,
      [CallerFilePath] string sourceFile = "")
    => AttachAndVerify(string.Join(Environment.NewLine, result), name, settings, sourceFile);
}
