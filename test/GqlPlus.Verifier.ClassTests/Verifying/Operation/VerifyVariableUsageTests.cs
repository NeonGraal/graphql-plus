using GqlPlus.Ast.Operation;

namespace GqlPlus.Verifying.Operation;

public class VerifyVariableUsageTests
  : IdentifiedVerifierTestsBase<IAstArg, IAstVariable>
{
  protected override IEnumerable<IAstVariable> OneDefinition(string name)
  {
    IAstVariable definition = A.Variable(name);

    return [definition];
  }

  protected override IEnumerable<IAstArg> OneUsage(string key)
  {
    IAstArg usage = A.Error<IAstArg>();
    usage.Variable.Returns(key);

    return [usage];
  }

  internal override IdentifiedVerifier<IAstArg, IAstVariable> NewVerifier()
    => new VerifyVariableUsage(VerifierRepo);
}
