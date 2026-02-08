//HintName: test_generic-parent-param+Output_Intf.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public interface ItestGnrcPrntParamOutp
  : ItestRefGnrcPrntParamOutp
{
}

public interface ItestGnrcPrntParamOutpObject
  : ItestRefGnrcPrntParamOutpObject
{
}

public interface ItestRefGnrcPrntParamOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcPrntParamOutpObject<Tref>
{
}

public interface ItestAltGnrcPrntParamOutp
{
  public ItestString AsString { get; set; }
}

public interface ItestAltGnrcPrntParamOutpObject
{
  public ItestNumber Alt { get; set; }
}
