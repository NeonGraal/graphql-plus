using GqlPlus;
using GqlPlus.Abstractions.Operation;
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
  public IGqlpArg[] Usages { get; init; } = [];

  public string? ResultType { get; set; }
  public IGqlpArg? Arg { get; set; }
  public IGqlpSelection[]? ResultObject { get; set; }
  public IAstModifier[] Modifiers { get; set; } = [];

  public IAstFragment[] Fragments { get; set; } = [];
  public IGqlpSpread[] Spreads { get; set; } = [];

  internal override string Abbr => "g";

  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;
  IEnumerable<IAstVariable> IAstOperation.Variables => Variables;
  IGqlpArg? IAstOperation.Arg => Arg;
  IEnumerable<IGqlpSelection>? IAstOperation.ResultObject => ResultObject;
  IEnumerable<IAstFragment> IAstOperation.Fragments => Fragments;
  IMessages IAstOperation.Errors => Errors;

  IEnumerable<IGqlpArg> IAstOperation.Usages => Usages;
  IEnumerable<IGqlpSpread> IAstOperation.Spreads => Spreads;

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
