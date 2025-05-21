using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

public abstract class IdentifiedVerifierBase<TUsage, TIdentified>
  : VerifierBase
  where TUsage : class, IGqlpError
  where TIdentified : class, IGqlpIdentified
{
  private readonly ForV<TUsage> _usage = new();
  private readonly ForV<TIdentified> _definition = new();

  protected IVerify<TUsage> Usage => _usage.Intf;
  protected IVerify<TIdentified> Definition => _definition.Intf;

  [Fact]
  public void Verify_WithNone()
  {
    IdentifiedVerifier<TUsage, TIdentified> verifier = NewVerifier();

    UsageIdentified<TUsage, TIdentified> item = new([], []);

    verifier.Verify(item, Errors);

    verifier.ShouldSatisfyAllConditions(
      _usage.NotCalled,
      _definition.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_WithDefinition()
  {
    IdentifiedVerifier<TUsage, TIdentified> verifier = NewVerifier();

    UsageIdentified<TUsage, TIdentified> item = new([], OneDefinition("defined"));

    verifier.Verify(item, Errors);

    verifier.ShouldSatisfyAllConditions(
      _usage.NotCalled,
      _definition.Called,
      () => Errors.Count.ShouldBe(1));
  }

  [Fact]
  public void Verify_WithUsage()
  {
    IdentifiedVerifier<TUsage, TIdentified> verifier = NewVerifier();

    UsageIdentified<TUsage, TIdentified> item = new(OneUsage("usage"), []);

    verifier.Verify(item, Errors);

    verifier.ShouldSatisfyAllConditions(
      _usage.Called,
      _definition.NotCalled,
      () => Errors.Count.ShouldBe(1));
  }

  [Fact]
  public void Verify_WithDifferent()
  {
    IdentifiedVerifier<TUsage, TIdentified> verifier = NewVerifier();

    UsageIdentified<TUsage, TIdentified> item = new(OneUsage("usage"), OneDefinition("defined"));

    verifier.Verify(item, Errors);

    verifier.ShouldSatisfyAllConditions(
      _usage.Called,
      _definition.Called,
      () => Errors.Count.ShouldBe(2));
  }

  [Fact]
  public void Verify_WithMatching()
  {
    IdentifiedVerifier<TUsage, TIdentified> verifier = NewVerifier();

    UsageIdentified<TUsage, TIdentified> item = new(OneUsage("match"), OneDefinition("match"));

    verifier.Verify(item, Errors);

    verifier.ShouldSatisfyAllConditions(
      _usage.Called,
      _definition.Called,
      () => Errors.ShouldBeEmpty());
  }

  internal abstract IdentifiedVerifier<TUsage, TIdentified> NewVerifier();
  protected abstract IEnumerable<TIdentified> OneDefinition(string name);
  protected abstract IEnumerable<TUsage> OneUsage(string key);
}
