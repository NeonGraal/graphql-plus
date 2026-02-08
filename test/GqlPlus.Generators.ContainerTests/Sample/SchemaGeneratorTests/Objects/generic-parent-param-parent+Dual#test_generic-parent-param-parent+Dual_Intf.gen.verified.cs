//HintName: test_generic-parent-param-parent+Dual_Intf.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public interface ItestGnrcPrntParamPrntDual
  : ItestRefGnrcPrntParamPrntDual
{
}

public interface ItestGnrcPrntParamPrntDualObject
  : ItestRefGnrcPrntParamPrntDualObject
{
}

public interface ItestRefGnrcPrntParamPrntDual<Tref>
  : Itestref
{
}

public interface ItestRefGnrcPrntParamPrntDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntParamPrntDual
{
  public ItestString AsString { get; set; }
}

public interface ItestAltGnrcPrntParamPrntDualObject
{
  public ItestNumber Alt { get; set; }
}
