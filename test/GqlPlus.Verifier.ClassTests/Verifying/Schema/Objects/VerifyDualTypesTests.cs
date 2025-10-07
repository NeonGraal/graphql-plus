﻿namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualTypesTests
  : ObjectVerifierTestsBase<IGqlpDualObject, IGqlpDualField>
{
  private readonly IGqlpDualObject _dual;

  protected override IGqlpDualObject TheObject => _dual;
  protected override IVerifyUsage<IGqlpDualObject> Verifier { get; }

  public VerifyDualTypesTests()
    : base(TypeKind.Dual)
  {
    Verifier = new VerifyDualTypes(new(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, ArgDelegate, LoggerFactory));

    _dual = A.Obj<IGqlpDualObject>(TypeKind.Dual, "Dual");
  }
}
