//HintName: test_generic-alt-arg+Output_Impl.gen.cs
// Generated from generic-alt-arg+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public class testGnrcAltArgOutp<TType>
  : ItestGnrcAltArgOutp<TType>
{
  public ItestRefGnrcAltArgOutp<TType> AsRefGnrcAltArgOutp { get; set; }
  public ItestGnrcAltArgOutpObject AsGnrcAltArgOutp { get; set; }
}

public class testRefGnrcAltArgOutp<TRef>
  : ItestRefGnrcAltArgOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltArgOutpObject AsRefGnrcAltArgOutp { get; set; }
}
