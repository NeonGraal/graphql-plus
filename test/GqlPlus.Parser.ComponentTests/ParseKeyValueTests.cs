﻿using GqlPlus.Parsing;

namespace GqlPlus;

public class ParseKeyValueTests(
  IOneChecksParser<KeyValue<IGqlpConstant>> checks
)
{
  [Theory, RepeatData]
  public void WithKeyValueValid_ReturnsCorrectAst(string key, string value)
    => checks.TrueExpected(
      key + ':' + value,
      new KeyValue<IGqlpConstant>(key.FieldKey(), new ConstantAst(value.FieldKey())));

  [Theory, RepeatData]
  public void WithKeyValueKeyNoEnumValue_ReturnsFalse(string key, string value)
    => checks.FalseExpected(
      key + ".:" + value);

  [Theory, RepeatData]
  public void WithKeyValueValueNoEnumValue_ReturnsFalse(string key, string value)
    => checks.FalseExpected(
      key + ":" + value + ".");

  [Theory, RepeatData]
  public void WithKeyValueNoKey_ReturnsFalse(string value)
    => checks.FalseExpected(':' + value, CheckNull);

  [Theory, RepeatData]
  public void WithKeyValueNoColon_ReturnsFalse(string key, string value)
    => checks.FalseExpected(key + ' ' + value, CheckNull);

  [Theory, RepeatData]
  public void WithKeyValueNoValue_ReturnsFalse(string key)
    => checks.FalseExpected(key + ' ', CheckNull);

  private void CheckNull(KeyValue<IGqlpConstant> result)
    => result.ShouldBe(default);
}
