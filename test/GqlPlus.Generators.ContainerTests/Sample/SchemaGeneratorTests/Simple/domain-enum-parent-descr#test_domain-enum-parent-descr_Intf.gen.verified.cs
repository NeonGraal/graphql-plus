//HintName: test_domain-enum-parent-descr_Intf.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent-descr.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent_descr;

public interface ItestDmnEnumPrntDescr
  : ItestPrntDmnEnumPrntDescr
{
  new testEnumDmnEnumPrntDescr? Value { get; }
}

public interface ItestPrntDmnEnumPrntDescr
  : IGqlpDomainEnum
{
  new testEnumDmnEnumPrntDescr? Value { get; }
}

public enum testEnumDmnEnumPrntDescr
{
  enum_dmnEnumPrntDescr,
  prnt_dmnEnumPrntDescr,
}
