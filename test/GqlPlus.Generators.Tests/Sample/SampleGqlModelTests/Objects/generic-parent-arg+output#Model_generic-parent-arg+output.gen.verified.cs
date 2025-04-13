//HintName: Model_generic-parent-arg+output.gen.cs
// Generated from generic-parent-arg+output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_arg_output;

public interface IOutpGnrcPrntArg<Ttype>
  : IRefOutpGnrcPrntArg
{
}
public class OutputOutpGnrcPrntArg<Ttype>
  : OutputRefOutpGnrcPrntArg
  , IOutpGnrcPrntArg<Ttype>
{
}

public interface IRefOutpGnrcPrntArg<Tref>
{
  Tref Asref { get; }
}
public class OutputRefOutpGnrcPrntArg<Tref>
  : IRefOutpGnrcPrntArg<Tref>
{
  public Tref Asref { get; set; }
}
