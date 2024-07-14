using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Globals;

internal class ParseCategory(
  ICategoryName name,
  Parser<NullAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<CategoryOption>, CategoryOption>.D option,
  Parser<CategoryOutput>.D definition
) : DeclarationParser<ICategoryName, NullAst, CategoryOption, CategoryOutput, IGqlpSchemaCategory>(name, param, aliases, option, definition)
{
  protected override IGqlpSchemaCategory MakeResult(AstPartial<NullAst, CategoryOption> partial, CategoryOutput value)
  {
    string name = string.IsNullOrWhiteSpace(partial.Name)
      ? value.Output.Camelize() : partial.Name;

    return new CategoryDeclAst(partial.At, name, partial.Description) {
      Aliases = partial.Aliases,
      Option = partial.Option ?? CategoryOption.Parallel,
      Output = value.Output,
      Modifiers = value.Modifiers,
    };
  }

  protected override IGqlpSchemaCategory ToResult(AstPartial<NullAst, CategoryOption> partial)
    => new CategoryDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      Option = partial.Option ?? CategoryOption.Parallel,
    };
}

internal record CategoryOutput(string Output)
{
  public ModifierAst[] Modifiers { get; set; } = [];
}

internal class CategoryName
  : ICategoryName
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
  Parser<IGqlpModifier>.DA modifiers
) : Parser<CategoryOutput>.I
{
  private readonly Parser<IGqlpModifier>.LA _modifiers = modifiers;

  public IResult<CategoryOutput> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (!tokens.Identifier(out string? output)) {
      return tokens.Error<CategoryOutput>(label, "output type");
    }

    CategoryOutput result = new(output);
    IResultArray<IGqlpModifier> modifiers = _modifiers.Parse(tokens, "Param");
    if (modifiers.IsError()) {
      return modifiers.AsResult(result);
    }

    modifiers.Optional(value => result.Modifiers = value.ArrayOf<ModifierAst>());
    return tokens.End(label, () => result);
  }
}
