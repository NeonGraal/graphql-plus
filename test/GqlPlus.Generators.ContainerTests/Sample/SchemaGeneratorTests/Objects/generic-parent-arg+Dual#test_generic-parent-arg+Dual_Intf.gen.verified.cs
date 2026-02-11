//HintName: test_generic-parent-arg+Dual_Intf.gen.cs
// Generated from generic-parent-arg+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

public interface ItestGnrcPrntArgDual<Ttype>
  : ItestRefGnrcPrntArgDual
{
  ItestGnrcPrntArgDualObject AsGnrcPrntArgDual { get; }
}

public interface ItestGnrcPrntArgDualObject<Ttype>
  : ItestRefGnrcPrntArgDualObject
{
}

public interface ItestRefGnrcPrntArgDual<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcPrntArgDualObject AsRefGnrcPrntArgDual { get; }
}

public interface ItestRefGnrcPrntArgDualObject<Tref>
{
}
