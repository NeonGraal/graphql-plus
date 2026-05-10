using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifyAllTypes(IVerifierRepository verifiers) : IVerify<IAstType[]>
{
  private readonly Defer<IVerifyUsage<IAstObject<IAstDualField>>>.L _dualAllTypes = verifiers.UsageFor<IAstObject<IAstDualField>>();
  private readonly Defer<IVerifyUsage<IAstEnum>>.L _enumAllTypes = verifiers.UsageFor<IAstEnum>();
  private readonly Defer<IVerifyUsage<IAstObject<IAstInputField>>>.L _inputAllTypes = verifiers.UsageFor<IAstObject<IAstInputField>>();
  private readonly Defer<IVerifyUsage<IAstObject<IAstOutputField>>>.L _outputAllTypes = verifiers.UsageFor<IAstObject<IAstOutputField>>();
  private readonly Defer<IVerifyUsage<IAstDomain>>.L _domainAllTypes = verifiers.UsageFor<IAstDomain>();
  private readonly Defer<IVerifyUsage<IAstUnion>>.L _unionAllTypes = verifiers.UsageFor<IAstUnion>();

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
