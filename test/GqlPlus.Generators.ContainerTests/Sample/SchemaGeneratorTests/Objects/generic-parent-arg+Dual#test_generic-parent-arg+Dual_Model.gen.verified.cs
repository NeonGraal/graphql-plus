//HintName: test_generic-parent-arg+Dual_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Dual;

public class testGnrcPrntArgDual<TType>
  : testRefGnrcPrntArgDual<TType>
  , ItestGnrcPrntArgDual<TType>
{
  public ItestGnrcPrntArgDualObject<TType>? As_GnrcPrntArgDual { get; set; }
}

public class testGnrcPrntArgDualObject<TType>
  : testRefGnrcPrntArgDualObject<TType>
  , ItestGnrcPrntArgDualObject<TType>
{

  public testGnrcPrntArgDualObject
    ()
  {
  }
}

public class testRefGnrcPrntArgDual<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntArgDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntArgDualObject<TRef>? As_RefGnrcPrntArgDual { get; set; }
}

public class testRefGnrcPrntArgDualObject<TRef>
  : GqlpModelBase
  , ItestRefGnrcPrntArgDualObject<TRef>
{

  public testRefGnrcPrntArgDualObject
    ()
  {
  }
}
