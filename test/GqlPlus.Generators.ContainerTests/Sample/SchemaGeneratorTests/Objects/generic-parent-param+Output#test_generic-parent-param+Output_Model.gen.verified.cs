//HintName: test_generic-parent-param+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public class testGnrcPrntParamOutp
  : testRefGnrcPrntParamOutp<ItestAltGnrcPrntParamOutp>
  , ItestGnrcPrntParamOutp
{
  public ItestGnrcPrntParamOutpObject? As_GnrcPrntParamOutp { get; set; }
}

public class testGnrcPrntParamOutpObject
  : testRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>
  , ItestGnrcPrntParamOutpObject
{

  public testGnrcPrntParamOutpObject
    ()
  {
  }
}

public class testRefGnrcPrntParamOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntParamOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntParamOutpObject<TRef>? As_RefGnrcPrntParamOutp { get; set; }
}

public class testRefGnrcPrntParamOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntParamOutpObject<TRef>
{

  public testRefGnrcPrntParamOutpObject
    ()
  {
  }
}

public class testAltGnrcPrntParamOutp
  : GqlpModelBase
  , ItestAltGnrcPrntParamOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntParamOutpObject? As_AltGnrcPrntParamOutp { get; set; }
}

public class testAltGnrcPrntParamOutpObject
  : GqlpModelBase
  , ItestAltGnrcPrntParamOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntParamOutpObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
