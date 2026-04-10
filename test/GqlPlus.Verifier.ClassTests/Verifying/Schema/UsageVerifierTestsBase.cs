using System.Collections.ObjectModel;

namespace GqlPlus.Verifying.Schema;

public abstract class UsageVerifierTestsBase<TUsage>
  : VerifierTypeTestsBase
  where TUsage : class, IAstAliased
{
  internal ForVA<TUsage> Aliased { get; } = new();
  protected Collection<TUsage> Usages { get; } = [];
  protected ICollection<IAstType> Definitions => _definitions;

  private readonly List<IAstType> _definitions = [];

  protected UsageAliased<TUsage> UsageAliased => new([.. Usages], [.. _definitions, .. Types.Values.OfType<IAstType>()]);

  protected abstract TUsage TheUsage { get; }
  protected abstract IVerifyUsage<TUsage> Verifier { get; }

  protected UsageVerifierTestsBase()
    => VerifierRepo.AliasedFor<TUsage>().Returns(Aliased.Intf);

  [Fact]
  public void Verify_CallsVerifierAndAliased_WithoutErrors()
  {
    Verifier.Verify(UsageAliased, Errors);

    Verifier.ShouldSatisfyAllConditions(
      Aliased.Called,
      () => Errors.ShouldBeEmpty());
  }

  internal void Define(params IAstType[] types)
  {
    AddTypes(types);
    _definitions.AddRange(types);
  }

  internal void Define<T>(params string[] names)
    where T : class, IAstType
  {
    IAstType[] types = A.NamedArray<T>(names);
    Define(types);
  }

  internal void Define<T, T1>(string name)
    where T : class, IAstType
    where T1 : class, IAstType
  {
    IAstType type = A.Of<T, T1>();
    type.Name.Returns(name);
    type.MakeError("").ReturnsForAnyArgs(c => c.ThrowIfNull().Arg<string>().MakeMessages());
    Define(type);
  }
}
