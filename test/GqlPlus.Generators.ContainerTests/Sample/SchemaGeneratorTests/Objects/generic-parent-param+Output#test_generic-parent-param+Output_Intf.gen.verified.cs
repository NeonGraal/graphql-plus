//HintName: test_generic-parent-param+Output_Intf.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public interface ItestGnrcPrntParamOutp
  : ItestRefGnrcPrntParamOutp
{
  public ItestGnrcPrntParamOutpObject AsGnrcPrntParamOutp { get; set; }
}

public interface ItestGnrcPrntParamOutpObject
  : ItestRefGnrcPrntParamOutpObject
{
}

public interface ItestRefGnrcPrntParamOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcPrntParamOutpObject AsRefGnrcPrntParamOutp { get; set; }
}

public interface ItestRefGnrcPrntParamOutpObject<Tref>
{
}

public interface ItestAltGnrcPrntParamOutp
{
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamOutpObject AsAltGnrcPrntParamOutp { get; set; }
}

public interface ItestAltGnrcPrntParamOutpObject
{
  public decimal Alt { get; set; }
}
