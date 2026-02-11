//HintName: test_generic-field-arg+Output_Impl.gen.cs
// Generated from generic-field-arg+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Output;

public class testGnrcFieldArgOutp<TType>
  : ItestGnrcFieldArgOutp<TType>
{
  public ItestRefGnrcFieldArgOutp<TType> Field { get; set; }
  public ItestGnrcFieldArgOutpObject AsGnrcFieldArgOutp { get; set; }
}

public class testRefGnrcFieldArgOutp<TRef>
  : ItestRefGnrcFieldArgOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldArgOutpObject AsRefGnrcFieldArgOutp { get; set; }
}
