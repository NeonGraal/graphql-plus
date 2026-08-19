using GqlPlus.Ast.Operation;

namespace GqlPlus.Ast.Schema.Globals;

internal sealed record class OperationDeclAst(
  ITokenAt At,
  string Name,
  string Description
) : AstDeclaration(At, Name, Description)
  , IEquatable<OperationDeclAst>
  , IAstSchemaOperation
{
  internal override string Abbr => "SO";
  public override string Label => "Operation";

  public IAstTypeRef? Domain { get; init; }
  public IEnumerable<IAstDirective> Directives { get; init; } = [];
  public IEnumerable<IAstModifier> Modifiers { get; init; } = [];

  internal OperationBaseAst _operationBase = new();

  string IAstOperationBase.Category => _operationBase.Category;
  IEnumerable<IAstVariable> IAstOperationBase.Variables => _operationBase.Variables;
  IAstArg? IAstOperationBase.Argument => _operationBase.Argument;
  IEnumerable<IAstFragment> IAstOperationBase.Fragments => _operationBase.Fragments;
  IMap<IAstSelection[]> IAstOperationBase.Selections => _operationBase.Selections;

  internal OperationDeclAst(ITokenAt at, string name, Action<OperationBaseAst> config)
    : this(at, name, "")
    => config(_operationBase);

  public bool Equals(OperationDeclAst? other)
    => base.Equals(other)
    && _operationBase.Category.NullEqual(other._operationBase.Category)
    && ResultEqual(other);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), _operationBase.Category);

  private bool ResultEqual(OperationDeclAst other)
    => Directives.SequenceEqual(other.Directives)
    && Modifiers.SequenceEqual(other.Modifiers)
    && Domain is null ? _operationBase.Selections.SequenceEqual(other._operationBase.Selections)
      : Domain.NullEqual(other.Domain) && _operationBase.Argument.NullEqual(other._operationBase.Argument);

  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(_operationBase.Category)
      .Concat(_operationBase.Variables.Bracket())
      .Concat(Directives.AsString())
      .Concat(_operationBase.Fragments.Bracket()
      .ConcatNull(Domain,
        d => d.GetFields().Concat(_operationBase.Argument.Bracket("(", ")")),
        () => _operationBase.SelectionsFields())
      .Concat(Modifiers.AsString()));
}
