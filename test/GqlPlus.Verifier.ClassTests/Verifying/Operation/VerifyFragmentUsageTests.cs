using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

public class VerifyFragmentUsageTests
  : IdentifiedVerifierTestsBase<IGqlpSpread, IGqlpFragment>
{
  [Fact]
  public void Verify_WithCycle()
  {
    IEnumerable<IGqlpSpread> usage1 = OneUsage("frag1");
    IEnumerable<IGqlpSpread> usage2 = OneUsage("frag2");

    IGqlpFragment definition1 = OneDefinition("frag1").First();
    definition1.Selections.Returns(usage2.Cast<IGqlpSelection>());
    IGqlpFragment definition2 = OneDefinition("frag2").First();
    definition2.Selections.Returns(usage1.Cast<IGqlpSelection>());

    UsageIdentified<IGqlpSpread, IGqlpFragment> item = new(usage1.Concat(usage2), [definition1, definition2]);

    VerifyWithErrors(item, 1);
  }

  protected override IEnumerable<IGqlpFragment> OneDefinition(string name)
  {
    IGqlpFragment definition = A.Error<IGqlpFragment>();
    definition.Identifier.Returns(name);

    return [definition];
  }

  protected override IEnumerable<IGqlpSpread> OneUsage(string key)
  {
    IGqlpSpread usage = A.Error<IGqlpSpread>();
    usage.Identifier.Returns(key);

    return [usage];
  }

  internal override IdentifiedVerifier<IGqlpSpread, IGqlpFragment> NewVerifier()
    => new VerifyFragmentUsage(Usage, Definition);
}
