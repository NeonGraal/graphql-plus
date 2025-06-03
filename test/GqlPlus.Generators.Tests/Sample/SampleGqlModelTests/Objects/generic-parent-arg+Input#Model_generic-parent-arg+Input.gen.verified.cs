//HintName: Model_generic-parent-arg+Input.gen.cs
// Generated from generic-parent-arg+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_arg_Input;

public interface IInpGnrcPrntArg<Ttype>
  : IRefInpGnrcPrntArg
{
}
public class InputInpGnrcPrntArg<Ttype>
  : InputRefInpGnrcPrntArg
  , IInpGnrcPrntArg<Ttype>
{
}

public interface IRefInpGnrcPrntArg<Tref>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcPrntArg<Tref>
  : IRefInpGnrcPrntArg<Tref>
{
  public Tref Asref { get; set; }
}
