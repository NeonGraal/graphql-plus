﻿using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseArgValueTests
{
  [Theory, RepeatData(Repeats)]
  public void WithVariable_ReturnsCorrectAst(string variable)
    => Test.TrueExpected(
      "$" + variable,
      new ArgumentAst(variable));

  [Theory, RepeatData(Repeats)]
  public void WithConstant_ReturnsCorrectAst(string label)
    => Test.TrueExpected(
      label,
      new ArgumentAst(new FieldKeyAst("", label)));

  [Theory, RepeatData(Repeats)]
  public void WithList_ReturnsCorrectAst(string label)
    => Test.TrueExpected(
      "[$" + label + ' ' + label + ']',
      new ArgumentAst(label.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListComma_ReturnsCorrectAst(string label)
    => Test.TrueExpected(
      "[$" + label + ',' + label + ']',
      new ArgumentAst(label.ArgumentList()));

  [Theory, RepeatData(Repeats)]
  public void WithListInvalid_ReturnsFalse(string label)
    => Test.False(
      '[' + label + ':' + label + ']',
      CheckDefault);

  [Theory, RepeatData(Repeats)]
  public void WithObject_ReturnsCorrectAst(string key, string label)
    => Test.TrueExpected(
      '{' + key + ":$" + label + ' ' + label + ':' + key + '}',
      new ArgumentAst(label.ArgumentObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectSemi_ReturnsCorrectAst(string key, string label)
    => Test.TrueExpected(
      '{' + key + ":$" + label + ';' + label + ':' + key + '}',
      new ArgumentAst(label.ArgumentObject(key)),
      key == label);

  [Theory, RepeatData(Repeats)]
  public void WithObjectInvalid_ReturnsFalse(string key, string label)
    => Test.False(
      '{' + key + ':' + label + ':' + label + ':' + key + '}',
      CheckDefault,
      key == label);

  private void CheckDefault(ArgumentAst result)
    => result.Should().Be(new ArgumentAst());

  private static BaseOneChecks<ArgumentAst> Test => new((ref OperationParser parser, out ArgumentAst result)
    => parser.ParseArgValue(out result));
}
