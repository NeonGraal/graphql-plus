//HintName: test_generic-parent-arg+Dual_Impl.gen.cs
// Generated from generic-parent-arg+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

public class DualtestGnrcPrntArgDual<Ttype>
  : DualtestRefGnrcPrntArgDual
  , ItestGnrcPrntArgDual<Ttype>
{
}

public class DualtestRefGnrcPrntArgDual<Tref>
  : ItestRefGnrcPrntArgDual<Tref>
{
  public Tref Asref { get; set; }
}
