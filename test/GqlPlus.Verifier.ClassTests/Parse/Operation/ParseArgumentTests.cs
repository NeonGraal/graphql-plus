﻿using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseArgumentTests
{
  [Theory, RepeatData(Repeats)]
  public void WithVariable_ReturnsCorrectAst(string variable)
    => _test.TrueExpected(
      "($" + variable + ")",
      new ArgumentAst(AstNulls.At, variable));

  [Theory, RepeatData(Repeats)]
  public void WithConstant_ReturnsCorrectAst(string label)
    => _test.TrueExpected(
      "(" + label + ")",
      new ArgumentAst(label.FieldKey()));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string label)
    => _test.TrueExpected(
      "($" + label + ' ' + label + ')',
      new ArgumentAst(AstNulls.At, label.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string label)
    => _test.TrueExpected(
      "($" + label + ',' + label + ')',
      new ArgumentAst(AstNulls.At, label.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string label)
    => _test.False(
      "($" + label + '|' + label + ')',
      CheckNull);

  [Theory, RepeatData(Repeats)]
  public void WithField_ReturnsTrue(string label)
    => _test.TrueExpected(
      '(' + label + ":$" + label + ')',
      new ArgumentAst(AstNulls.At, label.ArgumentObject(label)));

  [Theory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string label)
    => _test.TrueExpected(
      '(' + key + ":$" + label + ' ' + label + ':' + key + ')',
      new ArgumentAst(AstNulls.At, label.ArgumentObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string label)
    => _test.TrueExpected(
      '(' + key + ":$" + label + ',' + label + ':' + key + ')',
      new ArgumentAst(AstNulls.At, label.ArgumentObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectSemiLabel_ReturnsFalse(string key, string label)
    => _test.False(
      '(' + key + ":$" + label + ',' + label + ')',
      CheckNull,
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectFieldBad_ReturnsFalse(string key, string label)
    => _test.False(
      '(' + key + ":)",
      CheckNull,
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string label)
    => _test.False(
      '(' + key + ':' + label + ';' + label + ':' + key + ')',
      CheckNull,
      key == label);

  private void CheckNull(ArgumentAst? result)
    => result.Should().BeNull();

  private readonly OneChecksParser<IParserArgument, ArgumentAst> _test;

  public ParseArgumentTests(Parser<IParserArgument, ArgumentAst>.D parser)
    => _test = new(parser);
}
