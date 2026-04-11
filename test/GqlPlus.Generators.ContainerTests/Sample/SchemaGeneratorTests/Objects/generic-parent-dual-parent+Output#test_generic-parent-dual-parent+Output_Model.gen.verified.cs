//HintName: test_generic-parent-dual-parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
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

  public testGnrcPrntDualPrntOutpObject
    ()
  {
  }
}

public class testRefGnrcPrntDualPrntOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntDualPrntOutp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefGnrcPrntDualPrntOutpObject<TRef>? As_RefGnrcPrntDualPrntOutp { get; set; }
}

public class testRefGnrcPrntDualPrntOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntDualPrntOutpObject<TRef>
{

  public testRefGnrcPrntDualPrntOutpObject
    ()
  {
  }
}

public class testAltGnrcPrntDualPrntOutp
  : GqlpModelBase
  , ItestAltGnrcPrntDualPrntOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntDualPrntOutpObject? As_AltGnrcPrntDualPrntOutp { get; set; }
}

public class testAltGnrcPrntDualPrntOutpObject
  : GqlpModelBase
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
