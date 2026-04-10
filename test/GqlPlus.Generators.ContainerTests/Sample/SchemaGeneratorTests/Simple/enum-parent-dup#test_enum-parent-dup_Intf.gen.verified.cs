//HintName: test_enum-parent-dup_Intf.gen.cs
// Generated from {CurrentDirectory}enum-parent-dup.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_dup;

public enum testEnumPrntDup
{
  prnt_enumPrntDup = testPrntEnumPrntDup.prnt_enumPrntDup,
  enumPrntDup = testPrntEnumPrntDup.prnt_enumPrntDup,
  enumPrntDup,
}

public enum testPrntEnumPrntDup
{
  prnt_enumPrntDup,
  enumPrntDup = prnt_enumPrntDup,
}
