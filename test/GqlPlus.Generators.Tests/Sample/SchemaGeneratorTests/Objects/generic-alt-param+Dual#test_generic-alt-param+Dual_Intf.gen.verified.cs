//HintName: test_generic-alt-param+Dual_Intf.gen.cs
// Generated from generic-alt-param+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public interface ItestGnrcAltParamDual
{
  RefGnrcAltParamDual<AltGnrcAltParamDual> AsRefGnrcAltParamDual { get; }
}

public interface ItestRefGnrcAltParamDual<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcAltParamDual
{
  Number alt { get; }
  String AsString { get; }
}
