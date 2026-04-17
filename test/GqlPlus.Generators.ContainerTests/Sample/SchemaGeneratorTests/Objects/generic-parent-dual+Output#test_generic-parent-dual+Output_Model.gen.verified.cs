//HintName: test_generic-parent-dual+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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

  public testGnrcPrntDualOutpObject
    ()
  {
  }
}

public class testRefGnrcPrntDualOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntDualOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntDualOutpObject<TRef>? As_RefGnrcPrntDualOutp { get; set; }
}

public class testRefGnrcPrntDualOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntDualOutpObject<TRef>
{

  public testRefGnrcPrntDualOutpObject
    ()
  {
  }
}

public class testAltGnrcPrntDualOutp
  : GqlpModelBase
  , ItestAltGnrcPrntDualOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntDualOutpObject? As_AltGnrcPrntDualOutp { get; set; }
}

public class testAltGnrcPrntDualOutpObject
  : GqlpModelBase
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
