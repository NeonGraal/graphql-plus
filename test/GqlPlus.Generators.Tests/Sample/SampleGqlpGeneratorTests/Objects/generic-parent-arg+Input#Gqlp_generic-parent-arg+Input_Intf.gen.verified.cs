//HintName: Gqlp_generic-parent-arg+Input_Intf.gen.cs
// Generated from generic-parent-arg+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_arg_Input;

public interface IGnrcPrntArgInp<Ttype>
  : IRefGnrcPrntArgInp
{
}

public interface IRefGnrcPrntArgInp<Tref>
{
  Tref Asref { get; }
}
