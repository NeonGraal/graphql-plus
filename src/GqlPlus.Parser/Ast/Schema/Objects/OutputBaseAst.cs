using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class OutputBaseAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjectBase<OutputBaseAst>(At, Name, Description)
  , IEquatable<OutputBaseAst>
  , IGqlpOutputBase
{
  public OutputBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  public string? EnumMember { get; set; }

  internal override string Abbr => "OR";
  public override string Label => "Output";

  string IGqlpOutputBase.Output => Name;
  IEnumerable<IGqlpOutputBase> IGqlpObjectBase<IGqlpOutputBase>.TypeArguments => TypeArguments;
  IGqlpDualBase IGqlpToDual.ToDual => ToDual();

  public override bool Equals(OutputBaseAst? other)
    => base.Equals(other)
    && EnumMember.NullEqual(other.EnumMember);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), EnumMember);

  internal override IEnumerable<string?> GetFields()
    => new[] {
      At.ToString(),
      string.IsNullOrWhiteSpace(EnumMember)
        ? IsTypeParameter ? Name.Prefixed("$") : Name
        : $"{Name}.{EnumMember}"
    }.Concat(TypeArguments.Bracket("<", ">"));

  public DualBaseAst ToDual()
    => new(At, Name, Description) {
      IsTypeParameter = IsTypeParameter,
      TypeArguments = [.. TypeArguments.Select(a => a.ToDual())],
    };
  bool IEquatable<IGqlpOutputBase>.Equals(IGqlpOutputBase? other)
    => Equals(other);

  void IGqlpOutputBase.SetEnumType(string enumType)
  {
    EnumMember ??= Name;
    Name = enumType;
  }
}
