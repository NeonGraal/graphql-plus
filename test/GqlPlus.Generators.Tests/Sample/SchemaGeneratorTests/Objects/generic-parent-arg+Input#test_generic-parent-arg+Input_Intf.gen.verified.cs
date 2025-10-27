//HintName: test_generic-parent-arg+Input_Intf.gen.cs
// Generated from generic-parent-arg+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Input;

public interface ItestGnrcPrntArgInp<Ttype>
  : ItestRefGnrcPrntArgInp
{
}

public interface ItestRefGnrcPrntArgInp<Tref>
{
  Tref Asref { get; }
}
