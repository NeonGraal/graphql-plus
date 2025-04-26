namespace GqlPlus.Convert;

internal static class JsonTestHelper
{
  internal static string WithTag(this string tag, string value, string key = "value")
  => $"{{\r\n  \"$tag\": \"{tag}\",\r\n  \"{key}\": {value}\r\n}}";

}
