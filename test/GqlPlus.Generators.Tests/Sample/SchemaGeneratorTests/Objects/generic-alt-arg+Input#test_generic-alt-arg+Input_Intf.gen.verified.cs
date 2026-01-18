//HintName: test_generic-alt-arg+Input_Intf.gen.cs
// Generated from generic-alt-arg+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public interface ItestGnrcAltArgInp<Ttype>
{
  public testRefGnrcAltArgInp<Ttype> AsRefGnrcAltArgInp { get; set; }
  public testGnrcAltArgInp GnrcAltArgInp { get; set; }
}

public interface ItestGnrcAltArgInpField<Ttype>
{
}

public interface ItestRefGnrcAltArgInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltArgInp RefGnrcAltArgInp { get; set; }
}

public interface ItestRefGnrcAltArgInpField<Tref>
{
}
