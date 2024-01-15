using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Ast;

public abstract class AstAbbreviatedTests
  : AstAbbreviatedTests<string>
{ }

public abstract class AstAbbreviatedTests<TInput>
  : AstBaseTests<TInput>
{
  internal abstract IAstAbbreviatedChecks<TInput> AbbreviatedChecks { get; }

  protected virtual string AbbreviatedString(TInput input)
    => $"( !{AbbreviatedChecks.Abbr} {input} )";
  protected override string InputString(TInput input)
    => AbbreviatedString(input);

  internal sealed override IAstBaseChecks<TInput> BaseChecks => AbbreviatedChecks;
}

internal sealed class AstAbbreviatedChecks<TAst>
  : AstAbbreviatedChecks<string, TAst>
  where TAst : AstAbbreviated
{
  public AstAbbreviatedChecks(CreateBy<string> createInput,
    [CallerArgumentExpression("createInput")] string createExpression = "")
    : base(createInput, createExpression)
  { }
}

internal class AstAbbreviatedChecks<TInput, TAst>
  : AstBaseChecks<TInput, TAst>, IAstAbbreviatedChecks<TInput>
  where TAst : AstAbbreviated
{
  public AstAbbreviatedChecks(CreateBy<TInput> createInput,
    [CallerArgumentExpression("createInput")] string createExpression = "")
    : base(createInput, createExpression)
    => Abbr = createInput(default!).Abbr;

  public string Abbr { get; }
}

internal interface IAstAbbreviatedChecks<TInput>
  : IAstBaseChecks<TInput>
{
  string Abbr { get; }
}
