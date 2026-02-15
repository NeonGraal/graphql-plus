//HintName: test_enum-parent-dup_Enum.gen.cs
// Generated from enum-parent-dup.graphql+ for Enum
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_dup;

public enum testEnumPrntDup
{
  prnt_enumPrntDup = testPrntEnumPrntDup.prnt_enumPrntDup,
  enumPrntDup = testPrntEnumPrntDup.prnt_enumPrntDup,
  enumPrntDup,
}

public enum testPrntEnumPrntDup
{
  prnt_enumPrntDup,
  enumPrntDup = prnt_enumPrntDup,
}
