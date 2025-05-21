using GqlPlus.Abstractions.Operation;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Globals;

internal sealed record class OperationDeclAst(
  ITokenAt At,
  string Name,
  string Description,
  string Category
) : AstDeclaration(At, Name, Description)
  , IGqlpSchemaOperation
{
  internal override string Abbr => "SO";
  public override string Label => "Operation";

  public string Category { get; } = Category;
  public IEnumerable<IGqlpVariable> Variables { get; } = [];
  public IGqlpArg? Arg { get; }
  public IEnumerable<IGqlpSelection>? ResultObject { get; } = [];
  public IEnumerable<IGqlpFragment> Fragments { get; } = [];
  public IEnumerable<IGqlpDirective> Directives { get; init; } = [];
  public IEnumerable<IGqlpModifier> Modifiers { get; } = [];

  public OperationDeclAst(TokenAt at, string name, string category)
    : this(at, name, "", category) { }

  public bool Equals(OperationDeclAst? other)
    => other is IGqlpSchemaOperation schema && Equals(schema);
  public bool Equals(IGqlpDirectives? other)
    => other is IGqlpSchemaOperation schema && Equals(schema);
  public bool Equals(IGqlpSchemaOperation? other)
    => base.Equals(other)
    && Category == other.Category;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Category);

  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Category);
}
