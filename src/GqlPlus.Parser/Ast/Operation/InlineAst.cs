using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class InlineAst(
  ITokenAt At,
  params IGqlpSelection[] Selections
) : AstAbbreviated(At)
  , IEquatable<InlineAst>
  , IGqlpInline
{
  public string? OnType { get; set; }

  public IGqlpDirective[] Directives { get; set; } = [];

  internal override string Abbr => "i";

  IEnumerable<IGqlpDirective> IGqlpDirectives.Directives
  {
    get => Directives;
    init => Directives = [.. value.Cast<DirectiveAst>()];
  }
  IEnumerable<IGqlpSelection> IGqlpInline.Selections => Selections;

  public bool Equals(InlineAst? other)
    => base.Equals(other)
    && OnType.NullEqual(other.OnType)
    && Selections.SequenceEqual(other.Selections)
    && Directives.SequenceEqual(other.Directives);
  public override int GetHashCode()
    => HashCode.Combine(OnType, Selections?.Length, Directives.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(OnType.Prefixed(":"))
      .Concat(Directives.AsString())
      .Concat(Selections.Bracket("{", "}"));
}
