//HintName: test_generic-value+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public class testGnrcValueInp
  : GqlpEncoderBase
  , ItestGnrcValueInp
{
  public ItestRefGnrcValueInp<testEnumGnrcValueInp>? AsEnumGnrcValueInpgnrcValueInp { get; set; }
  public ItestGnrcValueInpObject? As_GnrcValueInp { get; set; }
}

public class testGnrcValueInpObject
  : GqlpEncoderBase
  , ItestGnrcValueInpObject
{

  public testGnrcValueInpObject
    ()
  {
  }
}

public class testRefGnrcValueInp<TType>
  : GqlpEncoderBase
  , ItestRefGnrcValueInp<TType>
{
  public ItestRefGnrcValueInpObject<TType>? As_RefGnrcValueInp { get; set; }
}

public class testRefGnrcValueInpObject<TType>
  : GqlpEncoderBase
  , ItestRefGnrcValueInpObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcValueInpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumGnrcValueInp
{
  gnrcValueInp,
}
