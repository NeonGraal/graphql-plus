//HintName: test_generic-alt-param+Output_Impl.gen.cs
// Generated from generic-alt-param+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public class testGnrcAltParamOutp
  : ItestGnrcAltParamOutp
{
  public ItestRefGnrcAltParamOutp<ItestAltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; set; }
  public ItestGnrcAltParamOutpObject AsGnrcAltParamOutp { get; set; }
}

public class testRefGnrcAltParamOutp<Tref>
  : ItestRefGnrcAltParamOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltParamOutpObject AsRefGnrcAltParamOutp { get; set; }
}

public class testAltGnrcAltParamOutp
  : ItestAltGnrcAltParamOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcAltParamOutpObject AsAltGnrcAltParamOutp { get; set; }
}
