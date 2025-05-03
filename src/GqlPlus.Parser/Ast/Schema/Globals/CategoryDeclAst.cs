using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Globals;

internal sealed record class CategoryDeclAst(
  ITokenAt At,
  string Name,
  string Description,
  TypeRefAst Output
) : AstDeclaration(At, Name, Description)
  , IEquatable<CategoryDeclAst>
  , IGqlpSchemaCategory
{
  public IGqlpModifier[] Modifiers { get; set; } = [];

  internal override string Abbr => "Ca";
  public override string Label => "Category";

  public TypeRefAst Output { get; set; } = Output;

  public CategoryOption Option { get; set; } = CategoryOption.Parallel;

  CategoryOption IGqlpSchemaCategory.CategoryOption => Option;
  IGqlpTypeRef IGqlpSchemaCategory.Output => Output;
  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  public CategoryDeclAst(TokenAt at, TypeRefAst output)
    : this(at, output.Name.Camelize()!, "", output) { }

  public CategoryDeclAst(TokenAt at, string name, TypeRefAst output)
    : this(at, name, "", output) { }

  public bool Equals(CategoryDeclAst? other)
    => base.Equals(other)
    && Option == other.Option
    && Output == other.Output
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Option, Output, Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append($"({Option})")
      .Concat(Output.GetFields())
      .Concat(Modifiers.AsString());
}
