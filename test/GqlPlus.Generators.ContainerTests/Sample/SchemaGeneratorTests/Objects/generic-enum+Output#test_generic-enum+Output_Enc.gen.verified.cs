//HintName: test_generic-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public class testGnrcEnumOutp
  : GqlpEncoderBase
  , ItestGnrcEnumOutp
{
  public ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp>? AsEnumGnrcEnumOutpgnrcEnumOutp { get; set; }
  public ItestGnrcEnumOutpObject? As_GnrcEnumOutp { get; set; }
}

public class testGnrcEnumOutpObject
  : GqlpEncoderBase
  , ItestGnrcEnumOutpObject
{

  public testGnrcEnumOutpObject
    ()
  {
  }
}

public class testRefGnrcEnumOutp<TType>
  : GqlpEncoderBase
  , ItestRefGnrcEnumOutp<TType>
{
  public ItestRefGnrcEnumOutpObject<TType>? As_RefGnrcEnumOutp { get; set; }
}

public class testRefGnrcEnumOutpObject<TType>
  : GqlpEncoderBase
  , ItestRefGnrcEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcEnumOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumGnrcEnumOutp
{
  gnrcEnumOutp,
}
