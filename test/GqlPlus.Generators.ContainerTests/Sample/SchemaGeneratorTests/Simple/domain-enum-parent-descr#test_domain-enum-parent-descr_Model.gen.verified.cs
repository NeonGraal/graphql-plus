//HintName: test_domain-enum-parent-descr_Model.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent_descr;

public class testDmnEnumPrntDescr
  : testPrntDmnEnumPrntDescr
  , ItestDmnEnumPrntDescr
{
  public new testEnumDmnEnumPrntDescr? Value { get; set; }
}

public class testPrntDmnEnumPrntDescr
  : GqlpDomainEnum
  , ItestPrntDmnEnumPrntDescr
{
  public new testEnumDmnEnumPrntDescr? Value { get; set; }
}
