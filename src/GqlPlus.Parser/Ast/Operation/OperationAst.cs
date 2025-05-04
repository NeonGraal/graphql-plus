using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class OperationAst(
  ITokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IEquatable<OperationAst>
  , IGqlpOperation
{
  public ParseResultKind Result { get; set; }
  internal TokenMessages Errors { get; set; } = [];

  public string Category { get; set; } = "query";

  public IGqlpVariable[] Variables { get; set; } = [];
  public IGqlpArg[] Usages { get; init; } = [];

  public string? ResultType { get; set; }
  public IGqlpArg? Arg { get; set; }
  public IGqlpSelection[]? ResultObject { get; set; }
  public IGqlpModifier[] Modifiers { get; set; } = [];

  public IGqlpFragment[] Fragments { get; set; } = [];
  public IGqlpSpread[] Spreads { get; set; } = [];

  internal override string Abbr => "g";

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;
  IEnumerable<IGqlpVariable> IGqlpOperation.Variables => Variables;
  IGqlpArg? IGqlpOperation.Arg => Arg;
  IEnumerable<IGqlpSelection>? IGqlpOperation.ResultObject => ResultObject;
  IEnumerable<IGqlpFragment> IGqlpOperation.Fragments => Fragments;
  ITokenMessages IGqlpOperation.Errors => Errors;

  IEnumerable<IGqlpArg> IGqlpOperation.Usages => Usages;
  IEnumerable<IGqlpSpread> IGqlpOperation.Spreads => Spreads;

  public OperationAst(TokenAt at)
    : this(at, "") { }

  public bool Equals(OperationAst? other)
    => base.Equals(other)
    && Result == other.Result;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Result);

  internal override IEnumerable<string?> GetFields()
    => // base.GetFields()
      new[] { AbbrAt, Category, Identifier, $"{Result}" }
      .Concat(Errors.Bracket("<", ">", true))
      .Concat(Variables.Bracket("[", "]"))
      .Concat(Directives.AsString())
      .Append(ResultType)
      .Concat(Arg.Bracket("(", ")"))
      .Concat(ResultObject.Bracket("{", "}"))
      .Append(Modifiers.AsString().Joined(""))
      .Concat(Fragments.Bracket());
}
