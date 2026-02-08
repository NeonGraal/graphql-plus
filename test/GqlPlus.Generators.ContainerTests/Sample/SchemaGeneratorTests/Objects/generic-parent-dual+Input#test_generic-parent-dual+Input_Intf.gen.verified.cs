//HintName: test_generic-parent-dual+Input_Intf.gen.cs
// Generated from generic-parent-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public interface ItestGnrcPrntDualInp
  : ItestRefGnrcPrntDualInp
{
}

public interface ItestGnrcPrntDualInpObject
  : ItestRefGnrcPrntDualInpObject
{
}

public interface ItestRefGnrcPrntDualInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcPrntDualInpObject<Tref>
{
}

public interface ItestAltGnrcPrntDualInp
{
  public ItestString AsString { get; set; }
}

public interface ItestAltGnrcPrntDualInpObject
{
  public ItestNumber Alt { get; set; }
}
