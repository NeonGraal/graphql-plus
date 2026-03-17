//HintName: test_generic-parent-param+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
}

public class testRefGnrcPrntParamOutp<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntParamOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntParamOutpObject<TRef>? As_RefGnrcPrntParamOutp { get; set; }
}

public class testRefGnrcPrntParamOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntParamOutpObject<TRef>
{
}

public class testAltGnrcPrntParamOutp
  : GqlpModelImplementationBase
  , ItestAltGnrcPrntParamOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcPrntParamOutpObject? As_AltGnrcPrntParamOutp { get; set; }
}

public class testAltGnrcPrntParamOutpObject
  : GqlpModelImplementationBase
  , ItestAltGnrcPrntParamOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcPrntParamOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
