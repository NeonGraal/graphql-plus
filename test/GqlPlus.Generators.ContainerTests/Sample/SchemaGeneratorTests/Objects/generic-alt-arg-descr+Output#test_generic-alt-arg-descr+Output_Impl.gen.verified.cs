//HintName: test_generic-alt-arg-descr+Output_Impl.gen.cs
// Generated from generic-alt-arg-descr+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

public class testGnrcAltArgDescrOutp<TType>
  : ItestGnrcAltArgDescrOutp<TType>
{
  public ItestRefGnrcAltArgDescrOutp<TType> AsRefGnrcAltArgDescrOutp { get; set; }
  public ItestGnrcAltArgDescrOutpObject AsGnrcAltArgDescrOutp { get; set; }
}

public class testRefGnrcAltArgDescrOutp<TRef>
  : ItestRefGnrcAltArgDescrOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltArgDescrOutpObject AsRefGnrcAltArgDescrOutp { get; set; }
}
