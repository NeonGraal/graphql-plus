//HintName: test_generic-parent-arg+Dual_Intf.gen.cs
// Generated from generic-parent-arg+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

public interface ItestGnrcPrntArgDual<Ttype>
  : ItestRefGnrcPrntArgDual
{
  public ItestGnrcPrntArgDualObject AsGnrcPrntArgDual { get; set; }
}

public interface ItestGnrcPrntArgDualObject<Ttype>
  : ItestRefGnrcPrntArgDualObject
{
}

public interface ItestRefGnrcPrntArgDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcPrntArgDualObject AsRefGnrcPrntArgDual { get; set; }
}

public interface ItestRefGnrcPrntArgDualObject<Tref>
{
}
