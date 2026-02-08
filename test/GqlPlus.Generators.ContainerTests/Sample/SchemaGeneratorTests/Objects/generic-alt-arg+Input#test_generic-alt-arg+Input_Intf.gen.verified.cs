//HintName: test_generic-alt-arg+Input_Intf.gen.cs
// Generated from generic-alt-arg+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public interface ItestGnrcAltArgInp<Ttype>
{
  public ItestRefGnrcAltArgInp<Ttype> AsRefGnrcAltArgInp { get; set; }
}

public interface ItestGnrcAltArgInpObject<Ttype>
{
}

public interface ItestRefGnrcAltArgInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcAltArgInpObject<Tref>
{
}
