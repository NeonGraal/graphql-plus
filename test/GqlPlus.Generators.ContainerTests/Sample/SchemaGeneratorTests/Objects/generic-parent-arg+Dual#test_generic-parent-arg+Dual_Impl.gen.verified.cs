//HintName: test_generic-parent-arg+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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

  public testGnrcPrntArgDualObject()
  {
  }
}

public class testRefGnrcPrntArgDual<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntArgDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntArgDualObject<TRef>? As_RefGnrcPrntArgDual { get; set; }
}

public class testRefGnrcPrntArgDualObject<TRef>
  : GqlpModelImplementationBase
  , ItestRefGnrcPrntArgDualObject<TRef>
{

  public testRefGnrcPrntArgDualObject()
  {
  }
}
