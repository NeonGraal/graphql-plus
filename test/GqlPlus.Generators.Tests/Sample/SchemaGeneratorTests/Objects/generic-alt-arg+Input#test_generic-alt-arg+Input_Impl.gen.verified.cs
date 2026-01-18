//HintName: test_generic-alt-arg+Input_Impl.gen.cs
// Generated from generic-alt-arg+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public class testGnrcAltArgInp<Ttype>
  : ItestGnrcAltArgInp<Ttype>
{
  public testRefGnrcAltArgInp<Ttype> AsRefGnrcAltArgInp { get; set; }
  public testGnrcAltArgInp GnrcAltArgInp { get; set; }
}

public class testRefGnrcAltArgInp<Tref>
  : ItestRefGnrcAltArgInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltArgInp RefGnrcAltArgInp { get; set; }
}
