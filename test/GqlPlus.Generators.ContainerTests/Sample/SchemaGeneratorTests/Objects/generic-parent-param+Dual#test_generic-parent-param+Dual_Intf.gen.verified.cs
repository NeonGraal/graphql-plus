//HintName: test_generic-parent-param+Dual_Intf.gen.cs
// Generated from generic-parent-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

public interface ItestGnrcPrntParamDual
  : ItestRefGnrcPrntParamDual
{
}

public interface ItestGnrcPrntParamDualObject
  : ItestRefGnrcPrntParamDualObject
{
}

public interface ItestRefGnrcPrntParamDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcPrntParamDualObject<Tref>
{
}

public interface ItestAltGnrcPrntParamDual
{
  public ItestString AsString { get; set; }
}

public interface ItestAltGnrcPrntParamDualObject
{
  public ItestNumber Alt { get; set; }
}
