//HintName: test_generic-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public class testGnrcEnumInp
  : GqlpEncoderBase
  , ItestGnrcEnumInp
{
  public ItestRefGnrcEnumInp<testEnumGnrcEnumInp>? AsEnumGnrcEnumInpgnrcEnumInp { get; set; }
  public ItestGnrcEnumInpObject? As_GnrcEnumInp { get; set; }
}

public class testGnrcEnumInpObject
  : GqlpEncoderBase
  , ItestGnrcEnumInpObject
{

  public testGnrcEnumInpObject
    ()
  {
  }
}

public class testRefGnrcEnumInp<TType>
  : GqlpEncoderBase
  , ItestRefGnrcEnumInp<TType>
{
  public ItestRefGnrcEnumInpObject<TType>? As_RefGnrcEnumInp { get; set; }
}

public class testRefGnrcEnumInpObject<TType>
  : GqlpEncoderBase
  , ItestRefGnrcEnumInpObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcEnumInpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumGnrcEnumInp
{
  gnrcEnumInp,
}
