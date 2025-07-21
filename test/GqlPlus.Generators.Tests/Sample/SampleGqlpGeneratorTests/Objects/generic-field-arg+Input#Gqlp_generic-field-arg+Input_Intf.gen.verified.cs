//HintName: Gqlp_generic-field-arg+Input_Intf.gen.cs
// Generated from generic-field-arg+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_arg_Input;

public interface IGnrcFieldArgInp<Ttype>
{
  RefGnrcFieldArgInp<Ttype> field { get; }
}

public interface IRefGnrcFieldArgInp<Tref>
{
  Tref Asref { get; }
}
