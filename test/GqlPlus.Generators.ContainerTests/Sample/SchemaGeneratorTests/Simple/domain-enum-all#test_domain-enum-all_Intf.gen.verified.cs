//HintName: test_domain-enum-all_Intf.gen.cs
// Generated from {CurrentDirectory}domain-enum-all.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all;

public interface ItestDmnEnumAll
  : IGqlpDomainEnum
{
  new testEnumDmnEnumAll? Value { get; }
}

public enum testEnumDmnEnumAll
{
  dmnEnumAll,
  enum_dmnEnumAll,
  dmnEnumAllValue,
}
