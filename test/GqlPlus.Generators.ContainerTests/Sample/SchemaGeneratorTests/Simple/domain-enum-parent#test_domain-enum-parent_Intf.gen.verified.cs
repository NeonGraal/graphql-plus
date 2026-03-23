//HintName: test_domain-enum-parent_Intf.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent;

public interface ItestDmnEnumPrnt
  : ItestPrntDmnEnumPrnt
{
  new testEnumDmnEnumPrnt? Value { get; }
}

public interface ItestPrntDmnEnumPrnt
  : IGqlpDomainEnum
{
  new testEnumDmnEnumPrnt? Value { get; }
}
