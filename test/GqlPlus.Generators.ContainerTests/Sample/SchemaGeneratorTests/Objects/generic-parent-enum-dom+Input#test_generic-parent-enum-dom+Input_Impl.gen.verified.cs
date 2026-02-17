//HintName: test_generic-parent-enum-dom+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

public class testGnrcPrntEnumDomInp
  : testFieldGnrcPrntEnumDomInp<ItestDomGnrcPrntEnumDomInp>
  , ItestGnrcPrntEnumDomInp
{
}

public class testFieldGnrcPrntEnumDomInp<TRef>
  : ItestFieldGnrcPrntEnumDomInp<TRef>
{
  public TRef Field { get; set; }
}

public class testDomGnrcPrntEnumDomInp
  : GqlpDomainEnum
  , ItestDomGnrcPrntEnumDomInp
{
}
