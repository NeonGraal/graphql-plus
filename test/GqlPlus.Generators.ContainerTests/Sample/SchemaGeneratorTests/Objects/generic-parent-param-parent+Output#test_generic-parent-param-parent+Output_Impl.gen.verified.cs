//HintName: test_generic-parent-param-parent+Output_Impl.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public class testGnrcPrntParamPrntOutp
  : testRefGnrcPrntParamPrntOutp
  , ItestGnrcPrntParamPrntOutp
{
}

public class testRefGnrcPrntParamPrntOutp<Tref>
  : testref
  , ItestRefGnrcPrntParamPrntOutp<Tref>
{
}

public class testAltGnrcPrntParamPrntOutp
  : ItestAltGnrcPrntParamPrntOutp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
}
