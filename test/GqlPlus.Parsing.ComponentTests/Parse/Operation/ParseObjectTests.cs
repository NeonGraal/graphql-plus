﻿using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Parse.Operation;

public class ParseObjectTests(Parser<IGqlpSelection>.DA parser)
{
  [Theory, RepeatData(Repeats)]
  public void WithJustField_ReturnsCorrectAst(string field)
    => _checks.TrueExpected("{" + field + "}",
    new FieldAst(AstNulls.At, field));

  [Theory, RepeatData(Repeats)]
  public void WithBadField_ReturnsCorrectAst(string field)
    => _checks.False("{" + field + "{}}");

  [Theory, RepeatData(Repeats)]
  public void WithJustInline_ReturnsCorrectAst(string inline)
    => _checks.TrueExpected("{|{" + inline + "}}",
      new InlineAst(AstNulls.At, new FieldAst(AstNulls.At, inline)));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithJustSpread_ReturnsCorrectAst(string spread)
    => _checks.TrueExpected("{|" + spread + "}",
      spread is null || spread.StartsWith("on", StringComparison.OrdinalIgnoreCase),
      new SpreadAst(AstNulls.At, spread ?? ""));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string field, string inline, string spread)
    => _checks.TrueExpected("{" + field + "|{" + inline + "}|" + spread + "}",
          spread is null || spread.StartsWith("on", StringComparison.OrdinalIgnoreCase),
          new FieldAst(AstNulls.At, field),
          new InlineAst(AstNulls.At, new FieldAst(AstNulls.At, inline)),
          new SpreadAst(AstNulls.At, spread ?? ""));

  [Fact]
  public void WithNoFields_ReturnsFalse()
    => _checks.False("{}");

  [Fact]
  public void WithNotField_ReturnsFalse()
    => _checks.False("{9");

  [Fact]
  public void WithBadSelection_ReturnsFalse()
    => _checks.False("{|}");

  private readonly ManyChecksParser<IGqlpSelection> _checks = new(parser);
}
