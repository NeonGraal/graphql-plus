//HintName: test_generic-parent+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Dual;

public class testGnrcPrntDual<TType>
  : GqlpModelImplementationBase
  , ItestGnrcPrntDual<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntDualObject<TType>? As_GnrcPrntDual { get; set; }
}

public class testGnrcPrntDualObject<TType>
  : GqlpModelImplementationBase
  , ItestGnrcPrntDualObject<TType>
{

  public testGnrcPrntDualObject
    ()
  {
  }
}
