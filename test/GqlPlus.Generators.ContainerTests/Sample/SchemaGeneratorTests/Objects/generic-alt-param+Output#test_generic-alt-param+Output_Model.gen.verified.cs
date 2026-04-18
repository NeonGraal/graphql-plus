//HintName: test_generic-alt-param+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public class testGnrcAltParamOutp
  : GqlpModelBase
  , ItestGnrcAltParamOutp
{
  public ItestRefGnrcAltParamOutp<ItestAltGnrcAltParamOutp>? AsRefGnrcAltParamOutp { get; set; }
  public ItestGnrcAltParamOutpObject? As_GnrcAltParamOutp { get; set; }
}

public class testGnrcAltParamOutpObject
  : GqlpModelBase
  , ItestGnrcAltParamOutpObject
{

  public testGnrcAltParamOutpObject
    ()
  {
  }
}

public class testRefGnrcAltParamOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltParamOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltParamOutpObject<TRef>? As_RefGnrcAltParamOutp { get; set; }
}

public class testRefGnrcAltParamOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltParamOutpObject<TRef>
{

  public testRefGnrcAltParamOutpObject
    ()
  {
  }
}

public class testAltGnrcAltParamOutp
  : GqlpModelBase
  , ItestAltGnrcAltParamOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltParamOutpObject? As_AltGnrcAltParamOutp { get; set; }
}

public class testAltGnrcAltParamOutpObject
  : GqlpModelBase
  , ItestAltGnrcAltParamOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltParamOutpObject
    ( decimal alt
    )
  {
    Alt = alt;
  }
}
