using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class OutputFieldAst(TokenAt At, string Name, string Description, OutputReferenceAst Type)
  : AstField<OutputReferenceAst>(At, Name, Description, Type), IEquatable<OutputFieldAst>
{
  public ParameterAst[] Parameters { get; set; } = [];

  internal override string Abbr => "OF";

  public OutputFieldAst(TokenAt at, string name, OutputReferenceAst fieldType)
    : this(at, name, "", fieldType) { }

  public bool Equals(OutputFieldAst? other)
    => base.Equals(other)
    && Parameters.SequenceEqual(other.Parameters);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Parameters.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
        .Concat(Parameters.Bracket("(", ")"))
        .Concat(Type.GetFields().Prepend(string.IsNullOrWhiteSpace(Type.EnumValue) ? ":" : "="))
        .Concat(Modifiers.AsString());
}
