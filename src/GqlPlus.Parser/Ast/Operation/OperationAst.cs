using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class OperationAst(
  TokenAt At,
  string Name
) : AstDirectives(At, Name)
  , IEquatable<OperationAst>
  , IGqlpOperation
{
  public ParseResultKind Result { get; set; }
  internal TokenMessages Errors { get; set; } = [];

  public string Category { get; set; } = "query";

  public IGqlpVariable[] Variables { get; set; } = [];
  public ArgumentAst[] Usages { get; init; } = [];

  public string? ResultType { get; set; }
  public ArgumentAst? Argument { get; set; }
  public IGqlpSelection[]? ResultObject { get; set; }
  public ModifierAst[] Modifiers { get; set; } = [];

  public IGqlpFragment[] Fragments { get; set; } = [];
  public SpreadAst[] Spreads { get; set; } = [];

  internal override string Abbr => "g";

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;
  IEnumerable<IGqlpVariable> IGqlpOperation.Variables => Variables;
  IGqlpArgument? IGqlpOperation.Argument => Argument;
  IEnumerable<IGqlpSelection>? IGqlpOperation.ResultObject => ResultObject;
  IEnumerable<IGqlpFragment> IGqlpOperation.Fragments => Fragments;
  ITokenMessages IGqlpOperation.Errors => Errors;

  IEnumerable<IGqlpArgument> IGqlpOperation.Usages => Usages;
  IEnumerable<IGqlpSpread> IGqlpOperation.Spreads => Spreads;

  public OperationAst(TokenAt at)
    : this(at, "") { }

  public string Show()
  {
    using StringWriter sw = new();
    int indent = 0;
    string[] begins = ["(", "{", "[", "<"];
    string[] ends = [")", "}", "]", ">"];
    foreach (string? field in GetFields()) {
      if (string.IsNullOrWhiteSpace(field)) {
        continue;
      }

      if (begins.Contains(field)) {
        Write(field);
        indent++;
      } else if (ends.Contains(field)) {
        indent--;
        Write(field);
      } else {
        Write(field);
      }
    }

    return sw.ToString();

    void Write(string text)
    {
      for (int i = 0; i < indent; i++) {
        sw.Write("  ");
      }

      sw.WriteLine(text);
    }
  }

  public bool Equals(OperationAst? other)
    => base.Equals(other)
    && Result == other.Result;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Result);

  internal override IEnumerable<string?> GetFields()
    => // base.GetFields()
      new[] { AbbrAt, Category, Name, $"{Result}" }
      .Concat(Errors.Bracket("<", ">", true))
      .Concat(Variables.Bracket("[", "]"))
      .Concat(Directives.AsString())
      .Append(ResultType)
      .Concat(Argument.Bracket("(", ")"))
      .Concat(ResultObject.Bracket("{", "}"))
      .Append(Modifiers.AsString().Joined(""))
      .Concat(Fragments.Bracket());
}
