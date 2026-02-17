//HintName: test_generic-parent-enum-parent+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Dual;

public class testGnrcPrntEnumPrntDual
  : testFieldGnrcPrntEnumPrntDual<testEnumGnrcPrntEnumPrntDual>
  , ItestGnrcPrntEnumPrntDual
{
}

public class testFieldGnrcPrntEnumPrntDual<TRef>
  : ItestFieldGnrcPrntEnumPrntDual<TRef>
{
  public TRef Field { get; set; }
}
