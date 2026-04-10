using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Globals;

internal sealed record class CategoryDeclAst(
  ITokenAt At,
  string Name,
  string Description,
  IAstTypeRef Output
) : AstDeclaration(At, Name, Description)
  , IAstSchemaCategory
{
  public IAstModifier[] Modifiers { get; set; } = [];

  internal override string Abbr => "Ca";
  public override string Label => "Category";

  public IAstTypeRef Output { get; set; } = Output;

  public CategoryOption Option { get; set; } = CategoryOption.Parallel;

  CategoryOption IAstSchemaCategory.CategoryOption => Option;
  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;

  public CategoryDeclAst(TokenAt at, IAstTypeRef output)
    : this(at, output.Name.Camelize(), "", output) { }

  public CategoryDeclAst(TokenAt at, string name, IAstTypeRef output)
    : this(at, name, "", output) { }

  public bool Equals(CategoryDeclAst? other)
    => other is IAstSchemaCategory category && Equals(category);
  public bool Equals(IAstSchemaCategory? other)
    => base.Equals(other)
    && Option == other.CategoryOption
    && Output.Equals(other.Output)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Option, Output.NullHashCode(), Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append($"({Option})")
      .Concat(Output.GetFields())
      .Concat(Modifiers.AsString());
}
