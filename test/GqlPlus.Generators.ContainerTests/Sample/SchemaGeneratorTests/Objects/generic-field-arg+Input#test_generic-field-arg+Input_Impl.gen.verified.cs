//HintName: test_generic-field-arg+Input_Impl.gen.cs
// Generated from generic-field-arg+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public class testGnrcFieldArgInp<Ttype>
  : ItestGnrcFieldArgInp<Ttype>
{
  public ItestRefGnrcFieldArgInp<Ttype> Field { get; set; }
}

public class testRefGnrcFieldArgInp<Tref>
  : ItestRefGnrcFieldArgInp<Tref>
{
  public Tref Asref { get; set; }
}
