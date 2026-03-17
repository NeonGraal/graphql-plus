//HintName: test_generic-parent-dual+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

public class testGnrcPrntDualOutp
  : testRefGnrcPrntDualOutp<ItestAltGnrcPrntDualOutp>
  , ItestGnrcPrntDualOutp
{
  public ItestGnrcPrntDualOutpObject? As_GnrcPrntDualOutp { get; set; }
}

public class testGnrcPrntDualOutpObject
  : testRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>
  , ItestGnrcPrntDualOutpObject
{
}

public class testRefGnrcPrntDualOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntDualOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntDualOutpObject<TRef>? As_RefGnrcPrntDualOutp { get; set; }
}

public class testRefGnrcPrntDualOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntDualOutpObject<TRef>
{
}

public class testAltGnrcPrntDualOutp
  : GqlpModelImplementationBase
  , ItestAltGnrcPrntDualOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntDualOutpObject? As_AltGnrcPrntDualOutp { get; set; }
}

public class testAltGnrcPrntDualOutpObject
  : GqlpModelImplementationBase
  , ItestAltGnrcPrntDualOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntDualOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
