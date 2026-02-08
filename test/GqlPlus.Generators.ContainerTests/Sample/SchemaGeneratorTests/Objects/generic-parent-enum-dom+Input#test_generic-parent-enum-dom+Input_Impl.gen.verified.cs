//HintName: test_generic-parent-enum-dom+Input_Impl.gen.cs
// Generated from generic-parent-enum-dom+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

public class testGnrcPrntEnumDomInp
  : testFieldGnrcPrntEnumDomInp
  , ItestGnrcPrntEnumDomInp
{
  public ItestGnrcPrntEnumDomInpObject AsGnrcPrntEnumDomInp { get; set; }
}

public class testFieldGnrcPrntEnumDomInp<Tref>
  : ItestFieldGnrcPrntEnumDomInp<Tref>
{
  public Tref Field { get; set; }
  public ItestFieldGnrcPrntEnumDomInpObject AsFieldGnrcPrntEnumDomInp { get; set; }
}

public class testDomGnrcPrntEnumDomInp
  : DomainEnum
  , ItestDomGnrcPrntEnumDomInp
{
}
