//HintName: Gqlp_generic-alt-simple+Input_Impl.gen.cs
// Generated from generic-alt-simple+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_simple_Input;
public class InputGnrcAltSmplInp
  : IGnrcAltSmplInp
{
  public RefGnrcAltSmplInp<String> AsRefGnrcAltSmplInp { get; set; }
}
public class InputRefGnrcAltSmplInp<Tref>
  : IRefGnrcAltSmplInp<Tref>
{
  public Tref Asref { get; set; }
}
