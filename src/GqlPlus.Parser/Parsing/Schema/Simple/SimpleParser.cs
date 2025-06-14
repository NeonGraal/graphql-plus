using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal abstract class SimpleParser<TDefinition, TResult>(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<TDefinition>.D definition
) : DeclarationParser<TDefinition, TResult>(name, param, aliases, option, definition)
  where TDefinition : SimpleDefinition
  where TResult : IGqlpSimple
{ }

internal class SimpleDefinition
{
  internal IGqlpTypeRef? Parent { get; set; }
}

internal abstract class SimpleDefinitionParser<TDefinition>(
      Parser<IGqlpTypeRef>.D typeRef
) : Parser<TDefinition>.I
  where TDefinition : SimpleDefinition
{
  private readonly Parser<IGqlpTypeRef>.L _typeRef = typeRef;

  protected bool ParseParent(ITokenizer tokens, TDefinition result)
  {
    if (tokens.Take(':')) {
      IResult<IGqlpTypeRef> parent = _typeRef.Parse(tokens, "Parent");
      return parent.Required(value => result.Parent = value);
    }

    return true;
  }

  public abstract IResult<TDefinition> Parse(ITokenizer tokens, string label);
}
