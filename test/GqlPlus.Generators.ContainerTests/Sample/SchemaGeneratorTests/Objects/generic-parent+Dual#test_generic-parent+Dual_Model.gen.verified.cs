//HintName: test_generic-parent+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Dual;

public class testGnrcPrntDual<TType>
  : GqlpModelBase
  , ItestGnrcPrntDual<TType>
{
  public TType? As_Parent { get; set; }
  public ItestGnrcPrntDualObject<TType>? As_GnrcPrntDual { get; set; }
}

public class testGnrcPrntDualObject<TType>
  : GqlpModelBase
  , ItestGnrcPrntDualObject<TType>
{

  public testGnrcPrntDualObject
    ()
  {
  }
}
