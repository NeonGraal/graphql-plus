//HintName: test_generic-alt-arg+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

public class testGnrcAltArgDual<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgDual<TType>
{
  public ItestRefGnrcAltArgDual<TType>? AsRefGnrcAltArgDual { get; set; }
  public ItestGnrcAltArgDualObject<TType>? As_GnrcAltArgDual { get; set; }
}

public class testGnrcAltArgDualObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltArgDualObject<TType>
{

  public testGnrcAltArgDualObject
    ()
  {
  }
}

public class testRefGnrcAltArgDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgDualObject<TRef>? As_RefGnrcAltArgDual { get; set; }
}

public class testRefGnrcAltArgDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcAltArgDualObject<TRef>
{

  public testRefGnrcAltArgDualObject
    ()
  {
  }
}
