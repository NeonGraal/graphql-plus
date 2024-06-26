using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Globals;

internal sealed record class CategoryDeclAst(
  TokenAt At,
  string Name,
  string Description,
  string Output
) : AstDeclaration(At, Name, Description)
  , IEquatable<CategoryDeclAst>
  , IGqlpSchemaCategory
{
  public IGqlpModifier[] Modifiers { get; set; } = [];

  internal override string Abbr => "Ca";
  public override string Label => "Category";

  public string Output { get; set; } = Output;

  public CategoryOption Option { get; set; } = CategoryOption.Parallel;

  CategoryOption IGqlpSchemaCategory.CategoryOption => Option;
  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  public CategoryDeclAst(TokenAt at, string output)
    : this(at, output.Camelize()!, "", output) { }

  public CategoryDeclAst(TokenAt at, string name, string output)
    : this(at, name, "", output) { }

  public bool Equals(CategoryDeclAst? other)
    => base.Equals(other)
    && Option == other.Option
    && Output == other.Output
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Option, Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append($"({Option})")
      .Append(Output)
      .Concat(Modifiers.AsString());
}
