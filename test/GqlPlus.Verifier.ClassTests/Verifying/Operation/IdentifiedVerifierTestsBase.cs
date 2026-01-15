using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

public abstract class IdentifiedVerifierTestsBase<TUsage, TIdentified>
  : VerifierTestsBase
  where TUsage : class, IGqlpError
  where TIdentified : class, IGqlpIdentified
{
  private readonly ForV<TUsage> _usage = new();
  private readonly ForV<TIdentified> _definition = new();

  protected IVerify<TUsage> Usage => _usage.Intf;
  protected IVerify<TIdentified> Definition => _definition.Intf;

  private readonly Lazy<IdentifiedVerifier<TUsage, TIdentified>> _verifier;

  protected IdentifiedVerifierTestsBase()
    => _verifier = new(NewVerifier);

  [Fact]
  public void Verify_WithNone()
  {
    UsageIdentified<TUsage, TIdentified> item = new([], []);

    _verifier.Value.Verify(item, Errors);

    item.ShouldSatisfyAllConditions(
      _usage.NotCalled,
      _definition.NotCalled,
      () => Errors.ShouldBeEmpty());
  }

  [Fact]
  public void Verify_WithDefinition()
  {
    UsageIdentified<TUsage, TIdentified> item = new([], OneDefinition("defined"));

    _verifier.Value.Verify(item, Errors);

    item.ShouldSatisfyAllConditions(
      _usage.NotCalled,
      _definition.Called,
      () => Errors.Count.ShouldBe(1));
  }

  [Fact]
  public void Verify_WithUsage()
  {
    UsageIdentified<TUsage, TIdentified> item = new(OneUsage("usage"), []);

    _verifier.Value.Verify(item, Errors);

    item.ShouldSatisfyAllConditions(
      _usage.Called,
      _definition.NotCalled,
      () => Errors.Count.ShouldBe(1));
  }

  [Fact]
  public void Verify_WithDifferent()
  {
    IdentifiedVerifier<TUsage, TIdentified> verifier = NewVerifier();

    UsageIdentified<TUsage, TIdentified> item = new(OneUsage("usage"), OneDefinition("defined"));

    VerifyWithErrors(item, 2);
  }

  [Fact]
  public void Verify_WithMatching()
  {
    UsageIdentified<TUsage, TIdentified> item = new(OneUsage("match"), OneDefinition("match"));

    VerifyWithOutErrors(item);
  }

  internal void VerifyWithOutErrors(UsageIdentified<TUsage, TIdentified> item)
  {
    _verifier.Value.Verify(item, Errors);

    item.ShouldSatisfyAllConditions(
      _usage.Called,
      _definition.Called,
      () => Errors.ShouldBeEmpty());
  }

  internal void VerifyWithErrors(UsageIdentified<TUsage, TIdentified> item, int count)
  {
    _verifier.Value.Verify(item, Errors);

    item.ShouldSatisfyAllConditions(
      _usage.Called,
      _definition.Called,
      () => Errors.Count.ShouldBe(count));
  }

  internal abstract IdentifiedVerifier<TUsage, TIdentified> NewVerifier();
  protected abstract IEnumerable<TIdentified> OneDefinition(string name);
  protected abstract IEnumerable<TUsage> OneUsage(string key);
}
