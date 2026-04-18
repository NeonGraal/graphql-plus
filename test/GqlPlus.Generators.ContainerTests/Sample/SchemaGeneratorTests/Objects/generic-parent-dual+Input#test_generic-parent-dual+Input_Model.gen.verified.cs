//HintName: test_generic-parent-dual+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public class testGnrcPrntDualInp
  : testRefGnrcPrntDualInp<ItestAltGnrcPrntDualInp>
  , ItestGnrcPrntDualInp
{
  public ItestGnrcPrntDualInpObject? As_GnrcPrntDualInp { get; set; }
}

public class testGnrcPrntDualInpObject
  : testRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>
  , ItestGnrcPrntDualInpObject
{

  public testGnrcPrntDualInpObject
    ()
  {
  }
}

public class testRefGnrcPrntDualInp<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntDualInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntDualInpObject<TRef>? As_RefGnrcPrntDualInp { get; set; }
}

public class testRefGnrcPrntDualInpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntDualInpObject<TRef>
{

  public testRefGnrcPrntDualInpObject
    ()
  {
  }
}

public class testAltGnrcPrntDualInp
  : GqlpModelBase
  , ItestAltGnrcPrntDualInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntDualInpObject? As_AltGnrcPrntDualInp { get; set; }
}

public class testAltGnrcPrntDualInpObject
  : GqlpModelBase
  , ItestAltGnrcPrntDualInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntDualInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
