using System.Runtime.CompilerServices;

namespace GqlPlus;

public static class VerifyHelpers
{
  private static readonly bool s_autoVerify = EnvironmentVariableExists("GQLPLUS_AUTOVERIFY");
  private static readonly bool s_attachments = !EnvironmentVariableExists("GQLPLUS_NO_ATTACHMENTS");

  private static bool EnvironmentVariableExists(string variableName)
  {
    string? value = Environment.GetEnvironmentVariable(variableName);
    return !string.IsNullOrWhiteSpace(value);
  }

  public static VerifySettings CheckAutoVerify(this VerifySettings settings)
  {
    ArgumentNullException.ThrowIfNull(settings);

    if (s_autoVerify) {
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
    if (string.IsNullOrWhiteSpace(result)) {
      return Task.CompletedTask;
    }

    result.AttachAs(name);

    return Verify(result, settings, sourceFile);
  }

  public static Task AttachAndVerify(
      this IEnumerable<string> result,
      string name,
      VerifySettings settings,
      [CallerFilePath] string sourceFile = "")
  {
    if (!result.Any()) {
      return Task.CompletedTask;
    }

    string.Join(Environment.NewLine, result).AttachAs(name);

    return Verify(result, settings, sourceFile);
  }

  public static void AttachAs(this string contents, string name)
  {
    if (string.IsNullOrWhiteSpace(contents)) {
      return;
    }

    if (s_attachments) {
      TestContext.Current.AddAttachment(name, contents);
    }
  }
}
