//HintName: test_generic-field-param+Dual_Intf.gen.cs
// Generated from generic-field-param+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public interface ItestGnrcFieldParamDual
{
  ItestGnrcFieldParamDualObject AsGnrcFieldParamDual { get; }
}

public interface ItestGnrcFieldParamDualObject
{
  ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; }
}

public interface ItestRefGnrcFieldParamDual<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcFieldParamDualObject AsRefGnrcFieldParamDual { get; }
}

public interface ItestRefGnrcFieldParamDualObject<Tref>
{
}

public interface ItestAltGnrcFieldParamDual
{
  string AsString { get; }
  ItestAltGnrcFieldParamDualObject AsAltGnrcFieldParamDual { get; }
}

public interface ItestAltGnrcFieldParamDualObject
{
  decimal Alt { get; }
}
