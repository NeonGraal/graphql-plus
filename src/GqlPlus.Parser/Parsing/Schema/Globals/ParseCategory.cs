using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Globals;

internal class ParseCategory(
  IParserRepository parsers
) : DeclarationParser<ICategoryName, NullAst, CategoryOption, CategoryOutput, IAstSchemaCategory>(parsers)
{
  protected override IAstSchemaCategory MakeResult(AstPartial<NullAst, CategoryOption> partial, CategoryOutput value)
  {
    string name = string.IsNullOrWhiteSpace(partial.Name)
      ? value.Output.Name.Camelize() : partial.Name;

    return new CategoryDeclAst(partial.At, name, partial.Description, value.Output) {
      Aliases = partial.Aliases,
      Option = partial.Option ?? CategoryOption.Parallel,
      Modifiers = value.Modifiers,
    };
  }

  protected override IAstSchemaCategory ToResult(AstPartial<NullAst, CategoryOption> partial)
    => new CategoryDeclAst(partial.At, partial.Name, partial.Description, new TypeRefAst(partial.At, partial.Name, "")) {
      Aliases = partial.Aliases,
      Option = partial.Option ?? CategoryOption.Parallel,
    };

  internal static ParseCategory Factory(IParserRepository p) => new(p);
}

internal record CategoryOutput(IAstTypeRef Output)
{
  public IAstModifier[] Modifiers { get; set; } = [];
}

internal class CategoryName
  : ICategoryName
{
  public bool ParseName(ITokenizer tokens, [NotNullWhen(true)] out string? name, out TokenAt at)
  {
    at = tokens.At;
    if (!tokens.Identifier(out name)) {
      name = "";
    }

    return true;
  }

  internal static CategoryName Factory(IParserRepository _) => new();
}

internal interface ICategoryName : INameParser;

internal class ParseCategoryDefinition(
  IParserRepository parsers
) : Parser<CategoryOutput>.I
{
  private readonly Parser<IAstTypeRef>.L _typeRef = parsers.ParserFor<IAstTypeRef>();
  private readonly Parser<IAstModifier>.LA _modifiers = parsers.ArrayFor<IAstModifier>();

  public IResult<CategoryOutput> Parse(ITokenizer tokens, string label)
  {
    IResult<IAstTypeRef> output = _typeRef.Parse(tokens, "Category Output");
    if (output.IsError()) {
      return tokens.Error<CategoryOutput>(label, "output type");
    }

    CategoryOutput result = new(output.Required());
    IResultArray<IAstModifier> modifiers = _modifiers.Parse(tokens, "Param");
    if (modifiers.IsError()) {
      return modifiers.AsPartial(result);
    }

    modifiers.Optional(value => result.Modifiers = [.. value]);
    return tokens.End(label, () => result);
  }

  internal static ParseCategoryDefinition Factory(IParserRepository p) => new(p);
}
