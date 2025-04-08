using GqlPlus.Convert;

namespace GqlPlus.Sample;

public class SchemaLinesTests(
    ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{
  protected override Task VerifyResult(Structured result, string label, string test, string testDirectory)
    => Verify(result.ToLines(true), CustomSettings(label, "Lines", test, testDirectory));

  protected override Task CheckResultErrors(string category, string directory, string file, ITokenMessages errors, bool includeVerify = false)
    => CheckErrors(category, directory, file, errors, includeVerify);
}
