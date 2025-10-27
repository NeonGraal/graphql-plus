//HintName: test_generic-parent-dual+Input_Intf.gen.cs
// Generated from generic-parent-dual+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public interface ItestGnrcPrntDualInp
  : ItestRefGnrcPrntDualInp
{
}

public interface ItestRefGnrcPrntDualInp<Tref>
{
  Tref Asref { get; }
}

public interface ItestAltGnrcPrntDualInp
{
  Number alt { get; }
  String AsString { get; }
}
