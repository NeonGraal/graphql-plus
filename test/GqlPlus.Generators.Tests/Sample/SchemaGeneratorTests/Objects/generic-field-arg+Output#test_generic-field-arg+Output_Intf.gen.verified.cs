//HintName: test_generic-field-arg+Output_Intf.gen.cs
// Generated from generic-field-arg+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Output;

public interface ItestGnrcFieldArgOutp<Ttype>
{
  RefGnrcFieldArgOutp<Ttype> field { get; }
}

public interface ItestRefGnrcFieldArgOutp<Tref>
{
  Tref Asref { get; }
}
