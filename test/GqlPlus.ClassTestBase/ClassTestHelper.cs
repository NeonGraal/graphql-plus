using Xunit;

namespace GqlPlus;

public static class ClassTestHelper
{
  private static readonly bool s_attachments = !EnvironmentVariableExists("GQLPLUS_NO_ATTACHMENTS");

  private static bool EnvironmentVariableExists(string variableName)
  {
    string? value = Environment.GetEnvironmentVariable(variableName);
    return !string.IsNullOrWhiteSpace(value);
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

  public static string[] ToLines(this string text)
    => text.IfWhiteSpace().Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
}
