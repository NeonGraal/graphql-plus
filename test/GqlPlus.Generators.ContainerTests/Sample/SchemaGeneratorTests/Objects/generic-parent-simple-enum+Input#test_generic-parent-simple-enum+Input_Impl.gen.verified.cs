//HintName: test_generic-parent-simple-enum+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

public class testGnrcPrntSmplEnumInp
  : testFieldGnrcPrntSmplEnumInp<testEnumGnrcPrntSmplEnumInp>
  , ItestGnrcPrntSmplEnumInp
{
}

public class testFieldGnrcPrntSmplEnumInp<TRef>
  : ItestFieldGnrcPrntSmplEnumInp<TRef>
{
  public TRef Field { get; set; }
}
