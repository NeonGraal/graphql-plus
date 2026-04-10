//HintName: test_generic-parent-descr+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Dual;

public class testGnrcPrntDescrDual<TType>
  : GqlpModelBase
  , ItestGnrcPrntDescrDual<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntDescrDualObject<TType>? As_GnrcPrntDescrDual { get; set; }
}

public class testGnrcPrntDescrDualObject<TType>
  : GqlpModelBase
  , ItestGnrcPrntDescrDualObject<TType>
{

  public testGnrcPrntDescrDualObject
    ()
  {
  }
}
