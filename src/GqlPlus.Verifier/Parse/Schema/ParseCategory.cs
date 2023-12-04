using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseCategory : DeclarationParser<CategoryName, NullAst, CategoryOption, CategoryOutput, CategoryAst>
{
  public ParseCategory(
    CategoryName name,
    Parser<NullAst>.DA param,
    Parser<string>.DA aliases,
    Parser<CategoryOption>.D option,
    Parser<CategoryOutput>.D definition
  ) : base(name, param, aliases, option, definition)
  {
  }

  protected override void ApplyDefinition(CategoryAst result, CategoryOutput value)
  {
    if (string.IsNullOrWhiteSpace(result.Name)) {
      result.Name = value.Output.Camelize();
    }

    result.Output = value.Output;
  }

  protected override bool ApplyOption(CategoryAst result, IResult<CategoryOption> option)
    => option.Optional(value => result.Option = value);

  protected override bool ApplyParameters(CategoryAst result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override CategoryAst MakeResult(TokenAt at, string? name, string description)
    => new(at, name ?? "", "") { Description = description };
}

internal record CategoryOutput(string Output);

internal class CategoryName : INameParser
{
  public bool ParseName(Tokenizer tokens, out string? name, out TokenAt at)
  {
    at = tokens.At;
    tokens.Identifier(out name);
    return true;
  }
}

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
