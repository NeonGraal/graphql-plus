//HintName: test_generic-alt-simple+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public class testGnrcAltSmplDual
  : GqlpModelImplementationBase
  , ItestGnrcAltSmplDual
{
  public ItestRefGnrcAltSmplDual<string>? AsRefGnrcAltSmplDual { get; set; }
  public ItestGnrcAltSmplDualObject? As_GnrcAltSmplDual { get; set; }
}

public class testGnrcAltSmplDualObject
  : GqlpModelImplementationBase
  , ItestGnrcAltSmplDualObject
{

  public testGnrcAltSmplDualObject
    ()
  {
  }
}

public class testRefGnrcAltSmplDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltSmplDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltSmplDualObject<TRef>? As_RefGnrcAltSmplDual { get; set; }
}

public class testRefGnrcAltSmplDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltSmplDualObject<TRef>
{

  public testRefGnrcAltSmplDualObject
    ()
  {
  }
}
