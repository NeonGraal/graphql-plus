//HintName: test_domain-enum-all-parent_Intf.gen.cs
// Generated from {CurrentDirectory}domain-enum-all-parent.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all_parent;

public interface ItestDmnEnumAllPrnt
  : IGqlpDomainEnum
{
  new testEnumDmnEnumAllPrnt? Value { get; }
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
