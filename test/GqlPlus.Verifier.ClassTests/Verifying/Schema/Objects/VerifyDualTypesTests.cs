using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualTypesTests
  : ObjectVerifierBase<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, IGqlpDualArg>
{
  private readonly IGqlpDualObject _dual;

  protected override IGqlpDualObject TheObject => _dual;
  protected override IVerifyUsage<IGqlpDualObject> Verifier { get; }

  public VerifyDualTypesTests()
  {
    Verifier = new VerifyDualTypes(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ConstraintMatcher, LoggerFactory);

    _dual = NFor<IGqlpDualObject>("Dual");
  }
}
