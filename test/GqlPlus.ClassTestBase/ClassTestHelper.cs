namespace GqlPlus;

public static class ClassTestHelper
{
  public static string[] ToLines(this string text)
    => text.IfWhiteSpace().Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
}
