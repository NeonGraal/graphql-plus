//HintName: test_generic-alt-dual+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public class testGnrcAltDualOutp
  : GqlpModelImplementationBase
  , ItestGnrcAltDualOutp
{
  public ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp>? AsRefGnrcAltDualOutp { get; set; }
  public ItestGnrcAltDualOutpObject? As_GnrcAltDualOutp { get; set; }
}

public class testGnrcAltDualOutpObject
  : GqlpModelImplementationBase
  , ItestGnrcAltDualOutpObject
{

  public testGnrcAltDualOutpObject
    ()
  {
  }
}

public class testRefGnrcAltDualOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltDualOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltDualOutpObject<TRef>? As_RefGnrcAltDualOutp { get; set; }
}

public class testRefGnrcAltDualOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltDualOutpObject<TRef>
{

  public testRefGnrcAltDualOutpObject
    ()
  {
  }
}

public class testAltGnrcAltDualOutp
  : GqlpModelImplementationBase
  , ItestAltGnrcAltDualOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltDualOutpObject? As_AltGnrcAltDualOutp { get; set; }
}

public class testAltGnrcAltDualOutpObject
  : GqlpModelImplementationBase
  , ItestAltGnrcAltDualOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltDualOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
