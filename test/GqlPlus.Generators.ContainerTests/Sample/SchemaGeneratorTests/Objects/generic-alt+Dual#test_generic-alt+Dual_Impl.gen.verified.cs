//HintName: test_generic-alt+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Dual;

public class testGnrcAltDual<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltDual<TType>
{
  public TType? Astype { get; set; }
  public ItestGnrcAltDualObject<TType>? As_GnrcAltDual { get; set; }
}

public class testGnrcAltDualObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcAltDualObject<TType>
{

  public testGnrcAltDualObject
    ()
  {
  }
}
