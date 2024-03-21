using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseUnion(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<UnionDefinition>.D definition
  ) : DeclarationParser<UnionDefinition, UnionDeclAst>(name, param, aliases, option, definition)
{
  protected override UnionDeclAst MakeResult(UnionDeclAst result, UnionDefinition value)
    => result with { Parent = value.Parent, Members = value.Values };

  protected override bool ApplyOption(UnionDeclAst result, IResult<NullOption> option) => true;
  protected override bool ApplyParameters(UnionDeclAst result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override UnionDeclAst MakePartial(TokenAt at, string? name, string description)
    => new(at, name!, description, []);
}

internal class UnionDefinition
{
  internal string? Parent { get; set; }
  internal string[] Values { get; set; } = [];
}

internal class ParseUnionDefinition
  : Parser<UnionDefinition>.I
{
  public IResult<UnionDefinition> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    UnionDefinition result = new();

    if (tokens.Take(':')) {
      if (tokens.Identifier(out var parent)) {
        result.Parent = parent;
      } else {
        return tokens.Error(label, "type after ':'", result);
      }
    }

    List<string> members = [];
    while (tokens.Identifier(out var unionMember)) {
      members.Add(unionMember);
    }

    result.Values = [.. members];
    return !tokens.Take("}")
      ? tokens.Partial(label, "'}' after members", () => result)
      : members.Count != 0
        ? result.Ok()
        : tokens.Partial(label, "at least one member", () => result);
  }
}
