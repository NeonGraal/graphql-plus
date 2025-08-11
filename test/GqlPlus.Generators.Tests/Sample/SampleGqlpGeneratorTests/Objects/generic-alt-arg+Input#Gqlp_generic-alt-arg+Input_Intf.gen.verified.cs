//HintName: Gqlp_generic-alt-arg+Input_Intf.gen.cs
// Generated from generic-alt-arg+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_arg_Input;

public interface IGnrcAltArgInp<Ttype>
{
  RefGnrcAltArgInp<Ttype> AsRefGnrcAltArgInp { get; }
}

public interface IRefGnrcAltArgInp<Tref>
{
  Tref Asref { get; }
}
