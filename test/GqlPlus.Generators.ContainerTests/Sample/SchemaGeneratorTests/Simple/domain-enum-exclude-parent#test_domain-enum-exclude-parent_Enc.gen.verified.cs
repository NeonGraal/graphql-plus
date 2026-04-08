//HintName: test_domain-enum-exclude-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-exclude-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_exclude_parent;

public class testDmnEnumExclPrnt
  : GqlpDomainEnum
  , ItestDmnEnumExclPrnt
{
}

public enum testEnumDmnEnumExclPrnt
{
  prnt_dmnEnumExclPrnt = testPrntDmnEnumExclPrnt.prnt_dmnEnumExclPrnt,
  dmnEnumExclPrntPrnt = testPrntDmnEnumExclPrnt.dmnEnumExclPrntPrnt,
  dmnEnumExclPrnt,
  dmnEnumExclPrntValue,
}

public enum testPrntDmnEnumExclPrnt
{
  prnt_dmnEnumExclPrnt,
  dmnEnumExclPrntPrnt,
}
