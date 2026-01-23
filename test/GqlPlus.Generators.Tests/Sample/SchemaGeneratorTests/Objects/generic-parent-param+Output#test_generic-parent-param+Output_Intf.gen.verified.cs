//HintName: test_generic-parent-param+Output_Intf.gen.cs
// Generated from generic-parent-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public interface ItestGnrcPrntParamOutp
  : ItestRefGnrcPrntParamOutp
{
  public testGnrcPrntParamOutp GnrcPrntParamOutp { get; set; }
}

public interface ItestGnrcPrntParamOutpObject
  : ItestRefGnrcPrntParamOutpObject
{
}

public interface ItestRefGnrcPrntParamOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntParamOutp RefGnrcPrntParamOutp { get; set; }
}

public interface ItestRefGnrcPrntParamOutpObject<Tref>
{
}

public interface ItestAltGnrcPrntParamOutp
{
  public testString AsString { get; set; }
  public testAltGnrcPrntParamOutp AltGnrcPrntParamOutp { get; set; }
}

public interface ItestAltGnrcPrntParamOutpObject
{
  public testNumber alt { get; set; }
}
