﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseInputFieldTests
  : BaseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithDefault_ReturnsCorrectAst(string name, string fieldType, string content)
    => Test.TrueExpected(
      name + ":" + fieldType + "='" + content + "'",
      Test.Field(name, fieldType) with {
        Default = new FieldKeyAst(AstNulls.At, content)
      });

  internal override IBaseFieldChecks Checks => Test;

  private readonly BaseFieldParserChecks<InputFieldAst, InputReferenceAst> Test;

  public ParseInputFieldTests(IParser<InputFieldAst> parser)
    => Test = new(new InputFactories(), parser);
}
