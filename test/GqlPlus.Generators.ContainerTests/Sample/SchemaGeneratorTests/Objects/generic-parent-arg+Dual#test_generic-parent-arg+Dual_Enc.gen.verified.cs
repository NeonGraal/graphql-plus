//HintName: test_generic-parent-arg+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
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

  public testGnrcPrntArgDualObject
    ()
  {
  }
}

public class testRefGnrcPrntArgDual<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntArgDual<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntArgDualObject<TRef>? As_RefGnrcPrntArgDual { get; set; }
}

public class testRefGnrcPrntArgDualObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntArgDualObject<TRef>
{

  public testRefGnrcPrntArgDualObject
    ()
  {
  }
}
