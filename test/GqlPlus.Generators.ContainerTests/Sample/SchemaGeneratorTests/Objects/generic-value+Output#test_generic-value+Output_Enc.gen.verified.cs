//HintName: test_generic-value+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public class testGnrcValueOutp
  : GqlpEncoderBase
  , ItestGnrcValueOutp
{
  public ItestRefGnrcValueOutp<testEnumGnrcValueOutp>? AsEnumGnrcValueOutpgnrcValueOutp { get; set; }
  public ItestGnrcValueOutpObject? As_GnrcValueOutp { get; set; }
}

public class testGnrcValueOutpObject
  : GqlpEncoderBase
  , ItestGnrcValueOutpObject
{

  public testGnrcValueOutpObject
    ()
  {
  }
}

public class testRefGnrcValueOutp<TType>
  : GqlpEncoderBase
  , ItestRefGnrcValueOutp<TType>
{
  public ItestRefGnrcValueOutpObject<TType>? As_RefGnrcValueOutp { get; set; }
}

public class testRefGnrcValueOutpObject<TType>
  : GqlpEncoderBase
  , ItestRefGnrcValueOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcValueOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumGnrcValueOutp
{
  gnrcValueOutp,
}
