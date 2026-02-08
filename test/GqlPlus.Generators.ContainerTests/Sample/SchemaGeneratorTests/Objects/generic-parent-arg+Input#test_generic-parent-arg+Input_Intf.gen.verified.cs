//HintName: test_generic-parent-arg+Input_Intf.gen.cs
// Generated from generic-parent-arg+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Input;

public interface ItestGnrcPrntArgInp<Ttype>
  : ItestRefGnrcPrntArgInp
{
}

public interface ItestGnrcPrntArgInpObject<Ttype>
  : ItestRefGnrcPrntArgInpObject
{
}

public interface ItestRefGnrcPrntArgInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcPrntArgInpObject<Tref>
{
}
