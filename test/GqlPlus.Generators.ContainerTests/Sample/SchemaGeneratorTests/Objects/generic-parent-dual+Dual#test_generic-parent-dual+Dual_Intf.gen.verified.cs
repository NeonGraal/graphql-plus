//HintName: test_generic-parent-dual+Dual_Intf.gen.cs
// Generated from generic-parent-dual+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Dual;

public interface ItestGnrcPrntDualDual
  : ItestRefGnrcPrntDualDual
{
  public ItestGnrcPrntDualDualObject AsGnrcPrntDualDual { get; set; }
}

public interface ItestGnrcPrntDualDualObject
  : ItestRefGnrcPrntDualDualObject
{
}

public interface ItestRefGnrcPrntDualDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcPrntDualDualObject AsRefGnrcPrntDualDual { get; set; }
}

public interface ItestRefGnrcPrntDualDualObject<Tref>
{
}

public interface ItestAltGnrcPrntDualDual
{
  public ItestString AsString { get; set; }
  public ItestAltGnrcPrntDualDualObject AsAltGnrcPrntDualDual { get; set; }
}

public interface ItestAltGnrcPrntDualDualObject
{
  public ItestNumber Alt { get; set; }
}
