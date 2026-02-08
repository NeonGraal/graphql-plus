//HintName: test_generic-alt-arg+Dual_Intf.gen.cs
// Generated from generic-alt-arg+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

public interface ItestGnrcAltArgDual<Ttype>
{
  public ItestRefGnrcAltArgDual<Ttype> AsRefGnrcAltArgDual { get; set; }
}

public interface ItestGnrcAltArgDualObject<Ttype>
{
}

public interface ItestRefGnrcAltArgDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcAltArgDualObject<Tref>
{
}
