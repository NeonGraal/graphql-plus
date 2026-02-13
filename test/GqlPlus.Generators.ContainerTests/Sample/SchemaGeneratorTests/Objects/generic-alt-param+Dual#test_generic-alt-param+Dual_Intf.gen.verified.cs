//HintName: test_generic-alt-param+Dual_Intf.gen.cs
// Generated from generic-alt-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public interface ItestGnrcAltParamDual
{
  ItestRefGnrcAltParamDual<ItestAltGnrcAltParamDual> AsRefGnrcAltParamDual { get; }
  ItestGnrcAltParamDualObject AsGnrcAltParamDual { get; }
}

public interface ItestGnrcAltParamDualObject
{
}

public interface ItestRefGnrcAltParamDual<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltParamDualObject<TRef> AsRefGnrcAltParamDual { get; }
}

public interface ItestRefGnrcAltParamDualObject<TRef>
{
}

public interface ItestAltGnrcAltParamDual
{
  string AsString { get; }
  ItestAltGnrcAltParamDualObject AsAltGnrcAltParamDual { get; }
}

public interface ItestAltGnrcAltParamDualObject
{
  decimal Alt { get; }
}
