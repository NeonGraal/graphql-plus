//HintName: test_generic-parent-enum-child+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

public class testGnrcPrntEnumChildInp
  : testFieldGnrcPrntEnumChildInp<testParentGnrcPrntEnumChildInp>
  , ItestGnrcPrntEnumChildInp
{
}

public class testFieldGnrcPrntEnumChildInp<TRef>
  : ItestFieldGnrcPrntEnumChildInp<TRef>
{
  public TRef Field { get; set; }
}
