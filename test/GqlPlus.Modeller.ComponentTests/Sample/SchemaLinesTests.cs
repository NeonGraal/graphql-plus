using System.Diagnostics.CodeAnalysis;
using GqlPlus.Convert;
using GqlPlus.Resolving;

namespace GqlPlus.Sample;

public class SchemaLinesTests(
    ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{

  protected override Task VerifyResult(Structured result, string label, string test, string testDirectory)
    => Verify(result.ToLines(true), CustomSettings(label, "Lines", test, testDirectory));

  protected override void CheckNoErrors([NotNull] ITypesContext context, string test)
    => context.Errors.ShouldBeEmpty(test);

  protected override Task CheckResultErrors(string[] dirs, string test, ITokenMessages errors, bool includeVerify = false)
    => CheckErrors(dirs, test, errors, includeVerify);
}
