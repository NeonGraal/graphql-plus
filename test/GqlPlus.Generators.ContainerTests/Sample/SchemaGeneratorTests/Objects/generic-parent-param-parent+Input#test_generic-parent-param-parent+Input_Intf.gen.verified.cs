//HintName: test_generic-parent-param-parent+Input_Intf.gen.cs
// Generated from generic-parent-param-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public interface ItestGnrcPrntParamPrntInp
  : ItestRefGnrcPrntParamPrntInp
{
}

public interface ItestGnrcPrntParamPrntInpObject
  : ItestRefGnrcPrntParamPrntInpObject
{
}

public interface ItestRefGnrcPrntParamPrntInp<Tref>
  : Itestref
{
}

public interface ItestRefGnrcPrntParamPrntInpObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntParamPrntInp
{
  public ItestString AsString { get; set; }
}

public interface ItestAltGnrcPrntParamPrntInpObject
{
  public ItestNumber Alt { get; set; }
}
