//HintName: test_generic-parent-arg+Output_Impl.gen.cs
// Generated from generic-parent-arg+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Output;

public class OutputtestGnrcPrntArgOutp<Ttype>
  : OutputtestRefGnrcPrntArgOutp
  , ItestGnrcPrntArgOutp<Ttype>
{
}

public class OutputtestRefGnrcPrntArgOutp<Tref>
  : ItestRefGnrcPrntArgOutp<Tref>
{
  public Tref Asref { get; set; }
}
