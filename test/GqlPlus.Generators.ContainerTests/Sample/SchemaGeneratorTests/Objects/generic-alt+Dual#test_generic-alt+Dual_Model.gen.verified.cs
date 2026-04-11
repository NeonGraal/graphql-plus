//HintName: test_generic-alt+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Dual;

public class testGnrcAltDual<TType>
  : GqlpModelBase
  , ItestGnrcAltDual<TType>
{
  public TType? Astype { get; set; }
  public ItestGnrcAltDualObject<TType>? As_GnrcAltDual { get; set; }
}

public class testGnrcAltDualObject<TType>
  : GqlpModelBase
  , ItestGnrcAltDualObject<TType>
{

  public testGnrcAltDualObject
    ()
  {
  }
}
