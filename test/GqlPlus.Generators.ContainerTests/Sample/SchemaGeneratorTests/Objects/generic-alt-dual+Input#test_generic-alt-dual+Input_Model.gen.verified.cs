//HintName: test_generic-alt-dual+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public class testGnrcAltDualInp
  : GqlpModelBase
  , ItestGnrcAltDualInp
{
  public ItestRefGnrcAltDualInp<ItestAltGnrcAltDualInp>? AsRefGnrcAltDualInp { get; set; }
  public ItestGnrcAltDualInpObject? As_GnrcAltDualInp { get; set; }
}

public class testGnrcAltDualInpObject
  : GqlpModelBase
  , ItestGnrcAltDualInpObject
{

  public testGnrcAltDualInpObject
    ()
  {
  }
}

public class testRefGnrcAltDualInp<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltDualInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltDualInpObject<TRef>? As_RefGnrcAltDualInp { get; set; }
}

public class testRefGnrcAltDualInpObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltDualInpObject<TRef>
{

  public testRefGnrcAltDualInpObject
    ()
  {
  }
}

public class testAltGnrcAltDualInp
  : GqlpModelBase
  , ItestAltGnrcAltDualInp
{
  public string? AsString { get; set; }
  public ItestAltGnrcAltDualInpObject? As_AltGnrcAltDualInp { get; set; }
}

public class testAltGnrcAltDualInpObject
  : GqlpModelBase
  , ItestAltGnrcAltDualInpObject
{
  public decimal Alt { get; set; }

  public testAltGnrcAltDualInpObject
    ( decimal palt
    )
  {
    Alt = palt;
  }
}
