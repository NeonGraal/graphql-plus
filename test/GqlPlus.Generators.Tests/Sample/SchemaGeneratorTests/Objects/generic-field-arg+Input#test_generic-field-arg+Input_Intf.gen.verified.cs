//HintName: test_generic-field-arg+Input_Intf.gen.cs
// Generated from generic-field-arg+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public interface ItestGnrcFieldArgInp<Ttype>
{
  RefGnrcFieldArgInp<Ttype> field { get; }
}

public interface ItestRefGnrcFieldArgInp<Tref>
{
  Tref Asref { get; }
}
