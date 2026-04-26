using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class OperationAst(
  ITokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IAstOperation
{
  public ParseResultKind Result { get; set; }
  internal IMessages Errors { get; set; } = Messages.New;

  public string Category { get; set; } = "query";

  public IAstVariable[] Variables { get; set; } = [];
  public IAstArg[] Usages { get; init; } = [];

  public string? ResultType { get; set; }
  public IAstArg? Arg { get; set; }
  public IAstSelection[]? ResultObject { get; set; }
  public IAstModifier[] Modifiers { get; set; } = [];

  public IAstFragment[] Fragments { get; set; } = [];
  public IAstSpread[] Spreads { get; set; } = [];

  internal override string Abbr => "g";

  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;
  IEnumerable<IAstVariable> IAstOperation.Variables => Variables;
  IAstArg? IAstOperation.Arg => Arg;
  IEnumerable<IAstSelection>? IAstOperation.ResultObject => ResultObject;
  IEnumerable<IAstFragment> IAstOperation.Fragments => Fragments;
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
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Result, Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => // base.GetFields()
      new[] { AbbrAt, Category, Identifier, $"{Result}" }
      .Concat(Errors.Bracket("<", ">", true))
      .Concat(Variables.Bracket("[", "]"))
      .Concat(Directives.AsString())
      .Append(ResultType)
      .Concat(Arg.Bracket("(", ")"))
      .Concat(ResultObject.Bracket("{", "}"))
      .Concat(Modifiers.AsString())
      .Concat(Fragments.Bracket());
}
