//HintName: test_generic-parent-enum-dom+Input_Impl.gen.cs
// Generated from generic-parent-enum-dom+Input.graphql+ for Impl
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
