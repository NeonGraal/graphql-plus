//HintName: Gqlp_generic-alt-arg+Input_Impl.gen.cs
// Generated from generic-alt-arg+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_arg_Input;

public class InputGnrcAltArgInp<Ttype>
  : IGnrcAltArgInp<Ttype>
{
  public RefGnrcAltArgInp<Ttype> AsRefGnrcAltArgInp { get; set; }
}

public class InputRefGnrcAltArgInp<Tref>
  : IRefGnrcAltArgInp<Tref>
{
  public Tref Asref { get; set; }
}
