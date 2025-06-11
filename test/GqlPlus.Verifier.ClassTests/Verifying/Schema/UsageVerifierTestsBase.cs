using System.Collections.ObjectModel;

namespace GqlPlus.Verifying.Schema;

public abstract class UsageVerifierTestsBase<TUsage>
  : VerifierTypeTestsBase
  where TUsage : class, IGqlpAliased
{
  internal ForVA<TUsage> Aliased { get; } = new();
  protected Collection<TUsage> Usages { get; } = [];
  protected ICollection<IGqlpType> Definitions => _definitions;

  private readonly List<IGqlpType> _definitions = [];

  protected UsageAliased<TUsage> UsageAliased => new([.. Usages], [.. _definitions, .. Types.Values.OfType<IGqlpType>()]);

  protected abstract TUsage TheUsage { get; }
  protected abstract IVerifyUsage<TUsage> Verifier { get; }

  [Fact]
  public void Verify_CallsVerifierAndAliased_WithoutErrors()
  {
    Verifier.Verify(UsageAliased, Errors);

    Verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      () => Errors.ShouldBeEmpty());
  }

  internal void Define<T>(params string[] names)
    where T : class, IGqlpType
  {
    IGqlpType[] types = A.NamedArray<T>(names);
    AddTypes(types);
    _definitions.AddRange(types);
  }

  internal void Define<T, T1>(string name)
    where T : class, IGqlpType
    where T1 : class, IGqlpType
  {
    IGqlpType type = A.Of<T, T1>();
    type.Name.Returns(name);
    type.MakeError("").ReturnsForAnyArgs(c => c.ThrowIfNull().Arg<string>().MakeMessages());
    AddTypes(type);
    _definitions.Add(type);
  }
}
