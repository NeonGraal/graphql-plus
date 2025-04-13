//HintName: Model_generic-parent-arg+input.gen.cs
// Generated from generic-parent-arg+input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_arg_input;

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
