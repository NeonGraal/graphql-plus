namespace GqlPlus.Verifier.Ast;

internal sealed record class ArgumentAst : IEquatable<ArgumentAst>
{
  internal string? Variable { get; set; }

  internal ConstantAst? Constant { get; set; }

  internal ArgumentAst[] Values { get; set; } = Array.Empty<ArgumentAst>();

  internal IDictionary<FieldKeyAst, ArgumentAst> Fields { get; set; } = new Dictionary<FieldKeyAst, ArgumentAst>();

  public bool Equals(ArgumentAst? other)
    => other is not null
    && Variable.NullEqual(other.Variable)
    && Constant.NullEqual(other.Constant)
    && Values.SequenceEqual(other.Values)
    && Fields.Ordered().SequenceEqual(other.Fields.Ordered());

  public override int GetHashCode()
    => HashCode.Combine(Variable, Constant, Values, Fields);
}
