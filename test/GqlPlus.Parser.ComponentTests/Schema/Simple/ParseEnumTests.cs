﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parsing;

namespace GqlPlus.Schema.Simple;

public sealed class ParseEnumTests(
  IBaseSimpleChecks<EnumInput, IGqlpEnum> checks
) : BaseSimpleTests<EnumInput, IGqlpEnum>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithEnumLabels_ReturnsCorrectAst(string name, string[] labels)
    => checks.TrueExpected(
      name + labels.Bracket("{", "}").Joined(),
      new EnumDeclAst(AstNulls.At, name, []) {
        Items = labels.EnumLabels(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabelsBad_ReturnsFalse(string name, string[] labels)
    => checks
    .SkipNull(labels)
    .SkipIf(labels.Length < 2)
    .FalseExpected(name + "{" + string.Join("|", labels) + "}");

  [Theory, RepeatData(Repeats)]
  public void WithEnumLabelsNone_ReturnsFalse(string name)
    => checks.FalseExpected(name + "{}");

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string name, string parent, string[] labels)
    => checks.TrueExpected(
      name + labels.Prepend(parent.Prefixed(":")).Bracket("{", "}").Joined(),
      new EnumDeclAst(AstNulls.At, name, labels.EnumLabels()) { Parent = parent });
}

internal sealed class ParseEnumChecks(
  Parser<IGqlpEnum>.D parser
) : BaseSimpleChecks<EnumInput, EnumDeclAst, IGqlpEnum>(parser)
{
  protected internal override EnumDeclAst NamedFactory(EnumInput input)
    => new(AstNulls.At, input.Type, new[] { input.Label }.EnumLabels());

  protected override string ParentString(EnumInput input, string aliases, string? parent)
    => input.Type + aliases + "{" +
    (string.IsNullOrWhiteSpace(parent) ? "" : $":{parent} ") +
    input.Label + "}";
}

public record struct EnumInput(string Type, string Label);
