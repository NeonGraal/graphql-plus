using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputParamAst(
  ITokenAt At,
  IGqlpObjBase Type
) : AstAbbreviated(At)
  , IGqlpInputParam
{
  public IGqlpModifier[] Modifiers { get; set; } = [];
  public IGqlpConstant? DefaultValue { get; set; }

  internal override string Abbr => "Pa";
  public string ModifiedType => Type.GetFields().Skip(2).Concat(Modifiers.AsString()).Joined();

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;
  string IGqlpDescribed.Description => Type.Description;

  internal InputParamAst(TokenAt at, string input, string description = "")
    : this(at, new ObjBaseAst(at, input, description)) { }

  public bool Equals(InputParamAst? other)
    => other is IGqlpInputParam inputParam && Equals(inputParam);
  public bool Equals(IGqlpDescribed? other)
    => other is IGqlpInputParam inputParam && Equals(inputParam);
  public bool Equals(IGqlpInputParam? other)
    => Equals(other as IGqlpAbbreviated)
    && (Type?.Equals(other.Type) ?? other.Type is null)
    && Modifiers.SequenceEqual(other.Modifiers)
    && DefaultValue.NullEqual(other.DefaultValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length, DefaultValue);

  internal override IEnumerable<string?> GetFields()
    => new[] { "!" + Abbr }
      .Concat(Type.GetFields())
      .Concat(Modifiers.AsString())
      .Append(DefaultValue.Prefixed("="));
}
