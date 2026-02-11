//HintName: test_generic-parent-param+Dual_Intf.gen.cs
// Generated from generic-parent-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

public interface ItestGnrcPrntParamDual
  : ItestRefGnrcPrntParamDual<ItestAltGnrcPrntParamDual>
{
  ItestGnrcPrntParamDualObject AsGnrcPrntParamDual { get; }
}

public interface ItestGnrcPrntParamDualObject
  : ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>
{
}

public interface ItestRefGnrcPrntParamDual<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcPrntParamDualObject AsRefGnrcPrntParamDual { get; }
}

public interface ItestRefGnrcPrntParamDualObject<TRef>
{
}

public interface ItestAltGnrcPrntParamDual
{
  string AsString { get; }
  ItestAltGnrcPrntParamDualObject AsAltGnrcPrntParamDual { get; }
}

public interface ItestAltGnrcPrntParamDualObject
{
  decimal Alt { get; }
}
