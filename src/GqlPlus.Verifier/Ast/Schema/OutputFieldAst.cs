using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class OutputFieldAst(TokenAt At, string Name, string Description, OutputReferenceAst Type)
  : AstField<OutputReferenceAst>(At, Name, Description, Type), IEquatable<OutputFieldAst>
{
  public ParameterAst[] Parameters { get; set; } = Array.Empty<ParameterAst>();
  public string? EnumValue { get; set; }

  internal override string Abbr => "OF";

  public OutputFieldAst(TokenAt at, string name, OutputReferenceAst fieldType)
    : this(at, name, "", fieldType) { }

  public bool Equals(OutputFieldAst? other)
    => base.Equals(other)
    && Parameters.SequenceEqual(other.Parameters)
    && EnumValue.NullEqual(other.EnumValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), EnumValue);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
        .Concat(Parameters.Bracket("(", ")"))
        .Concat(EnumValue is not null
          ? new[] { "=", $"{Type.Name}.{EnumValue}" }
          : Type.GetFields().Prepend(":"))
        .Concat(Modifiers.AsString());
}
