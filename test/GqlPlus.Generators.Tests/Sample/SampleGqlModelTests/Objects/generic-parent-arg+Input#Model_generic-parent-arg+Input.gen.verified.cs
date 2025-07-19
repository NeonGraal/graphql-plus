//HintName: Model_generic-parent-arg+Input.gen.cs
// Generated from generic-parent-arg+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_arg_Input;

public interface IGnrcPrntArgInp<Ttype>
  : IRefGnrcPrntArgInp
{
}
public class InputGnrcPrntArgInp<Ttype>
  : InputRefGnrcPrntArgInp
  , IGnrcPrntArgInp<Ttype>
{
}

public interface IRefGnrcPrntArgInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefGnrcPrntArgInp<Tref>
  : IRefGnrcPrntArgInp<Tref>
{
  public Tref Asref { get; set; }
}
