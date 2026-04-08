//HintName: test_constraint-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public class testCnstEnumOutp
  : GqlpEncoderBase
  , ItestCnstEnumOutp
{
  public ItestRefCnstEnumOutp<testEnumCnstEnumOutp>? AsEnumCnstEnumOutpcnstEnumOutp { get; set; }
  public ItestCnstEnumOutpObject? As_CnstEnumOutp { get; set; }
}

public class testCnstEnumOutpObject
  : GqlpEncoderBase
  , ItestCnstEnumOutpObject
{

  public testCnstEnumOutpObject
    ()
  {
  }
}

public class testRefCnstEnumOutp<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumOutp<TType>
{
  public ItestRefCnstEnumOutpObject<TType>? As_RefCnstEnumOutp { get; set; }
}

public class testRefCnstEnumOutpObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstEnumOutp
{
  cnstEnumOutp,
}
