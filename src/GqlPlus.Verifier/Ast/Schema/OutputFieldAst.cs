namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class OutputFieldAst(ParseAt At, string Name, string Description, OutputReferenceAst Type)
  : AstAliased(At, Name, Description), IEquatable<OutputFieldAst>
{
  public ParameterAst? Parameter { get; set; }
  public ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();
  public string? Label { get; set; }

  internal override string Abbr => "OF";

  public OutputFieldAst(ParseAt at, string name, OutputReferenceAst fieldType)
    : this(at, name, "", fieldType) { }

  public bool Equals(OutputFieldAst? other)
    => base.Equals(other)
    && Parameter.NullEqual(other.Parameter)
    && Type.Equals(other.Type)
    && Modifiers.SequenceEqual(other.Modifiers)
    && Label.NullEqual(other.Label);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length, Label);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
        .Concat(Parameter.Bracket("(", ")"))
        .Concat(Label is not null
          ? new[] { "=", $"{Type.Name}.{Label}" }
          : Type.GetFields().Prepend(":"))
        .Concat(Modifiers.AsString());
}
