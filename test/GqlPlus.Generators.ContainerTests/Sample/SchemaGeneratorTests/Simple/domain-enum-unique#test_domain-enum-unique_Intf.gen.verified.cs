//HintName: test_domain-enum-unique_Intf.gen.cs
// Generated from {CurrentDirectory}domain-enum-unique.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_unique;

public interface ItestDmnEnumUnq
  : IGqlpDomainEnum
{
}

public enum testEnumDmnEnumUnq
{
  enum_dmnEnumUnq,
  dmnEnumUnq,
  dmnEnumUnqValue,
}

public enum testDupDmnEnumUnq
{
  dmnEnumUnq,
  dup_dmnEnumUnq,
  dmnEnumUnqDup,
}
