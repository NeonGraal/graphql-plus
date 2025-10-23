namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualTypesTests
  : ObjectVerifierTestsBase<IGqlpDualObject, IGqlpDualField>
{
  protected override IVerifyUsage<IGqlpDualObject> Verifier { get; }

  public VerifyDualTypesTests()
    : base(TypeKind.Dual)
    => Verifier = new VerifyDualTypes(new(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ArgDelegate, LoggerFactory));
}
