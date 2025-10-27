namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualsAliasedTests()
  : VerifyObjectsAliasedTests<IGqlpDualField>(TypeKind.Dual)
{ }
