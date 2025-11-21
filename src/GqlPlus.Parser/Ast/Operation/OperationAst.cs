using GqlPlus;
using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class OperationAst(
  ITokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IGqlpOperation
{
  public ParseResultKind Result { get; set; }
  internal Messages Errors { get; set; } = [];

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
  IMessages IGqlpOperation.Errors => Errors;

  IEnumerable<IGqlpArg> IGqlpOperation.Usages => Usages;
  IEnumerable<IGqlpSpread> IGqlpOperation.Spreads => Spreads;

  public OperationAst(TokenAt at)
    : this(at, "") { }

  public bool Equals(OperationAst? other)
    => other is IGqlpOperation operation && Equals(operation);
  public bool Equals(IGqlpOperation other)
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
