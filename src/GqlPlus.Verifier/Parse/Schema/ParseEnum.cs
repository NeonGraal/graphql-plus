﻿using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseEnum(
  ISimpleName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<EnumDefinition>.D definition
  ) : DeclarationParser<EnumDefinition, EnumDeclAst>(name, param, aliases, option, definition)
{
  protected override EnumDeclAst MakeResult(EnumDeclAst result, EnumDefinition value)
  {
    result.Parent = value.Parent;
    result.Members = value.Values;

    return result;
  }

  protected override bool ApplyOption(EnumDeclAst result, IResult<NullOption> option) => true;
  protected override bool ApplyParameters(EnumDeclAst result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override EnumDeclAst MakePartial(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class EnumDefinition
{
  internal string? Parent { get; set; }
  internal EnumMemberAst[] Values { get; set; } = [];
}

internal class ParseEnumDefinition(
  Parser<EnumMemberAst>.D enumMember
) : Parser<EnumDefinition>.I
{
  private readonly Parser<EnumMemberAst>.L _enumMember = enumMember;

  public IResult<EnumDefinition> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    EnumDefinition result = new();

    if (tokens.Take(':')) {
      if (tokens.Identifier(out var parent)) {
        result.Parent = parent;
      } else {
        return tokens.Error(label, "type after ':'", result);
      }
    }

    List<EnumMemberAst> members = [];
    while (!tokens.Take("}")) {
      var enumMember = _enumMember.Parse(tokens, "Enum Member");
      if (!enumMember.Required(members.Add)) {
        result.Values = [.. members];
        return enumMember.AsResult(result);
      }
    }

    result.Values = [.. members];
    return members.Count != 0
      ? result.Ok()
      : tokens.Partial(label, "at least one member", () => result);
  }
}
