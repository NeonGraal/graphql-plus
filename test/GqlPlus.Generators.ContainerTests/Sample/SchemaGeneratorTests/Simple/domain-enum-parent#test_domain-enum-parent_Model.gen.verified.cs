//HintName: test_domain-enum-parent_Model.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent;

public class testDmnEnumPrnt
  : testPrntDmnEnumPrnt
  , ItestDmnEnumPrnt
{
  public new testEnumDmnEnumPrnt? Value { get; set; }
}

public class testPrntDmnEnumPrnt
  : GqlpDomainEnum
  , ItestPrntDmnEnumPrnt
{
  public new testEnumDmnEnumPrnt? Value { get; set; }
}
