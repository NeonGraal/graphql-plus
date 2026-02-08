//HintName: test_generic-parent-dual-parent+Input_Intf.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public interface ItestGnrcPrntDualPrntInp
  : ItestRefGnrcPrntDualPrntInp
{
}

public interface ItestGnrcPrntDualPrntInpObject
  : ItestRefGnrcPrntDualPrntInpObject
{
}

public interface ItestRefGnrcPrntDualPrntInp<Tref>
  : Itestref
{
}

public interface ItestRefGnrcPrntDualPrntInpObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntDualPrntInp
{
  public ItestString AsString { get; set; }
}

public interface ItestAltGnrcPrntDualPrntInpObject
{
  public ItestNumber Alt { get; set; }
}
