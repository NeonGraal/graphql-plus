//HintName: test_generic-parent-param-parent+Dual_Intf.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public interface ItestGnrcPrntParamPrntDual
  : ItestRefGnrcPrntParamPrntDual
{
  ItestGnrcPrntParamPrntDualObject AsGnrcPrntParamPrntDual { get; }
}

public interface ItestGnrcPrntParamPrntDualObject
  : ItestRefGnrcPrntParamPrntDualObject
{
}

public interface ItestRefGnrcPrntParamPrntDual<Tref>
  : Itestref
{
  ItestRefGnrcPrntParamPrntDualObject AsRefGnrcPrntParamPrntDual { get; }
}

public interface ItestRefGnrcPrntParamPrntDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntParamPrntDual
{
  string AsString { get; }
  ItestAltGnrcPrntParamPrntDualObject AsAltGnrcPrntParamPrntDual { get; }
}

public interface ItestAltGnrcPrntParamPrntDualObject
{
  decimal Alt { get; }
}
