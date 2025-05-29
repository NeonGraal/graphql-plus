using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

public abstract class AliasedVerifierTestsBase<TAliased>
  : GroupedVerifierTestsBase<TAliased>
  where TAliased : class, IGqlpAliased
{
  private readonly ForV<TAliased> _definition = new();
  protected IVerify<TAliased> Definition => _definition.Intf;

  protected override void CheckSimpleVerify()
  {
    _definition.Called();

    base.CheckSimpleVerify();
  }
}
