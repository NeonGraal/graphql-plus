//HintName: test_enum-parent-alias_Intf.gen.cs
// Generated from {CurrentDirectory}enum-parent-alias.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_alias;

public enum testEnumPrntAlias
{
  prnt_enumPrntAlias = testPrntEnumPrntAlias.prnt_enumPrntAlias,
  val_enumPrntAlias,
  prnt_enumPrntAlias,
  enumPrntAlias = prnt_enumPrntAlias,
}

public enum testPrntEnumPrntAlias
{
  prnt_enumPrntAlias,
}
