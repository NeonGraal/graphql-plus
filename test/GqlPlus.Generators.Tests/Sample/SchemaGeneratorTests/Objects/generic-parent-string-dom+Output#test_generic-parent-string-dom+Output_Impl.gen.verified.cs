//HintName: test_generic-parent-string-dom+Output_Impl.gen.cs
// Generated from generic-parent-string-dom+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Output;

public class testGnrcPrntStrDomOutp
  : testFieldGnrcPrntStrDomOutp
  , ItestGnrcPrntStrDomOutp
{
  public testGnrcPrntStrDomOutp GnrcPrntStrDomOutp { get; set; }
}

public class testFieldGnrcPrntStrDomOutp<Tref>
  : ItestFieldGnrcPrntStrDomOutp<Tref>
{
  public Tref field { get; set; }
  public testFieldGnrcPrntStrDomOutp FieldGnrcPrntStrDomOutp { get; set; }
}

public class testDomGnrcPrntStrDomOutp
  : DomainString
  , ItestDomGnrcPrntStrDomOutp
{
}
