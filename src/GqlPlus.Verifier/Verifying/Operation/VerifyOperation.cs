using GqlPlus.Ast.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyOperation(IVerifierRepository verifiers) : IVerify<IAstOperation>
{
  private readonly IVerifyIdentified<IAstArg, IAstVariable> _usages = verifiers.IdentifiedFor<IAstArg, IAstVariable>();
  private readonly IVerifyIdentified<IAstSpread, IAstFragment> _spreads = verifiers.IdentifiedFor<IAstSpread, IAstFragment>();

  public void Verify(IAstOperation item, IMessages errors)
  {
    _usages.Verify(new(item.Usages, item.Variables), errors);
    _spreads.Verify(new(item.Spreads, item.Fragments), errors);
    errors.Add(item.Errors);
  }

  internal static VerifyOperation Factory(IVerifierRepository v) => new(v);
}
