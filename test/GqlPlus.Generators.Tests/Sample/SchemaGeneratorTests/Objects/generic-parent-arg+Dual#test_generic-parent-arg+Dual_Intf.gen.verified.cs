//HintName: test_generic-parent-arg+Dual_Intf.gen.cs
// Generated from generic-parent-arg+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

public interface ItestGnrcPrntArgDual<Ttype>
  : ItestRefGnrcPrntArgDual
{
  public testGnrcPrntArgDual GnrcPrntArgDual { get; set; }
}

public interface ItestGnrcPrntArgDualField<Ttype>
  : ItestRefGnrcPrntArgDualField
{
}

public interface ItestRefGnrcPrntArgDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcPrntArgDual RefGnrcPrntArgDual { get; set; }
}

public interface ItestRefGnrcPrntArgDualField<Tref>
{
}
