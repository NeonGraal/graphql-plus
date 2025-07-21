//HintName: Gqlp_generic-parent-arg+Input_Impl.gen.cs
// Generated from generic-parent-arg+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_arg_Input;
public class InputGnrcPrntArgInp<Ttype>
  : InputRefGnrcPrntArgInp
  , IGnrcPrntArgInp<Ttype>
{
}
public class InputRefGnrcPrntArgInp<Tref>
  : IRefGnrcPrntArgInp<Tref>
{
  public Tref Asref { get; set; }
}
