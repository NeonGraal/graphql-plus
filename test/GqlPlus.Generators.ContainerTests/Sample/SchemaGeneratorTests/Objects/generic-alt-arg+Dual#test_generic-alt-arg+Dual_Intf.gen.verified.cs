//HintName: test_generic-alt-arg+Dual_Intf.gen.cs
// Generated from generic-alt-arg+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

public interface ItestGnrcAltArgDual<TType>
{
  ItestRefGnrcAltArgDual<TType> AsRefGnrcAltArgDual { get; }
  ItestGnrcAltArgDualObject<TType> AsGnrcAltArgDual { get; }
}

public interface ItestGnrcAltArgDualObject<TType>
{
}

public interface ItestRefGnrcAltArgDual<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltArgDualObject<TRef> AsRefGnrcAltArgDual { get; }
}

public interface ItestRefGnrcAltArgDualObject<TRef>
{
}
