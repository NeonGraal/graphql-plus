//HintName: Gqlp_generic-parent-arg+Dual_Intf.gen.cs
// Generated from generic-parent-arg+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_arg_Dual;

public interface IGnrcPrntArgDual<Ttype>
  : IRefGnrcPrntArgDual
{
}

public interface IRefGnrcPrntArgDual<Tref>
{
  Tref Asref { get; }
}
