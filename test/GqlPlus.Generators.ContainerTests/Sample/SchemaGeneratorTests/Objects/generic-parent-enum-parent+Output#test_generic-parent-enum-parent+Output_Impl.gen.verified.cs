//HintName: test_generic-parent-enum-parent+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

public class testGnrcPrntEnumPrntOutp
  : testFieldGnrcPrntEnumPrntOutp<testEnumGnrcPrntEnumPrntOutp>
  , ItestGnrcPrntEnumPrntOutp
{
}

public class testFieldGnrcPrntEnumPrntOutp<TRef>
  : ItestFieldGnrcPrntEnumPrntOutp<TRef>
{
  public TRef Field { get; set; }
}
