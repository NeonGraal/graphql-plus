using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class InlineAst(
  TokenAt At,
  params IGqlpSelection[] Selections
) : AstAbbreviated(At)
  , IGqlpInline
{
  public string? OnType { get; set; }

  public IGqlpDirective[] Directives { get; set; } = [];

  internal override string Abbr => "i";

  IEnumerable<IGqlpDirective> IGqlpDirectives.Directives
  {
    get => Directives;
    init => Directives = [.. value];
  }
  IEnumerable<IGqlpSelection> IGqlpInline.Selections => Selections;

  public bool Equals(InlineAst? other)
    => other is IGqlpInline inline && Equals(inline);
  public bool Equals(IGqlpDirectives? other)
    => other is IGqlpInline inline ? Equals(inline)
      : base.Equals(other)
        && Directives.SequenceEqual(other.Directives);
  public bool Equals(IGqlpInline? other)
    => base.Equals(other)
    && Directives.SequenceEqual(other.Directives)
    && OnType.NullEqual(other.OnType)
    && Selections.SequenceEqual(other.Selections);
  public override int GetHashCode()
    => HashCode.Combine(OnType, Selections?.Length, Directives.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(OnType.Prefixed(":"))
      .Concat(Directives.AsString())
      .Concat(Selections.Bracket("{", "}"));
}
