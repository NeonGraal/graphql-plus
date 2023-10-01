namespace GqlPlus.Verifier.Ast;

internal record class FieldKeyAst
{
  internal string? Type { get; set; }

  internal string? Label { get; set; }

  internal decimal? Number { get; set; }

  internal string? String { get; set; }

  internal FieldKeyAst() { }
  internal FieldKeyAst(decimal number)
    => Number = number;
  internal FieldKeyAst(string content)
    => String = content;
  internal FieldKeyAst(string theType, string label)
    => (Type, Label) = (theType, label);
}
