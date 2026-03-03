//HintName: test_generic-parent-param-parent+Input_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public class testGnrcPrntParamPrntInp
  : testRefGnrcPrntParamPrntInp<ItestAltGnrcPrntParamPrntInp>
  , ItestGnrcPrntParamPrntInp
{
  public ItestGnrcPrntParamPrntInpObject? As_GnrcPrntParamPrntInp { get; set; }
}

public class testGnrcPrntParamPrntInpObject
  : testRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>
  , ItestGnrcPrntParamPrntInpObject
{

  public testGnrcPrntParamPrntInpObject
    ()
  {
  }
}

public class testRefGnrcPrntParamPrntInp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntParamPrntInp<TRef>
{
  public TRef? As_Parent { get; set; }
  public ItestRefGnrcPrntParamPrntInpObject<TRef>? As_RefGnrcPrntParamPrntInp { get; set; }
}

public class testRefGnrcPrntParamPrntInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntParamPrntInpObject<TRef>
{

  public testRefGnrcPrntParamPrntInpObject
    ()
  {
  }
}

public class testAltGnrcPrntParamPrntInp
  : GqlpModelImplementationBase
  , ItestAltGnrcPrntParamPrntInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntParamPrntInpObject? As_AltGnrcPrntParamPrntInp { get; set; }
}

public class testAltGnrcPrntParamPrntInpObject
  : GqlpModelImplementationBase
  , ItestAltGnrcPrntParamPrntInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntParamPrntInpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
