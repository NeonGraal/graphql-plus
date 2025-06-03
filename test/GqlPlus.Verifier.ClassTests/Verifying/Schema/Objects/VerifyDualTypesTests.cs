namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualTypesTests
  : ObjectVerifierTestsBase<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, IGqlpDualArg>
{
  private readonly IGqlpDualObject _dual;

  protected override IGqlpDualObject TheObject => _dual;
  protected override IVerifyUsage<IGqlpDualObject> Verifier { get; }

  public VerifyDualTypesTests()
  {
    Verifier = new VerifyDualTypes(new(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ArgDelegate, LoggerFactory));

    _dual = NFor<IGqlpDualObject>("Dual");
  }
}
