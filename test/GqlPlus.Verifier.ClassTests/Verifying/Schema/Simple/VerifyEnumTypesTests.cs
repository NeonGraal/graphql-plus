using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyEnumTypesTests
  : UsageVerifierTestsBase<IGqlpEnum>
{
  private readonly ForM<IGqlpEnumLabel> _mergeLabels = new();
  private readonly VerifyEnumTypes _verifier;

  private readonly IGqlpEnum _enum;

  protected override IGqlpEnum TheUsage => _enum;
  protected override IVerifyUsage<IGqlpEnum> Verifier => _verifier;

  public VerifyEnumTypesTests()
  {
    _verifier = new(Aliased.Intf, _mergeLabels.Intf);

    _enum = NFor<IGqlpEnum>("Enum");
  }

  [Fact]
  public void Verify_CallsVerifierWithoutErrors()
  {
    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      _mergeLabels.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_Enum_ReturnsNoErrors()
  {
    Usages.Add(_enum);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_EnumLabels_ReturnsNoErrors()
  {
    IGqlpEnumLabel[] labels = NForA<IGqlpEnumLabel>("Label1", "Label2");
    labels[0].Aliases.Returns(["Alias1", "Alias2"]);
    _enum.Items.Returns(labels);

    Usages.Add(_enum);

    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      _mergeLabels.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_EnumParent_ReturnsNoErrors()
  {
    Define<IGqlpEnum>("Parent");

    _enum.Parent.Returns("Parent");

    Usages.Add(_enum);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Fact]
  public void Verify_EnumParentLabels_ReturnsNoErrors()
  {
    IGqlpEnum parent = NFor<IGqlpEnum>("Parent");
    IGqlpEnumLabel[] parentLabels = NForA<IGqlpEnumLabel>("Label3", "Label4");
    parent.Items.Returns(parentLabels);

    Definitions.Add(parent);

    IGqlpEnumLabel[] labels = NForA<IGqlpEnumLabel>("Label1", "Label2");
    _enum.Items.Returns(labels);
    _enum.Parent.Returns("Parent");

    Usages.Add(_enum);

    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      _mergeLabels.Called,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_EnumParentLabelsCantMerge_ReturnsErrors()
  {
    IGqlpEnum parent = NFor<IGqlpEnum>("Parent");
    IGqlpEnumLabel[] parentLabels = NForA<IGqlpEnumLabel>("Label3", "Label4");
    parent.Items.Returns(parentLabels);

    Definitions.Add(parent);

    IGqlpEnumLabel[] labels = NForA<IGqlpEnumLabel>("Label1", "Label2");
    _enum.Items.Returns(labels);
    _enum.Parent.Returns("Parent");

    _mergeLabels.Intf.CanMerge(Arg.Any<IEnumerable<IGqlpEnumLabel>>()).Returns(MakeMessages("Error"));

    Usages.Add(_enum);

    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      _mergeLabels.Called,
      () => Errors.ShouldNotBeEmpty());
  }
}
