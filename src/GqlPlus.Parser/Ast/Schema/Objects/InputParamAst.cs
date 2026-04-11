using GqlPlus;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class InputParamAst(
  ITokenAt At,
  IAstObjBase Type
) : AstAbbreviated(At)
  , IAstInputParam
{
  public IAstModifier[] Modifiers { get; set; } = [];
  public IAstConstant? DefaultValue { get; set; }
  public IAstEnumValue? EnumValue { get; set; }

  string IAstObjEnum.EnumTypeName => Type?.Name ?? "";
  void IAstObjEnum.SetEnumType(string enumType)
  {
    string enumLabel = EnumValue?.EnumLabel ?? Type.Name;
    Type.SetName(enumType);
    EnumValue = new EnumValueAst(At, enumType, enumLabel);
  }

  internal override string Abbr => "Pa";
  public string ModifiedType => Type.GetFields().Skip(2).Concat(Modifiers.AsString()).Joined();

  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;
  string IAstDescribed.Description => Type.Description;

  internal InputParamAst(TokenAt at, string input, string description = "")
    : this(at, new ObjBaseAst(at, input, description)) { }

  public bool Equals(InputParamAst? other)
    => other is IAstInputParam inputParam && Equals(inputParam);
  [ExcludeFromCodeCoverage]
  public bool Equals(IAstDescribed? other)
    => other is IAstInputParam inputParam && Equals(inputParam);
  public bool Equals(IAstInputParam? other)
    => Equals(other as IAstAbbreviated)
    && (Type?.Equals(other.Type) ?? other.Type is null)
    && Modifiers.SequenceEqual(other.Modifiers)
    && EnumValue.NullEqual(other.EnumValue)
    && DefaultValue.NullEqual(other.DefaultValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type.NullHashCode(), Modifiers.Length, EnumValue.NullHashCode(), DefaultValue.NullHashCode());

  internal override IEnumerable<string?> GetFields()
    => string.IsNullOrWhiteSpace(EnumValue?.EnumLabel)
        ? new[] { "!" + Abbr }
          .Concat(Type.GetFields())
          .Concat(Modifiers.AsString())
          .Append(DefaultValue.Prefixed("="))
        : new[] { "!" + Abbr }
          .Concat(Type.GetFields())
          .Append(EnumValue?.EnumLabel.Prefixed("."));
}
