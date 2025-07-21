//HintName: Gqlp_generic-parent-arg+Dual_Impl.gen.cs
// Generated from generic-parent-arg+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_arg_Dual;
public class DualGnrcPrntArgDual<Ttype>
  : DualRefGnrcPrntArgDual
  , IGnrcPrntArgDual<Ttype>
{
}
public class DualRefGnrcPrntArgDual<Tref>
  : IRefGnrcPrntArgDual<Tref>
{
  public Tref Asref { get; set; }
}
