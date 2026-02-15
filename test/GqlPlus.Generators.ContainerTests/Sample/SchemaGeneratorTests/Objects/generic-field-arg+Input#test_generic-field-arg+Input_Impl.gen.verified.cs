//HintName: test_generic-field-arg+Input_Impl.gen.cs
// Generated from generic-field-arg+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public class testGnrcFieldArgInp<TType>
  : ItestGnrcFieldArgInp<TType>
{
  public ItestRefGnrcFieldArgInp<TType> Field { get; set; }
}

public class testRefGnrcFieldArgInp<TRef>
  : ItestRefGnrcFieldArgInp<TRef>
{
}
