using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Verification;
internal class FragmentsContext : VerificationContext
{
  internal FragmentAst[] Fragments { get; }

  public FragmentsContext(VerificationContext context, FragmentAst[] fragments)
  {
    Errors = context.Errors;
    Fragments = fragments;
  }
}
