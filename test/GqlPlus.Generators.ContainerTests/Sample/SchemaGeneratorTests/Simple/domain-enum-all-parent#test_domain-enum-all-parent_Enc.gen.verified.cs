//HintName: test_domain-enum-all-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-all-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all_parent;

public class testDmnEnumAllPrnt
  : GqlpDomainEnum
  , ItestDmnEnumAllPrnt
{
}

public enum testEnumDmnEnumAllPrnt
{
  prnt_dmnEnumAllPrnt = testPrntDmnEnumAllPrnt.prnt_dmnEnumAllPrnt,
  dmnEnumAllPrntPrnt = testPrntDmnEnumAllPrnt.dmnEnumAllPrntPrnt,
  dmnEnumAllPrnt,
  dmnEnumAllPrntValue,
}

public enum testPrntDmnEnumAllPrnt
{
  prnt_dmnEnumAllPrnt,
  dmnEnumAllPrntPrnt,
}
