//HintName: test_generic-parent-param+Output_Impl.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public class testGnrcPrntParamOutp
  : testRefGnrcPrntParamOutp<ItestAltGnrcPrntParamOutp>
  , ItestGnrcPrntParamOutp
{
}

public class testRefGnrcPrntParamOutp<TRef>
  : ItestRefGnrcPrntParamOutp<TRef>
{
}

public class testAltGnrcPrntParamOutp
  : ItestAltGnrcPrntParamOutp
{
  public decimal Alt { get; set; }
}
