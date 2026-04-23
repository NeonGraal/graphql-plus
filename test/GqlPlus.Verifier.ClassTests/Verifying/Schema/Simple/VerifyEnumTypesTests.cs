using GqlPlus.Building.Schema.Simple;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyEnumTypesTests
  : UsageVerifierTestsBase<IAstEnum>
{
  private readonly ForM<IAstEnumLabel> _mergeLabels = new();
  private readonly VerifyEnumTypes _verifier;

  private readonly EnumBuilder _enum;
  private IAstEnum? _usage;

  protected override IAstEnum TheUsage => _usage ??= _enum.AsEnum;
  protected override IVerifyUsage<IAstEnum> Verifier => _verifier;

  public VerifyEnumTypesTests()
  {
    VerifierRepo.MergerFor<IAstEnumLabel>().Returns(_mergeLabels.Intf);
    _verifier = new(VerifierRepo);

    _enum = A.Enum("Enum");
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
  public void Verify_EnumWithNoLabels_ReturnsError()
  {
    Usages.Add(TheUsage);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldNotBeEmpty();
  }

  [Fact]
  public void Verify_EnumLabels_ReturnsNoErrors()
  {
    IAstEnumLabel[] labels = A.NamedArray<IAstEnumLabel>("Label1", "Label2");
    labels[0].Aliases.Returns(["Alias1", "Alias2"]);
    _enum.WithLabels(labels);

    Usages.Add(TheUsage);

    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      _mergeLabels.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Theory, RepeatData]
  public void Verify_EnumParent_ReturnsNoErrors(string name, string parentName)
  {
    this.SkipEqual(name, parentName);

    Define(A.Enum(parentName).AsEnum);

    IAstEnumLabel[] labels = A.NamedArray<IAstEnumLabel>("Label1", "Label2");
    IAstEnum anEnum = A.Enum(name)
      .WithParent(parentName)
      .WithLabels(labels)
      .AsEnum;

    Usages.Add(anEnum);

    _verifier.Verify(UsageAliased, Errors);

    Errors.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void Verify_EnumParentLabels_ReturnsNoErrors(string name, string[] labels, string parentName, string[] parentLabels)
  {
    this.SkipEqual(name, parentName);

    IAstEnum parent = A.Enum(parentName, parentLabels);
    Definitions.Add(parent);

    IAstEnum anEnum = A.Enum(name)
      .WithParent(parentName)
      .WithLabels(labels)
      .AsEnum;
    Usages.Add(anEnum);

    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      _mergeLabels.Called,
      () => Errors.ShouldBeEmpty());
  }

  [Theory, RepeatData]
  public void Verify_EnumParentLabelsCantMerge_ReturnsErrors(string name, string[] labels, string parentName, string[] parentLabels)
  {
    IAstEnum parent = A.Enum(parentName, parentLabels);
    Definitions.Add(parent);

    IAstEnum anEnum = A.Enum(name)
      .WithParent(parentName)
      .WithLabels(labels)
      .AsEnum;
    Usages.Add(anEnum);

    _mergeLabels.Intf.CanMerge(Arg.Any<IEnumerable<IAstEnumLabel>>()).Returns("Error".MakeMessages());

    _verifier.Verify(UsageAliased, Errors);

    _verifier.ShouldSatisfyAllConditions(
      _mergeLabels.Called,
      () => Errors.ShouldNotBeEmpty());
  }
}
