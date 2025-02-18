using GqlPlus.Abstractions.Operation;
using NSubstitute;

namespace GqlPlus.Verifying.Operation;

public class VerifyFragmentUsageTests
  : NamedVerifierBase<IGqlpSpread, IGqlpFragment>
{
  protected override IEnumerable<IGqlpFragment> OneDefinition(string name)
  {
    IGqlpFragment definition = EFor<IGqlpFragment>();
    definition.Name.Returns(name);

    return [definition];
  }

  protected override IEnumerable<IGqlpSpread> OneUsage(string key)
  {
    IGqlpSpread usage = EFor<IGqlpSpread>();
    usage.Name.Returns(key);

    return [usage];
  }

  internal override NamedVerifier<IGqlpSpread, IGqlpFragment> NewVerifier()
    => new VerifyFragmentUsage(Usage, Definition);
}
