//HintName: test_generic-parent-param+Output_Impl.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public class testGnrcPrntParamOutp
  : testRefGnrcPrntParamOutp
  , ItestGnrcPrntParamOutp
{
}

public class testRefGnrcPrntParamOutp<Tref>
  : ItestRefGnrcPrntParamOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class testAltGnrcPrntParamOutp
  : ItestAltGnrcPrntParamOutp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
}
