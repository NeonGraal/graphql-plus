//HintName: test_generic-parent-dual-parent+Input_Intf.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public interface ItestGnrcPrntDualPrntInp
  : ItestRefGnrcPrntDualPrntInp
{
}

public interface ItestRefGnrcPrntDualPrntInp<Tref>
  : Itestref
{
}

public interface ItestAltGnrcPrntDualPrntInp
{
  Number alt { get; }
  String AsString { get; }
}
