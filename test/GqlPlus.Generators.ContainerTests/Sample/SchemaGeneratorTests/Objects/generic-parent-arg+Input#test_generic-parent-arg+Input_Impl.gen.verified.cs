//HintName: test_generic-parent-arg+Input_Impl.gen.cs
// Generated from generic-parent-arg+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Input;

public class testGnrcPrntArgInp<Ttype>
  : testRefGnrcPrntArgInp
  , ItestGnrcPrntArgInp<Ttype>
{
  public ItestGnrcPrntArgInpObject AsGnrcPrntArgInp { get; set; }
}

public class testRefGnrcPrntArgInp<Tref>
  : ItestRefGnrcPrntArgInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcPrntArgInpObject AsRefGnrcPrntArgInp { get; set; }
}
