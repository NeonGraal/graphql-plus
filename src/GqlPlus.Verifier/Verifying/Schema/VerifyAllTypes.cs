using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifyAllTypes(IVerifierRepository verifiers) : IVerify<IAstType[]>
{
  private readonly DeferOne<IVerifyUsage<IAstObject<IAstDualField>>> _dualAllTypes = verifiers.UsageFor<IAstObject<IAstDualField>>();
  private readonly DeferOne<IVerifyUsage<IAstEnum>> _enumAllTypes = verifiers.UsageFor<IAstEnum>();
  private readonly DeferOne<IVerifyUsage<IAstObject<IAstInputField>>> _inputAllTypes = verifiers.UsageFor<IAstObject<IAstInputField>>();
  private readonly DeferOne<IVerifyUsage<IAstObject<IAstOutputField>>> _outputAllTypes = verifiers.UsageFor<IAstObject<IAstOutputField>>();
  private readonly DeferOne<IVerifyUsage<IAstDomain>> _domainAllTypes = verifiers.UsageFor<IAstDomain>();
  private readonly DeferOne<IVerifyUsage<IAstUnion>> _unionAllTypes = verifiers.UsageFor<IAstUnion>();

  public void Verify(IAstType[] item, IMessages errors)
  {
    IAstType[] allTypes = [.. item, .. BuiltIn.Basic, .. BuiltIn.Internal];

    IAstObject<IAstDualField>[] dualTypes = item.ArrayOf<IAstObject<IAstDualField>>();
    IAstEnum[] enumTypes = item.ArrayOf<IAstEnum>();
    IAstObject<IAstInputField>[] inputTypes = item.ArrayOf<IAstObject<IAstInputField>>();
    IAstObject<IAstOutputField>[] outputTypes = item.ArrayOf<IAstObject<IAstOutputField>>();
    IAstDomain[] domainTypes = item.ArrayOf<IAstDomain>();
    IAstUnion[] unionTypes = item.ArrayOf<IAstUnion>();

    _dualAllTypes.I.Verify(new(dualTypes, allTypes), errors);
    _enumAllTypes.I.Verify(new(enumTypes, allTypes), errors);
    _inputAllTypes.I.Verify(new(inputTypes, allTypes), errors);
    _outputAllTypes.I.Verify(new(outputTypes, allTypes), errors);
    _domainAllTypes.I.Verify(new(domainTypes, allTypes), errors);
    _unionAllTypes.I.Verify(new(unionTypes, allTypes), errors);
  }

  internal static VerifyAllTypes Factory(IVerifierRepository v) => new(v);
}
