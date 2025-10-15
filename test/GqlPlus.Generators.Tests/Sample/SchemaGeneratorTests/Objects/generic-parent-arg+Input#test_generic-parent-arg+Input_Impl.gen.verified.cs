//HintName: test_generic-parent-arg+Input_Impl.gen.cs
// Generated from generic-parent-arg+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Input;

public class InputtestGnrcPrntArgInp<Ttype>
  : InputtestRefGnrcPrntArgInp
  , ItestGnrcPrntArgInp<Ttype>
{
}

public class InputtestRefGnrcPrntArgInp<Tref>
  : ItestRefGnrcPrntArgInp<Tref>
{
  public Tref Asref { get; set; }
}
