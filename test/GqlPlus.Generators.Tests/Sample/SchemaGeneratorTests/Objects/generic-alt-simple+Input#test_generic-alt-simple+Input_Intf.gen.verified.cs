//HintName: test_generic-alt-simple+Input_Intf.gen.cs
// Generated from generic-alt-simple+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public interface ItestGnrcAltSmplInp
{
  RefGnrcAltSmplInp<String> AsRefGnrcAltSmplInp { get; }
}

public interface ItestRefGnrcAltSmplInp<Tref>
{
  Tref Asref { get; }
}
