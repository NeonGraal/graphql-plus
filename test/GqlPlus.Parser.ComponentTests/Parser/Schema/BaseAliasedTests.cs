using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Parser.Schema;

public abstract class BaseAliasedTests<TInput, TParsed>(
  IBaseAliasedChecks<TInput, TParsed> aliasChecks
) : BaseNamedTests<TInput, TParsed>(aliasChecks)
  where TParsed : IAstAliased
{
  [Theory, RepeatData]
  public void WithAliases_ReturnsCorrectAst(TInput input, string[] aliases)
    => aliasChecks.WithAliases(input, aliases);

  [Theory, RepeatData]
  public void WithAliasesBad_ReturnsFalse(TInput input, string[] aliases)
    => aliasChecks.WithAliasesBad(input, aliases);

  [Theory, RepeatData]
  public void WithAliasesNone_ReturnsFalse(TInput input)
    => aliasChecks.WithAliasesNone(input);
}

internal abstract class BaseAliasedChecks<TInput, TAliasedAst, TAliased>(
  IParserRepository parsers
) : BaseNamedChecks<TInput, TAliasedAst, TAliased>(parsers)
  , IBaseAliasedChecks<TInput, TAliased>
  where TAliasedAst : AstAliased, TAliased
  where TAliased : IAstAliased
{
  public void WithAliases(TInput input, string[] aliases)
  => TrueExpected(AliasesString(input, "[" + aliases.Joined() + "]"),
      NamedFactory(input) with { Aliases = aliases });

  public void WithAliasesBad(TInput input, string[] aliases)
    => FalseExpected(AliasesString(input, "[" + aliases.Joined()));

  public void WithAliasesNone(TInput input)
    => FalseExpected(AliasesString(input, "[]"));

  [SuppressMessage("Performance", "CA1822:Mark members as static")]
  public IGqlpTypeRef ParentFactory(string parent)
    => new TypeRefAst(AstNulls.At, parent);

  protected internal abstract string AliasesString(TInput input, string aliases);

  protected internal override string NameString(TInput input)
    => AliasesString(input, "");
}

public interface IBaseAliasedChecks<TInput, TParsed>
  : IBaseNamedChecks<TInput, TParsed>
  where TParsed : IAstAliased
{
  void WithAliases(TInput input, string[] aliases);
  void WithAliasesBad(TInput input, string[] aliases);
  void WithAliasesNone(TInput input);
}
