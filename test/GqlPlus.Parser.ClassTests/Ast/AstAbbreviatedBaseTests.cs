using System.Runtime.CompilerServices;

namespace GqlPlus.Ast;

public abstract class AstAbbreviatedBaseTests
  : AstAbbreviatedBaseTests<string>
{ }

public abstract class AstAbbreviatedBaseTests<TInput>
  : AstBaseTests<TInput>
{
  internal abstract IAstAbbreviatedChecks<TInput> AbbreviatedChecks { get; }

  internal sealed override IAstBaseChecks<TInput> BaseChecks => AbbreviatedChecks;
}

internal class AstAbbreviatedChecks<TAst>(
  BaseAstChecks<TAst>.CreateBy<string> createInput,
  BaseAstChecks<TAst>.CloneBy<string> cloneInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstAbbreviatedChecks<string, TAst>(createInput, cloneInput, createExpression)
  where TAst : IGqlpError
{ }

internal class AstAbbreviatedChecks<TInput, TAst>(
  BaseAstChecks<TAst>.CreateBy<TInput> createInput,
  BaseAstChecks<TAst>.CloneBy<TInput> cloneInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstBaseChecks<TInput, TAst>(createInput, cloneInput, createExpression)
  , IAstAbbreviatedChecks<TInput>
  where TAst : IGqlpError
{
  public string Abbr { get; } = ((createInput(default!) as AstAbbreviated)?.Abbr).IfWhiteSpace("??");

  protected virtual string AbbreviatedString(TInput input)
    => $"( !{Abbr} {input} )";
  protected override string InputString(TInput input)
    => AbbreviatedString(input);
}

internal interface IAstAbbreviatedChecks<TInput>
  : IAstBaseChecks<TInput>
{
  string Abbr { get; }
}
