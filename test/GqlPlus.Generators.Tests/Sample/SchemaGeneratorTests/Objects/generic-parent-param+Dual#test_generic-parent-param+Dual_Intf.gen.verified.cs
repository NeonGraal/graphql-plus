//HintName: test_generic-parent-param+Dual_Intf.gen.cs
// Generated from generic-parent-param+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

public interface ItestGnrcPrntParamDual
  : ItestRefGnrcPrntParamDual
{
}

public interface ItestRefGnrcPrntParamDual<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcPrntParamDual
{
  Number alt { get; }
  String AsString { get; }
}
