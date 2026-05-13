namespace GqlPlus.Verifying.Schema;

public abstract class AliasedVerifierTestsBase<TAliased>
  : GroupedVerifierTestsBase<TAliased>
  where TAliased : class, IAstAliased
{
  private readonly ForV<TAliased> _definition = new();
  protected IVerify<TAliased> Definition => _definition.Intf;

  protected AliasedVerifierTestsBase()
    => VerifierForReturns(Definition);

  protected override void CheckSimpleVerify()
  {
    _definition.Called();

    base.CheckSimpleVerify();
  }
}
