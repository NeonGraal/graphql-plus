//HintName: test_generic-parent-string-dom+Input_Impl.gen.cs
// Generated from generic-parent-string-dom+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

public class testGnrcPrntStrDomInp
  : testFieldGnrcPrntStrDomInp<ItestDomGnrcPrntStrDomInp>
  , ItestGnrcPrntStrDomInp
{
  public ItestGnrcPrntStrDomInpObject AsGnrcPrntStrDomInp { get; set; }
}

public class testFieldGnrcPrntStrDomInp<TRef>
  : ItestFieldGnrcPrntStrDomInp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntStrDomInpObject AsFieldGnrcPrntStrDomInp { get; set; }
}

public class testDomGnrcPrntStrDomInp
  : DomainString
  , ItestDomGnrcPrntStrDomInp
{
}
