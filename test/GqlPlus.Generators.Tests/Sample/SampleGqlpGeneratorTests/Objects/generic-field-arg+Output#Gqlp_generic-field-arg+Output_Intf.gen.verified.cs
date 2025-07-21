//HintName: Gqlp_generic-field-arg+Output_Intf.gen.cs
// Generated from generic-field-arg+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_arg_Output;

public interface IGnrcFieldArgOutp<Ttype>
{
  RefGnrcFieldArgOutp<Ttype> field { get; }
}

public interface IRefGnrcFieldArgOutp<Tref>
{
  Tref Asref { get; }
}
