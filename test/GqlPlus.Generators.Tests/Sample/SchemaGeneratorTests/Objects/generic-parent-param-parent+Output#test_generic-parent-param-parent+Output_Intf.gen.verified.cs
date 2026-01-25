//HintName: test_generic-parent-param-parent+Output_Intf.gen.cs
// Generated from generic-parent-param-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public interface ItestGnrcPrntParamPrntOutp
  : ItestRefGnrcPrntParamPrntOutp
{
  public testGnrcPrntParamPrntOutp GnrcPrntParamPrntOutp { get; set; }
}

public interface ItestGnrcPrntParamPrntOutpObject
  : ItestRefGnrcPrntParamPrntOutpObject
{
}

public interface ItestRefGnrcPrntParamPrntOutp<Tref>
  : Itestref
{
  public testRefGnrcPrntParamPrntOutp RefGnrcPrntParamPrntOutp { get; set; }
}

public interface ItestRefGnrcPrntParamPrntOutpObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntParamPrntOutp
{
  public testString AsString { get; set; }
  public testAltGnrcPrntParamPrntOutp AltGnrcPrntParamPrntOutp { get; set; }
}

public interface ItestAltGnrcPrntParamPrntOutpObject
{
  public testNumber alt { get; set; }
}
