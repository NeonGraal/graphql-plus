﻿using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseCategory(
  ICategoryName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<CategoryOption>, CategoryOption>.D option,
  Parser<CategoryOutput>.D definition
) : DeclarationParser<ICategoryName, NullAst, CategoryOption, CategoryOutput, CategoryDeclAst>(name, param, aliases, option, definition)
{
  protected override void ApplyDefinition(CategoryDeclAst result, CategoryOutput value)
  {
    if (string.IsNullOrWhiteSpace(result.Name)) {
      result.Name = value.Output.Camelize();
    }

    result.Output = value.Output;
  }

  protected override bool ApplyOption(CategoryDeclAst result, IResult<CategoryOption> option)
    => option.Optional(value => result.Option = value);

  protected override bool ApplyParameters(CategoryDeclAst result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override CategoryDeclAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name ?? "", description, "");
}

internal record CategoryOutput(string Output);

internal class CategoryName : ICategoryName
{
  public bool ParseName(Tokenizer tokens, out string? name, out TokenAt at)
  {
    at = tokens.At;
    tokens.Identifier(out name);
    return true;
  }
}

internal interface ICategoryName : INameParser { }

internal class ParseCategoryDefinition : Parser<CategoryOutput>.I
{
  public IResult<CategoryOutput> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (!tokens.Identifier(out var output)) {
      return tokens.Error<CategoryOutput>(label, "output type");
    }

    var result = new CategoryOutput(output);
    return tokens.End(label, () => result);
  }
}
