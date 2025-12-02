//HintName: test_generic-parent-arg+Input_Intf.gen.cs
// Generated from generic-parent-arg+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Input;

public interface ItestGnrcPrntArgInp<Ttype>
  : ItestRefGnrcPrntArgInp
{
  public testGnrcPrntArgInp GnrcPrntArgInp { get; set; }
}

public interface ItestGnrcPrntArgInpField<Ttype>
  : ItestRefGnrcPrntArgInpField
{
}

public interface ItestRefGnrcPrntArgInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntArgInp RefGnrcPrntArgInp { get; set; }
}

public interface ItestRefGnrcPrntArgInpField<Tref>
{
}
