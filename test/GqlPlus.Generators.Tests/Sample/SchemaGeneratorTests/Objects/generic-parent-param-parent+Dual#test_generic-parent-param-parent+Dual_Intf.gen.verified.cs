//HintName: test_generic-parent-param-parent+Dual_Intf.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Dual;

public interface ItestGnrcPrntParamPrntDual
  : ItestRefGnrcPrntParamPrntDual
{
}

public interface ItestRefGnrcPrntParamPrntDual<Tref>
  : Itestref
{
}

public interface ItestAltGnrcPrntParamPrntDual
{
  Number alt { get; }
  String AsString { get; }
}
