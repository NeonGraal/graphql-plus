//HintName: test_generic-alt-param+Output_Intf.gen.cs
// Generated from generic-alt-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public interface ItestGnrcAltParamOutp
{
  public ItestRefGnrcAltParamOutp<ItestAltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; set; }
  public ItestGnrcAltParamOutpObject AsGnrcAltParamOutp { get; set; }
}

public interface ItestGnrcAltParamOutpObject
{
}

public interface ItestRefGnrcAltParamOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltParamOutpObject AsRefGnrcAltParamOutp { get; set; }
}

public interface ItestRefGnrcAltParamOutpObject<Tref>
{
}

public interface ItestAltGnrcAltParamOutp
{
  public string AsString { get; set; }
  public ItestAltGnrcAltParamOutpObject AsAltGnrcAltParamOutp { get; set; }
}

public interface ItestAltGnrcAltParamOutpObject
{
  public decimal Alt { get; set; }
}
