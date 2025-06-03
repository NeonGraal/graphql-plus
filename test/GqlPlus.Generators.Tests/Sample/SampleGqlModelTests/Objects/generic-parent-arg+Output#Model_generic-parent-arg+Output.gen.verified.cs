//HintName: Model_generic-parent-arg+Output.gen.cs
// Generated from generic-parent-arg+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_arg_Output;

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
