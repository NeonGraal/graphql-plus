using System.Runtime.CompilerServices;

namespace GqlPlus.Ast;

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

internal sealed class AstAbbreviatedChecks<TAst>(
  BaseAstChecks<TAst>.CreateBy<string> createInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstAbbreviatedChecks<string, TAst>(createInput, createExpression)
  where TAst : IGqlpError
{
}

internal class AstAbbreviatedChecks<TInput, TAst>(
  BaseAstChecks<TAst>.CreateBy<TInput> createInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstBaseChecks<TInput, TAst>(createInput, createExpression)
  , IAstAbbreviatedChecks<TInput>
  where TAst : IGqlpError
{
  public string Abbr { get; } = (createInput(default!) as AstAbbreviated)?.Abbr ?? "??";
}

internal interface IAstAbbreviatedChecks<TInput>
  : IAstBaseChecks<TInput>
{
  string Abbr { get; }
}
