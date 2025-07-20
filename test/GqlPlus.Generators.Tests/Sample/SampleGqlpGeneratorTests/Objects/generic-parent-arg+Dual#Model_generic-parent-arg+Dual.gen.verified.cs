//HintName: Model_generic-parent-arg+Dual.gen.cs
// Generated from generic-parent-arg+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_parent_arg_Dual;

public interface IGnrcPrntArgDual<Ttype>
  : IRefGnrcPrntArgDual
{
}
public class DualGnrcPrntArgDual<Ttype>
  : DualRefGnrcPrntArgDual
  , IGnrcPrntArgDual<Ttype>
{
}

public interface IRefGnrcPrntArgDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefGnrcPrntArgDual<Tref>
  : IRefGnrcPrntArgDual<Tref>
{
  public Tref Asref { get; set; }
}
