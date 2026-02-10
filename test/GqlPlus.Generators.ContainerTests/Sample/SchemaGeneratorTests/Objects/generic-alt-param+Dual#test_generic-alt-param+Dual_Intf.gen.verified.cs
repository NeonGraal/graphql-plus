//HintName: test_generic-alt-param+Dual_Intf.gen.cs
// Generated from generic-alt-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public interface ItestGnrcAltParamDual
{
  public ItestRefGnrcAltParamDual<ItestAltGnrcAltParamDual> AsRefGnrcAltParamDual { get; set; }
  public ItestGnrcAltParamDualObject AsGnrcAltParamDual { get; set; }
}

public interface ItestGnrcAltParamDualObject
{
}

public interface ItestRefGnrcAltParamDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltParamDualObject AsRefGnrcAltParamDual { get; set; }
}

public interface ItestRefGnrcAltParamDualObject<Tref>
{
}

public interface ItestAltGnrcAltParamDual
{
  public string AsString { get; set; }
  public ItestAltGnrcAltParamDualObject AsAltGnrcAltParamDual { get; set; }
}

public interface ItestAltGnrcAltParamDualObject
{
  public decimal Alt { get; set; }
}
