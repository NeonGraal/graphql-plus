//HintName: test_generic-alt-arg+Dual_Intf.gen.cs
// Generated from generic-alt-arg+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

public interface ItestGnrcAltArgDual<Ttype>
{
  RefGnrcAltArgDual<Ttype> AsRefGnrcAltArgDual { get; }
}

public interface ItestRefGnrcAltArgDual<Tref>
{
  Tref Asref { get; }
}
