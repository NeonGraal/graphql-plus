namespace GqlPlus.Verifier.Ast;

internal abstract record class AstBase
{
  protected abstract string Abbr { get; }

  public ParseAt At { get; }

  internal AstBase(ParseAt loc)
    => At = loc;

  public sealed override string ToString()
    => Abbr + "("
      + string.Join(" ", GetFields().Where(s => s?.Length > 0))
      + ")";

  internal virtual IEnumerable<string?> GetFields()
    => Array.Empty<string?>();

  internal ParseError Error(string message)
    => new(At, message);
}

