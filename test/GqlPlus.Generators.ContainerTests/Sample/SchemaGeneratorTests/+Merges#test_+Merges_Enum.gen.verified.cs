//HintName: test_+Merges_Enum.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Enum
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

public enum testEnumAlias
{
  enumAlias,
}

public enum testEnumDiff
{
  one,
  two,
}

public enum testEnumSame
{
  enumSame,
}

public enum testEnumSamePrnt
{
  prnt_enumSamePrnt = testPrntEnumSamePrnt.prnt_enumSamePrnt,
  enumSamePrnt,
}

public enum testPrntEnumSamePrnt
{
  prnt_enumSamePrnt,
}

public enum testEnumValueAlias
{
  enumValueAlias,
  val1 = enumValueAlias,
  val2 = enumValueAlias,
}
