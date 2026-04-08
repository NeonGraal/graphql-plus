//HintName: test_generic-parent-arg+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Input;

public class testGnrcPrntArgInp<TType>
  : testRefGnrcPrntArgInp<TType>
  , ItestGnrcPrntArgInp<TType>
{
  public ItestGnrcPrntArgInpObject<TType>? As_GnrcPrntArgInp { get; set; }
}

public class testGnrcPrntArgInpObject<TType>
  : testRefGnrcPrntArgInpObject<TType>
  , ItestGnrcPrntArgInpObject<TType>
{

  public testGnrcPrntArgInpObject
    ()
  {
  }
}

public class testRefGnrcPrntArgInp<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntArgInp<TRef>
{
  public TRef? Asref { get; set; }
  public ItestRefGnrcPrntArgInpObject<TRef>? As_RefGnrcPrntArgInp { get; set; }
}

public class testRefGnrcPrntArgInpObject<TRef>
  : GqlpEncoderBase
  , ItestRefGnrcPrntArgInpObject<TRef>
{

  public testRefGnrcPrntArgInpObject
    ()
  {
  }
}
