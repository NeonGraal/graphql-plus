//HintName: Model_generic-parent-arg+Output.gen.cs
// Generated from generic-parent-arg+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_arg_Output;

public interface IGnrcPrntArgOutp<Ttype>
  : IRefGnrcPrntArgOutp
{
}
public class OutputGnrcPrntArgOutp<Ttype>
  : OutputRefGnrcPrntArgOutp
  , IGnrcPrntArgOutp<Ttype>
{
}

public interface IRefGnrcPrntArgOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefGnrcPrntArgOutp<Tref>
  : IRefGnrcPrntArgOutp<Tref>
{
  public Tref Asref { get; set; }
}
