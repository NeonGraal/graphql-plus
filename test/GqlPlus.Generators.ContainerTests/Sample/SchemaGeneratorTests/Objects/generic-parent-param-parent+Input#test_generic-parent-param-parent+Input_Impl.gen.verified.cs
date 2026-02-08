//HintName: test_generic-parent-param-parent+Input_Impl.gen.cs
// Generated from generic-parent-param-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public class testGnrcPrntParamPrntInp
  : testRefGnrcPrntParamPrntInp
  , ItestGnrcPrntParamPrntInp
{
}

public class testRefGnrcPrntParamPrntInp<Tref>
  : testref
  , ItestRefGnrcPrntParamPrntInp<Tref>
{
}

public class testAltGnrcPrntParamPrntInp
  : ItestAltGnrcPrntParamPrntInp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
}
