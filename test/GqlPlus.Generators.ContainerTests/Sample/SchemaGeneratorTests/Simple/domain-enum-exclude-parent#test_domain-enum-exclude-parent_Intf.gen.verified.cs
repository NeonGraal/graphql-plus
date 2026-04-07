//HintName: test_domain-enum-exclude-parent_Intf.gen.cs
// Generated from {CurrentDirectory}domain-enum-exclude-parent.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_exclude_parent;

public interface ItestDmnEnumExclPrnt
  : IGqlpDomainEnum
{
}

public enum testEnumDmnEnumExclPrnt
{
  prnt_dmnEnumExclPrnt = testPrntDmnEnumExclPrnt.prnt_dmnEnumExclPrnt,
  dmnEnumExclPrntPrnt = testPrntDmnEnumExclPrnt.dmnEnumExclPrntPrnt,
  dmnEnumExclPrnt,
  dmnEnumExclPrntValue,
}

public enum testPrntDmnEnumExclPrnt
{
  prnt_dmnEnumExclPrnt,
  dmnEnumExclPrntPrnt,
}
