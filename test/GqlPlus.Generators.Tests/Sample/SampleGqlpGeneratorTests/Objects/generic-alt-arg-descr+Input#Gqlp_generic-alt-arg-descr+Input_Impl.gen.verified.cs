//HintName: Gqlp_generic-alt-arg-descr+Input_Impl.gen.cs
// Generated from generic-alt-arg-descr+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_arg_descr_Input;
public class InputGnrcAltArgDescrInp<Ttype>
  : IGnrcAltArgDescrInp<Ttype>
{
  public RefGnrcAltArgDescrInp<Ttype> AsRefGnrcAltArgDescrInp { get; set; }
}
public class InputRefGnrcAltArgDescrInp<Tref>
  : IRefGnrcAltArgDescrInp<Tref>
{
  public Tref Asref { get; set; }
}
