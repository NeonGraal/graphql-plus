//HintName: test_domain-enum-label_Intf.gen.cs
// Generated from {CurrentDirectory}domain-enum-label.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_label;

public interface ItestDmnEnumLabel
  : IGqlpDomainEnum
{
  new testEnumDmnEnumLabel? Value { get; }
}

public enum testEnumDmnEnumLabel
{
  dmnEnumLabel,
}
