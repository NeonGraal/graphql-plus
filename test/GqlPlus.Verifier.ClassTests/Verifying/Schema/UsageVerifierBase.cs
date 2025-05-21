using System.Collections.ObjectModel;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

public abstract class UsageVerifierBase<TUsage>
  : VerifierTypeBase
  where TUsage : class, IGqlpAliased
{
  internal ForVA<TUsage> Aliased { get; } = new();
  protected Collection<TUsage> Usages { get; } = [];
  protected Collection<IGqlpType> Definitions { get; } = [];

  protected UsageAliased<TUsage> UsageAliased => new([.. Usages], [.. Definitions, .. Types.Values.OfType<IGqlpType>()]);

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
    foreach (string name in names) {
      Definitions.Add(AddType<T>(name));
    }
  }
}
