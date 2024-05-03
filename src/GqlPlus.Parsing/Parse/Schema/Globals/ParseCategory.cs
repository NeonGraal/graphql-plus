using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Globals;

internal class ParseCategory(
  ICategoryName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<CategoryOption>, CategoryOption>.D option,
  Parser<CategoryOutput>.D definition
) : DeclarationParser<ICategoryName, NullAst, CategoryOption, CategoryOutput, CategoryDeclAst>(name, param, aliases, option, definition)
{
  protected override CategoryDeclAst MakeResult(CategoryDeclAst result, CategoryOutput value)
  {
    if (string.IsNullOrWhiteSpace(result.Name)) {
      result.Name = value.Output.Camelize();
    }

    result.Output = value.Output;
    result.Modifiers = value.Modifiers;
    return result;
  }

  protected override bool ApplyOption(CategoryDeclAst result, IResult<CategoryOption> option)
    => option.Optional(value => result.Option = value);

  protected override bool ApplyParameters(CategoryDeclAst result, IResultArray<NullAst> parameter) => true;

  [return: NotNull]
  protected override CategoryDeclAst MakePartial(TokenAt at, string? name, string description)
    => new(at, name ?? "", description, "");
}

internal record CategoryOutput(string Output)
{
  public ModifierAst[] Modifiers { get; set; } = [];
}

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

internal class ParseCategoryDefinition(
  Parser<ModifierAst>.DA modifiers
) : Parser<CategoryOutput>.I
{
  private readonly Parser<ModifierAst>.LA _modifiers = modifiers;

  public IResult<CategoryOutput> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (!tokens.Identifier(out string? output)) {
      return tokens.Error<CategoryOutput>(label, "output type");
    }

    CategoryOutput result = new(output);
    IResultArray<ModifierAst> modifiers = _modifiers.Parse(tokens, "Parameter");
    if (modifiers.IsError()) {
      return modifiers.AsResult(result);
    }

    modifiers.Optional(value => result.Modifiers = value);
    return tokens.End(label, () => result);
  }
}
