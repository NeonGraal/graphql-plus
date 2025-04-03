using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying;

namespace GqlPlus.Schema;

public abstract class AliasedVerifierBase<TAliased>
  : GroupedVerifierBase<TAliased>
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
