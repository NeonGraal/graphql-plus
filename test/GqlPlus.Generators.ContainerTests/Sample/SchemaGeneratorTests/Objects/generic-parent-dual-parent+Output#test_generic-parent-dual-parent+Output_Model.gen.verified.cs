//HintName: test_generic-parent-dual-parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Output;

public class testGnrcPrntDualPrntOutp
  : testRefGnrcPrntDualPrntOutp<ItestAltGnrcPrntDualPrntOutp>
  , ItestGnrcPrntDualPrntOutp
{
  public ItestGnrcPrntDualPrntOutpObject? As_GnrcPrntDualPrntOutp { get; set; }
}

public class testGnrcPrntDualPrntOutpObject
  : testRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>
  , ItestGnrcPrntDualPrntOutpObject
{
}

public class testRefGnrcPrntDualPrntOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntDualPrntOutp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefGnrcPrntDualPrntOutpObject<TRef>? As_RefGnrcPrntDualPrntOutp { get; set; }
}

public class testRefGnrcPrntDualPrntOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntDualPrntOutpObject<TRef>
{
}

public class testAltGnrcPrntDualPrntOutp
  : GqlpModelImplementationBase
  , ItestAltGnrcPrntDualPrntOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntDualPrntOutpObject? As_AltGnrcPrntDualPrntOutp { get; set; }
}

public class testAltGnrcPrntDualPrntOutpObject
  : GqlpModelImplementationBase
  , ItestAltGnrcPrntDualPrntOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntDualPrntOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
