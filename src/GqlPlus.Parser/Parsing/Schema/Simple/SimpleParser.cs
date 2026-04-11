using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal abstract class SimpleParser<TDefinition, TResult>(
  IParserRepository parsers
) : DeclarationParser<TDefinition, TResult>(parsers)
  where TDefinition : SimpleDefinition
  where TResult : IAstSimple
{ }

public class SimpleDefinition
{
  internal IAstTypeRef? Parent { get; set; }
}

internal abstract class SimpleDefinitionParser<TDefinition>(
      IParserRepository parsers
) : Parser<TDefinition>.I
  where TDefinition : SimpleDefinition
{
  private readonly Parser<IAstTypeRef>.L _typeRef = parsers.ParserFor<IAstTypeRef>();

  protected bool ParseParent(ITokenizer tokens, TDefinition result)
  {
    if (tokens.Take(':')) {
      IResult<IAstTypeRef> parent = _typeRef.Parse(tokens, "Parent");
      return parent.Required(value => result.Parent = value);
    }

    return true;
  }

  public abstract IResult<TDefinition> Parse(ITokenizer tokens, string label);
}
