//HintName: test_generic-alt-arg+Input_Intf.gen.cs
// Generated from generic-alt-arg+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public interface ItestGnrcAltArgInp<Ttype>
{
  RefGnrcAltArgInp<Ttype> AsRefGnrcAltArgInp { get; }
}

public interface ItestRefGnrcAltArgInp<Tref>
{
  Tref Asref { get; }
}
