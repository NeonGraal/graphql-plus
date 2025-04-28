using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

public class VerifyFragmentUsageTests
  : IdentifiedVerifierBase<IGqlpSpread, IGqlpFragment>
{
  protected override IEnumerable<IGqlpFragment> OneDefinition(string name)
  {
    IGqlpFragment definition = EFor<IGqlpFragment>();
    definition.Identifier.Returns(name);

    return [definition];
  }

  protected override IEnumerable<IGqlpSpread> OneUsage(string key)
  {
    IGqlpSpread usage = EFor<IGqlpSpread>();
    usage.Identifier.Returns(key);

    return [usage];
  }

  internal override IdentifiedVerifier<IGqlpSpread, IGqlpFragment> NewVerifier()
    => new VerifyFragmentUsage(Usage, Definition);
}
