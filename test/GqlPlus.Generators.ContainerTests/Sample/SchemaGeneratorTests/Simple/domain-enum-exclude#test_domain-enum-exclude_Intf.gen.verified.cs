//HintName: test_domain-enum-exclude_Intf.gen.cs
// Generated from {CurrentDirectory}domain-enum-exclude.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_exclude;

public interface ItestDmnEnumExcl
  : IGqlpDomainEnum
{
  new testEnumDmnEnumExcl? Value { get; }
}

public enum testEnumDmnEnumExcl
{
  dmnEnumExcl,
  enum_dmnEnumExcl,
  dmnEnumExclValue,
}
