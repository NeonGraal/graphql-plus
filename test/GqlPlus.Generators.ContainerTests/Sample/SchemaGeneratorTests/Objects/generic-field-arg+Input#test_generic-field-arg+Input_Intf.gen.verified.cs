//HintName: test_generic-field-arg+Input_Intf.gen.cs
// Generated from generic-field-arg+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public interface ItestGnrcFieldArgInp<Ttype>
{
}

public interface ItestGnrcFieldArgInpObject<Ttype>
{
  public ItestRefGnrcFieldArgInp<Ttype> Field { get; set; }
}

public interface ItestRefGnrcFieldArgInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefGnrcFieldArgInpObject<Tref>
{
}
