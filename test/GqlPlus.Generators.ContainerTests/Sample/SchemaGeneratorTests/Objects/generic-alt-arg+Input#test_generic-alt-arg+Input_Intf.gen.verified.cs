//HintName: test_generic-alt-arg+Input_Intf.gen.cs
// Generated from generic-alt-arg+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public interface ItestGnrcAltArgInp<Ttype>
{
  ItestRefGnrcAltArgInp<Ttype> AsRefGnrcAltArgInp { get; }
  ItestGnrcAltArgInpObject AsGnrcAltArgInp { get; }
}

public interface ItestGnrcAltArgInpObject<Ttype>
{
}

public interface ItestRefGnrcAltArgInp<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcAltArgInpObject AsRefGnrcAltArgInp { get; }
}

public interface ItestRefGnrcAltArgInpObject<Tref>
{
}
