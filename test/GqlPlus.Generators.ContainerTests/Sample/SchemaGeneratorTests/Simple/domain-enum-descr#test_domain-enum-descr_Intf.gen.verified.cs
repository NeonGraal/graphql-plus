//HintName: test_domain-enum-descr_Intf.gen.cs
// Generated from {CurrentDirectory}domain-enum-descr.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_descr;

public interface ItestDmnEnumDescr
  : IGqlpDomainEnum
{
  new testEnumDmnEnumDescr? Value { get; }
}

public enum testEnumDmnEnumDescr
{
  dmnEnumDescr,
}
