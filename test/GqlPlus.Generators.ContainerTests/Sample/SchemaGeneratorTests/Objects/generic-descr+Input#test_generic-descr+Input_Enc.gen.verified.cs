//HintName: test_generic-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Input;

public class testGnrcDescrInp<TType>
  : GqlpEncoderBase
  , ItestGnrcDescrInp<TType>
{
  public ItestGnrcDescrInpObject<TType>? As_GnrcDescrInp { get; set; }
}

public class testGnrcDescrInpObject<TType>
  : GqlpEncoderBase
  , ItestGnrcDescrInpObject<TType>
{
  public TType Field { get; set; }

  public testGnrcDescrInpObject
    ( TType field
    )
  {
    Field = field;
  }
}
