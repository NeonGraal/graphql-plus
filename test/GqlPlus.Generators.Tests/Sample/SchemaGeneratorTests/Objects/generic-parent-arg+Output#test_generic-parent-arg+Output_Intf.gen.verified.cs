//HintName: test_generic-parent-arg+Output_Intf.gen.cs
// Generated from generic-parent-arg+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Output;

public interface ItestGnrcPrntArgOutp<Ttype>
  : ItestRefGnrcPrntArgOutp
{
  public testGnrcPrntArgOutp GnrcPrntArgOutp { get; set; }
}

public interface ItestGnrcPrntArgOutpObject<Ttype>
  : ItestRefGnrcPrntArgOutpObject
{
}

public interface ItestRefGnrcPrntArgOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntArgOutp RefGnrcPrntArgOutp { get; set; }
}

public interface ItestRefGnrcPrntArgOutpObject<Tref>
{
}
