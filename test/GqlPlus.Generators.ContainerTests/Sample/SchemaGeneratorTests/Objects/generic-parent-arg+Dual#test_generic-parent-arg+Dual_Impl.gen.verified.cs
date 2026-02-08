//HintName: test_generic-parent-arg+Dual_Impl.gen.cs
// Generated from generic-parent-arg+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

public class testGnrcPrntArgDual<Ttype>
  : testRefGnrcPrntArgDual
  , ItestGnrcPrntArgDual<Ttype>
{
  public ItestGnrcPrntArgDualObject AsGnrcPrntArgDual { get; set; }
}

public class testRefGnrcPrntArgDual<Tref>
  : ItestRefGnrcPrntArgDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcPrntArgDualObject AsRefGnrcPrntArgDual { get; set; }
}
