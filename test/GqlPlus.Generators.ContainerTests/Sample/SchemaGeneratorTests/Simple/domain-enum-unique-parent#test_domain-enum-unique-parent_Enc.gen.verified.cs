//HintName: test_domain-enum-unique-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-unique-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_unique_parent;

public class testDmnEnumUnqPrnt
  : GqlpDomainEnum
  , ItestDmnEnumUnqPrnt
{
}

public enum testEnumDmnEnumUnqPrnt
{
  dmnEnumUnqPrnt = testPrntDmnEnumUnqPrnt.dmnEnumUnqPrnt,
  prnt_dmnEnumUnqPrnt = testPrntDmnEnumUnqPrnt.prnt_dmnEnumUnqPrnt,
  dmnEnumUnqPrntPrnt = testPrntDmnEnumUnqPrnt.dmnEnumUnqPrntPrnt,
  enum_dmnEnumUnqPrnt,
  dmnEnumUnqPrntValue,
}

public enum testPrntDmnEnumUnqPrnt
{
  dmnEnumUnqPrnt,
  prnt_dmnEnumUnqPrnt,
  dmnEnumUnqPrntPrnt,
}

public enum testDupDmnEnumUnqPrnt
{
  dmnEnumUnqPrnt,
  dup_dmnEnumUnqPrnt,
  dmnEnumUnqPrntDup,
}
