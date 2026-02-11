//HintName: test_generic-parent-arg+Dual_Intf.gen.cs
// Generated from generic-parent-arg+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

public interface ItestGnrcPrntArgDual<TType>
  : ItestRefGnrcPrntArgDual<TType>
{
  ItestGnrcPrntArgDualObject AsGnrcPrntArgDual { get; }
}

public interface ItestGnrcPrntArgDualObject<TType>
  : ItestRefGnrcPrntArgDualObject<TType>
{
}

public interface ItestRefGnrcPrntArgDual<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcPrntArgDualObject AsRefGnrcPrntArgDual { get; }
}

public interface ItestRefGnrcPrntArgDualObject<TRef>
{
}
