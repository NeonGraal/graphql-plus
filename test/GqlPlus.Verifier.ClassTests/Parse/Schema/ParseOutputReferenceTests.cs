﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputReferenceTests : BaseReferenceTests
{
  [Theory, RepeatData(Repeats)]
  public void WithArgumentEnumLabels_ReturnsCorrectAst(string name, string enumType, string[] labels)
    => Test.TrueExpected(
      name + "<" + labels.Joined(enumType + ".") + ">",
      Test.Reference(name) with {
        Arguments = labels.Select(
          label => Test.Reference(enumType) with { Label = label })
          .ToArray()
      });

  internal override IBaseReferenceChecks Checks => Test;

  private static BaseReferenceChecks<OutputReferenceAst> Test => new(
    new OutputFactories(),
    parser => parser.ParseReference(new OutputParserFactories(parser), ""));
}
