//HintName: test_generic-parent-string-dom+Input_Impl.gen.cs
// Generated from generic-parent-string-dom+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

public class testGnrcPrntStrDomInp
  : testFieldGnrcPrntStrDomInp
  , ItestGnrcPrntStrDomInp
{
  public testGnrcPrntStrDomInp GnrcPrntStrDomInp { get; set; }
}

public class testFieldGnrcPrntStrDomInp<Tref>
  : ItestFieldGnrcPrntStrDomInp<Tref>
{
  public Tref field { get; set; }
  public testFieldGnrcPrntStrDomInp FieldGnrcPrntStrDomInp { get; set; }
}

public class testDomGnrcPrntStrDomInp
  : DomainString
  , ItestDomGnrcPrntStrDomInp
{
}
