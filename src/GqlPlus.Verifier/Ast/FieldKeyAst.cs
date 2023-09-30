namespace GqlPlus.Verifier.Ast;

internal record class FieldKeyAst
{
  internal string? Type { get; set; }

  internal string? Label { get; set; }

  internal decimal? Number { get; set; }

  internal string? String { get; set; }
}
