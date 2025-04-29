using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualTypesTests
  : ObjectVerifierBase<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>
{
  private readonly IGqlpDualObject _dual;

  protected override IGqlpDualObject TheObject => _dual;
  protected override IVerifyUsage<IGqlpDualObject> Verifier { get; }

  public VerifyDualTypesTests()
  {
    Verifier = new VerifyDualTypes(Aliased.Intf, MergeFields.Intf, MergeAlternates.Intf, Logger);

    _dual = NFor<IGqlpDualObject>("Dual");
  }

  [Fact]
  public void Verify_Dual_WithTypeParams_ReturnsNoErrors()
  {
    IGqlpTypeParam[] typeParams = NForA<IGqlpTypeParam>("a");
    _dual.TypeParams.Returns(typeParams);
    IGqlpDualBase parent = NFor<IGqlpDualBase>("a");
    parent.IsTypeParam.Returns(true);
    _dual.ObjParent.Returns(parent);

    Usages.Add(_dual);
    Definitions.Add(_dual);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_Dual_WithTypeArg_ReturnsNoErrors()
  {
    Define<IGqlpTypeSpecial>("String");

    IGqlpDualObject other = NFor<IGqlpDualObject>("Other");
    IGqlpTypeParam[] typeParams = NForA<IGqlpTypeParam>("a");
    other.TypeParams.Returns(typeParams);
    IGqlpDualBase parent = NFor<IGqlpDualBase>("a");
    parent.IsTypeParam.Returns(true);
    other.ObjParent.Returns(parent);

    IGqlpDualField field = NFor<IGqlpDualField>("field");
    IGqlpDualBase dualBase = NFor<IGqlpDualBase>("Other");
    IGqlpDualArg[] args = NForA<IGqlpDualArg>("String");
    dualBase.Args.Returns(args);
    dualBase.BaseArgs.Returns(args);
    field.Type.Returns(dualBase);
    field.BaseType.Returns(dualBase);

    _dual.Fields.Returns([field]);
    _dual.ObjFields.Returns([field]);

    Usages.Add(_dual);
    Definitions.Add(other);

    Verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }
}
