//HintName: test_generic-parent-dual-parent+Dual_Intf.gen.cs
// Generated from generic-parent-dual-parent+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

public interface ItestGnrcPrntDualPrntDual
  : ItestRefGnrcPrntDualPrntDual
{
  public ItestGnrcPrntDualPrntDualObject AsGnrcPrntDualPrntDual { get; set; }
}

public interface ItestGnrcPrntDualPrntDualObject
  : ItestRefGnrcPrntDualPrntDualObject
{
}

public interface ItestRefGnrcPrntDualPrntDual<Tref>
  : Itestref
{
  public ItestRefGnrcPrntDualPrntDualObject AsRefGnrcPrntDualPrntDual { get; set; }
}

public interface ItestRefGnrcPrntDualPrntDualObject<Tref>
  : ItestrefObject
{
}

public interface ItestAltGnrcPrntDualPrntDual
{
  public ItestString AsString { get; set; }
  public ItestAltGnrcPrntDualPrntDualObject AsAltGnrcPrntDualPrntDual { get; set; }
}

public interface ItestAltGnrcPrntDualPrntDualObject
{
  public ItestNumber Alt { get; set; }
}
