using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class OperationAst(
  ITokenAt At,
  string Identifier
) : AstModifiers(At, Identifier)
  , IAstOperation
{
  public ParseResultKind Result { get; set; }
  internal IMessages Errors { get; set; } = Messages.New;
  public string? Domain { get; set; }

  public IAstSpread[] Spreads { get; set; } = [];
  public IAstArg[] Usages { get; init; } = [];

  internal OperationBaseAst _operationBase = new();

  internal override string Abbr => "g";

  string IAstOperationBase.Category => _operationBase.Category;
  IEnumerable<IAstVariable> IAstOperationBase.Variables => _operationBase.Variables;
  IAstArg? IAstOperationBase.Argument => _operationBase.Argument;
  IEnumerable<IAstFragment> IAstOperationBase.Fragments => _operationBase.Fragments;
  IMap<IAstSelection[]> IAstOperationBase.Selections => _operationBase.Selections;

  IMessages IAstOperation.Errors => Errors;

  IEnumerable<IAstArg> IAstOperation.Usages => Usages;
  IEnumerable<IAstSpread> IAstOperation.Spreads => Spreads;

  public OperationAst(TokenAt at)
    : this(at, "") { }

  public bool Equals(OperationAst? other)
    => other is IAstOperation operation && Equals(operation);
  public bool Equals(IAstOperation other)
    => base.Equals(other)
    && Result == other.Result
    && Domain.NullEqual(other?.Domain);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Result);

  internal override IEnumerable<string?> GetFields()
    => new[] { AbbrAt, _operationBase.Category, Identifier, $"{Result}" }
      .Concat(Errors.Bracket("<", ">", true))
      .Concat(_operationBase.Variables.Bracket("[", "]"))
      .Concat(Directives.AsString())
      .Concat(_operationBase.Fragments.Bracket()
      .ConcatIf(Domain.IsWhiteSpace(),
        () => _operationBase.SelectionsFields(),
        () => _operationBase.Argument.Bracket("(", ")").Prepend(Domain))
      .Concat(Modifiers.AsString()));
}
