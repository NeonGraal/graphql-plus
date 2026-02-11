//HintName: test_generic-alt-arg+Dual_Intf.gen.cs
// Generated from generic-alt-arg+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

public interface ItestGnrcAltArgDual<Ttype>
{
  ItestRefGnrcAltArgDual<Ttype> AsRefGnrcAltArgDual { get; }
  ItestGnrcAltArgDualObject AsGnrcAltArgDual { get; }
}

public interface ItestGnrcAltArgDualObject<Ttype>
{
}

public interface ItestRefGnrcAltArgDual<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcAltArgDualObject AsRefGnrcAltArgDual { get; }
}

public interface ItestRefGnrcAltArgDualObject<Tref>
{
}
