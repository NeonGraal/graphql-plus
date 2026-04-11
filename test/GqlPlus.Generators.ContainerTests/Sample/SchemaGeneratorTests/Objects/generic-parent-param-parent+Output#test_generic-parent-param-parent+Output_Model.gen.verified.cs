//HintName: test_generic-parent-param-parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public class testGnrcPrntParamPrntOutp
  : testRefGnrcPrntParamPrntOutp<ItestAltGnrcPrntParamPrntOutp>
  , ItestGnrcPrntParamPrntOutp
{
  public ItestGnrcPrntParamPrntOutpObject? As_GnrcPrntParamPrntOutp { get; set; }
}

public class testGnrcPrntParamPrntOutpObject
  : testRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>
  , ItestGnrcPrntParamPrntOutpObject
{

  public testGnrcPrntParamPrntOutpObject
    ()
  {
  }
}

public class testRefGnrcPrntParamPrntOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntParamPrntOutp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefGnrcPrntParamPrntOutpObject<TRef>? As_RefGnrcPrntParamPrntOutp { get; set; }
}

public class testRefGnrcPrntParamPrntOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntParamPrntOutpObject<TRef>
{

  public testRefGnrcPrntParamPrntOutpObject
    ()
  {
  }
}

public class testAltGnrcPrntParamPrntOutp
  : GqlpModelBase
  , ItestAltGnrcPrntParamPrntOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntParamPrntOutpObject? As_AltGnrcPrntParamPrntOutp { get; set; }
}

public class testAltGnrcPrntParamPrntOutpObject
  : GqlpModelBase
  , ItestAltGnrcPrntParamPrntOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntParamPrntOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
