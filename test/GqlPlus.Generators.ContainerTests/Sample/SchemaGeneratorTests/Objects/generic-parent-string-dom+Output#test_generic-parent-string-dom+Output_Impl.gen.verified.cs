//HintName: test_generic-parent-string-dom+Output_Impl.gen.cs
// Generated from generic-parent-string-dom+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Output;

public class testGnrcPrntStrDomOutp
  : testFieldGnrcPrntStrDomOutp<ItestDomGnrcPrntStrDomOutp>
  , ItestGnrcPrntStrDomOutp
{
}

public class testFieldGnrcPrntStrDomOutp<TRef>
  : ItestFieldGnrcPrntStrDomOutp<TRef>
{
  public TRef Field { get; set; }
}

public class testDomGnrcPrntStrDomOutp
  : GqlpDomainString
  , ItestDomGnrcPrntStrDomOutp
{
}
