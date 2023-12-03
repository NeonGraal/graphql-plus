using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseCategory : DeclarationParser<CategoryName, NullAst, CategoryOption, CategoryOutput, CategoryAst>
{
  public ParseCategory(
    CategoryName name,
    IParserArray<NullAst> param,
    IParserArray<string> aliases,
    IParser<CategoryOption> option,
    IParser<CategoryOutput> definition
  ) : base(name, param, aliases, option, definition)
  {
  }

  protected override string Label => "Category";

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

internal class ParseCategoryOption : OptionParser<CategoryOption>
{
  protected override string Label => "Category";
}

internal class ParseCategoryDefinition : IParser<CategoryOutput>
{
  public IResult<CategoryOutput> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    if (!tokens.Identifier(out var output)) {
      return tokens.Error<CategoryOutput>("Category", "output type");
    }

    var result = new CategoryOutput(output);
    return tokens.End("Category", () => result);
  }
}
