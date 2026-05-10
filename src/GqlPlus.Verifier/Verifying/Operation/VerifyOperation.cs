using GqlPlus.Ast.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyOperation(IVerifierRepository verifiers)
  : IVerify<IAstOperation>
{
  private readonly Defer<IVerifyIdentified<IAstArg, IAstVariable>>.L _usages = verifiers.IdentifiedFor<IAstArg, IAstVariable>();
  private readonly Defer<IVerifyIdentified<IAstSpread, IAstFragment>>.L _spreads = verifiers.IdentifiedFor<IAstSpread, IAstFragment>();

  public void Verify(IAstOperation item, IMessages errors)
  {
    _usages.I.Verify(new(item.Usages, item.Variables), errors);
    _spreads.I.Verify(new(item.Spreads, item.Fragments), errors);
    errors.Add(item.Errors);
  }

  internal static VerifyOperation Factory(IVerifierRepository v) => new(v);
}
