using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class CategoryDeclAst(
  TokenAt At,
  string Name,
  string Description,
  string Output
) : AstDeclaration(At, Name, Description), IEquatable<CategoryDeclAst>
{
  public ModifierAst[] Modifiers { get; set; } = [];

  internal override string Abbr => "C";

  public string Output { get; set; } = Output;

  public CategoryOption Option { get; set; } = CategoryOption.Parallel;

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

[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
public enum CategoryOption
{
  Parallel,
  Single,
  Sequential
}
