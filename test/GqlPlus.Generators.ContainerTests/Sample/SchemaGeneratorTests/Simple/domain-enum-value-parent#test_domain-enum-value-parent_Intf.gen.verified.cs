//HintName: test_domain-enum-value-parent_Intf.gen.cs
// Generated from {CurrentDirectory}domain-enum-value-parent.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_value_parent;

public interface ItestDmnEnumValuePrnt
  : IGqlpDomainEnum
{
  new testEnumDmnEnumValuePrnt? Value { get; }
}

public enum testEnumDmnEnumValuePrnt
{
  prnt_dmnEnumValuePrnt = testPrntDmnEnumValuePrnt.prnt_dmnEnumValuePrnt,
  dmnEnumValuePrnt,
}

public enum testPrntDmnEnumValuePrnt
{
  prnt_dmnEnumValuePrnt,
}
