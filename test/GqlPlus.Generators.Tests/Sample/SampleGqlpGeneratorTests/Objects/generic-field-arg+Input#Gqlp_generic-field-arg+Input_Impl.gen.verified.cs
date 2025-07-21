//HintName: Gqlp_generic-field-arg+Input_Impl.gen.cs
// Generated from generic-field-arg+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_arg_Input;
public class InputGnrcFieldArgInp<Ttype>
  : IGnrcFieldArgInp<Ttype>
{
  public RefGnrcFieldArgInp<Ttype> field { get; set; }
}
public class InputRefGnrcFieldArgInp<Tref>
  : IRefGnrcFieldArgInp<Tref>
{
  public Tref Asref { get; set; }
}
