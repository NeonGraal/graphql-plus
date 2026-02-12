//HintName: test_generic-parent-arg+Output_Impl.gen.cs
// Generated from generic-parent-arg+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Output;

public class testGnrcPrntArgOutp<TType>
  : testRefGnrcPrntArgOutp<TType>
  , ItestGnrcPrntArgOutp<TType>
{
  public ItestGnrcPrntArgOutpObject<TType> AsGnrcPrntArgOutp { get; set; }
}

public class testRefGnrcPrntArgOutp<TRef>
  : ItestRefGnrcPrntArgOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntArgOutpObject<TRef> AsRefGnrcPrntArgOutp { get; set; }
}
