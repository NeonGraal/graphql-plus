//HintName: test_generic-parent-arg+Output_Impl.gen.cs
// Generated from generic-parent-arg+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Output;

public class testGnrcPrntArgOutp<Ttype>
  : testRefGnrcPrntArgOutp
  , ItestGnrcPrntArgOutp<Ttype>
{
  public testGnrcPrntArgOutp GnrcPrntArgOutp { get; set; }
}

public class testRefGnrcPrntArgOutp<Tref>
  : ItestRefGnrcPrntArgOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntArgOutp RefGnrcPrntArgOutp { get; set; }
}
