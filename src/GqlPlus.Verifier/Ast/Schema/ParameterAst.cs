namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class ParameterAst(ParseAt At, InputReferenceAst Input)
  : AstBase(At), IEquatable<ParameterAst>
{
  public ModifierAst[] Modifers { get; set; } = Array.Empty<ModifierAst>();
  public ConstantAst? Default { get; set; }

  internal override string Abbr => "P";

  internal ParameterAst(ParseAt at, string input)
    : this(at, new InputReferenceAst(at, input)) { }

  public bool Equals(ParameterAst? other)
    => base.Equals(other)
    && Input.NullEqual(other.Input)
    && Modifers.SequenceEqual(other.Modifers)
    && Default.NullEqual(other.Default);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Input, Modifers.Length, Default);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Input.GetFields())
      .Concat(Modifers.AsString())
      .Append(Default is null ? "" : "=" + Default.ToString());
}
