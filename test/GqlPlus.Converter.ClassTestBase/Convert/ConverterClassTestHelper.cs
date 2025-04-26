namespace GqlPlus.Convert;

public static class ConverterClassTestHelper
{
  public static string[] ToLines(this string text)
    => (text ?? "").Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
}
