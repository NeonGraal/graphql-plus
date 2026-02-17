//HintName: test_generic-parent-enum-child+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Dual;

public class testGnrcPrntEnumChildDual
  : testFieldGnrcPrntEnumChildDual<testParentGnrcPrntEnumChildDual>
  , ItestGnrcPrntEnumChildDual
{
}

public class testFieldGnrcPrntEnumChildDual<TRef>
  : ItestFieldGnrcPrntEnumChildDual<TRef>
{
  public TRef Field { get; set; }
}
