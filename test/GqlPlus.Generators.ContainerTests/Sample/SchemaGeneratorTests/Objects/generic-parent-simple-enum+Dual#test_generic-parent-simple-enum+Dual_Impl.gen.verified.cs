//HintName: test_generic-parent-simple-enum+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Dual;

public class testGnrcPrntSmplEnumDual
  : testFieldGnrcPrntSmplEnumDual<testEnumGnrcPrntSmplEnumDual>
  , ItestGnrcPrntSmplEnumDual
{
}

public class testFieldGnrcPrntSmplEnumDual<TRef>
  : ItestFieldGnrcPrntSmplEnumDual<TRef>
{
  public TRef Field { get; set; }
}
