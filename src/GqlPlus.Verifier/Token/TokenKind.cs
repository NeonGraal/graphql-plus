using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifier.Token;

[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
public enum TokenKind
{
  Start,
  Identifer,
  Number,
  String,
  Regex,
  Punctuation,
  End
}
