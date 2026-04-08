//HintName: test_domain-enum-parent-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent_descr;

public class testDmnEnumPrntDescr
  : testPrntDmnEnumPrntDescr
  , ItestDmnEnumPrntDescr
{
}

public class testPrntDmnEnumPrntDescr
  : GqlpDomainEnum
  , ItestPrntDmnEnumPrntDescr
{
}

public enum testEnumDmnEnumPrntDescr
{
  enum_dmnEnumPrntDescr,
  prnt_dmnEnumPrntDescr,
}
