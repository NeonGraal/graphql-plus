//HintName: test_generic-parent-enum-parent+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

public class testGnrcPrntEnumPrntInp
  : testFieldGnrcPrntEnumPrntInp<testEnumGnrcPrntEnumPrntInp>
  , ItestGnrcPrntEnumPrntInp
{
}

public class testFieldGnrcPrntEnumPrntInp<TRef>
  : ItestFieldGnrcPrntEnumPrntInp<TRef>
{
  public TRef Field { get; set; }
}
