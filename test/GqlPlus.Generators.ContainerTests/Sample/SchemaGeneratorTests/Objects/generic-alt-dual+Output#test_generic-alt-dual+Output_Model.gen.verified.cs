//HintName: test_generic-alt-dual+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public class testGnrcAltDualOutp
  : GqlpModelBase
  , ItestGnrcAltDualOutp
{
  public ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp>? AsRefGnrcAltDualOutp { get; set; }
  public ItestGnrcAltDualOutpObject? As_GnrcAltDualOutp { get; set; }
}

public class testGnrcAltDualOutpObject
  : GqlpModelBase
  , ItestGnrcAltDualOutpObject
{

  public testGnrcAltDualOutpObject
    ()
  {
  }
}

public class testRefGnrcAltDualOutp<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltDualOutp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltDualOutpObject<TRef>? As_RefGnrcAltDualOutp { get; set; }
}

public class testRefGnrcAltDualOutpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltDualOutpObject<TRef>
{

  public testRefGnrcAltDualOutpObject
    ()
  {
  }
}

public class testAltGnrcAltDualOutp
  : GqlpModelBase
  , ItestAltGnrcAltDualOutp
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltDualOutpObject? As_AltGnrcAltDualOutp { get; set; }
}

public class testAltGnrcAltDualOutpObject
  : GqlpModelBase
  , ItestAltGnrcAltDualOutpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltDualOutpObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
