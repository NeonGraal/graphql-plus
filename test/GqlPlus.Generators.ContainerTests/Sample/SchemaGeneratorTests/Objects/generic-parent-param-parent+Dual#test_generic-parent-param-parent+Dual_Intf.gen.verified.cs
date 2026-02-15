//HintName: test_generic-parent-param-parent+Dual_Intf.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public interface ItestGnrcPrntParamPrntDual
  : ItestRefGnrcPrntParamPrntDual<ItestAltGnrcPrntParamPrntDual>
{
  ItestGnrcPrntParamPrntDualObject AsGnrcPrntParamPrntDual { get; }
}

public interface ItestGnrcPrntParamPrntDualObject
  : ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>
{
}

public interface ItestRefGnrcPrntParamPrntDual<TRef>
{
  TRef AsParent { get; }
  ItestRefGnrcPrntParamPrntDualObject<TRef> AsRefGnrcPrntParamPrntDual { get; }
}

public interface ItestRefGnrcPrntParamPrntDualObject<TRef>
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
