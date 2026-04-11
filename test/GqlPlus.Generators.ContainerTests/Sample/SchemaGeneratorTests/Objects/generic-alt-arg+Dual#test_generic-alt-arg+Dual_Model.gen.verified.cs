//HintName: test_generic-alt-arg+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

public class testGnrcAltArgDual<TType>
  : GqlpModelBase
  , ItestGnrcAltArgDual<TType>
{
  public ItestRefGnrcAltArgDual<TType>? AsRefGnrcAltArgDual { get; set; }
  public ItestGnrcAltArgDualObject<TType>? As_GnrcAltArgDual { get; set; }
}

public class testGnrcAltArgDualObject<TType>
  : GqlpModelBase
  , ItestGnrcAltArgDualObject<TType>
{

  public testGnrcAltArgDualObject
    ()
  {
  }
}

public class testRefGnrcAltArgDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltArgDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcAltArgDualObject<TRef>? As_RefGnrcAltArgDual { get; set; }
}

public class testRefGnrcAltArgDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcAltArgDualObject<TRef>
{

  public testRefGnrcAltArgDualObject
    ()
  {
  }
}
