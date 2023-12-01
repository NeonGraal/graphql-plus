namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class OutputFieldAst(ParseAt At, string Name, string Description, OutputReferenceAst Type)
  : AstField<OutputReferenceAst>(At, Name, Description, Type), IEquatable<OutputFieldAst>
{
  public ParameterAst[] Parameters { get; set; } = Array.Empty<ParameterAst>();
  public string? Label { get; set; }

  internal override string Abbr => "OF";

  public OutputFieldAst(ParseAt at, string name, OutputReferenceAst fieldType)
    : this(at, name, "", fieldType) { }

  public bool Equals(OutputFieldAst? other)
    => base.Equals(other)
    && Parameters.SequenceEqual(other.Parameters)
    && Label.NullEqual(other.Label);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Label);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
        .Concat(Parameters.Bracket("(", ")"))
        .Concat(Label is not null
          ? new[] { "=", $"{Type.Name}.{Label}" }
          : Type.GetFields().Prepend(":"))
        .Concat(Modifiers.AsString());
}
