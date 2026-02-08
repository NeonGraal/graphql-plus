//HintName: test_generic-parent-string-dom+Output_Impl.gen.cs
// Generated from generic-parent-string-dom+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Output;

public class testGnrcPrntStrDomOutp
  : testFieldGnrcPrntStrDomOutp
  , ItestGnrcPrntStrDomOutp
{
  public ItestGnrcPrntStrDomOutpObject AsGnrcPrntStrDomOutp { get; set; }
}

public class testFieldGnrcPrntStrDomOutp<Tref>
  : ItestFieldGnrcPrntStrDomOutp<Tref>
{
  public Tref Field { get; set; }
  public ItestFieldGnrcPrntStrDomOutpObject AsFieldGnrcPrntStrDomOutp { get; set; }
}

public class testDomGnrcPrntStrDomOutp
  : DomainString
  , ItestDomGnrcPrntStrDomOutp
{
}
