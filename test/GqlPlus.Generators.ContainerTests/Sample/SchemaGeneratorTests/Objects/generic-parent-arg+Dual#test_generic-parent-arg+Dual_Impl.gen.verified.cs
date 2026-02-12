//HintName: test_generic-parent-arg+Dual_Impl.gen.cs
// Generated from generic-parent-arg+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

public class testGnrcPrntArgDual<TType>
  : testRefGnrcPrntArgDual<TType>
  , ItestGnrcPrntArgDual<TType>
{
  public ItestGnrcPrntArgDualObject<TType> AsGnrcPrntArgDual { get; set; }
}

public class testRefGnrcPrntArgDual<TRef>
  : ItestRefGnrcPrntArgDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntArgDualObject<TRef> AsRefGnrcPrntArgDual { get; set; }
}
