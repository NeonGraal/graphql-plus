//HintName: test_generic-parent-simple-enum+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

public class testGnrcPrntSmplEnumOutp
  : testFieldGnrcPrntSmplEnumOutp<testEnumGnrcPrntSmplEnumOutp>
  , ItestGnrcPrntSmplEnumOutp
{
}

public class testFieldGnrcPrntSmplEnumOutp<TRef>
  : ItestFieldGnrcPrntSmplEnumOutp<TRef>
{
  public TRef Field { get; set; }
}
