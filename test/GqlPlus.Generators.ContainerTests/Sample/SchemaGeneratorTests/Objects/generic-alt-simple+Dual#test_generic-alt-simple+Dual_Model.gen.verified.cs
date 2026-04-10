//HintName: test_generic-alt-simple+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public class testGnrcAltSmplDual
  : GqlpModelBase
  , ItestGnrcAltSmplDual
{
  public ItestRefGnrcAltSmplDual<string>? AsRefGnrcAltSmplDual { get; set; }
  public ItestGnrcAltSmplDualObject? As_GnrcAltSmplDual { get; set; }
}

public class testGnrcAltSmplDualObject
  : GqlpModelBase
  , ItestGnrcAltSmplDualObject
{

  public testGnrcAltSmplDualObject
    ()
  {
  }
}

public class testRefGnrcAltSmplDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltSmplDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltSmplDualObject<TRef>? As_RefGnrcAltSmplDual { get; set; }
}

public class testRefGnrcAltSmplDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltSmplDualObject<TRef>
{

  public testRefGnrcAltSmplDualObject
    ()
  {
  }
}
