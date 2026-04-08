//HintName: test_constraint-dom-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public class testCnstDomEnumOutp
  : GqlpEncoderBase
  , ItestCnstDomEnumOutp
{
  public ItestRefCnstDomEnumOutp<testEnumCnstDomEnumOutp>? AsEnumCnstDomEnumOutpcnstDomEnumOutp { get; set; }
  public ItestCnstDomEnumOutpObject? As_CnstDomEnumOutp { get; set; }
}

public class testCnstDomEnumOutpObject
  : GqlpEncoderBase
  , ItestCnstDomEnumOutpObject
{

  public testCnstDomEnumOutpObject
    ()
  {
  }
}

public class testRefCnstDomEnumOutp<TType>
  : GqlpEncoderBase
  , ItestRefCnstDomEnumOutp<TType>
{
  public ItestRefCnstDomEnumOutpObject<TType>? As_RefCnstDomEnumOutp { get; set; }
}

public class testRefCnstDomEnumOutpObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstDomEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstDomEnumOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstDomEnumOutp
{
  cnstDomEnumOutp,
  other,
}

public class testJustCnstDomEnumOutp
  : GqlpDomainEnum
  , ItestJustCnstDomEnumOutp
{
}
