//HintName: test_constraint-dom-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public class testCnstDomEnumInp
  : GqlpEncoderBase
  , ItestCnstDomEnumInp
{
  public ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp>? AsEnumCnstDomEnumInpcnstDomEnumInp { get; set; }
  public ItestCnstDomEnumInpObject? As_CnstDomEnumInp { get; set; }
}

public class testCnstDomEnumInpObject
  : GqlpEncoderBase
  , ItestCnstDomEnumInpObject
{

  public testCnstDomEnumInpObject
    ()
  {
  }
}

public class testRefCnstDomEnumInp<TType>
  : GqlpEncoderBase
  , ItestRefCnstDomEnumInp<TType>
{
  public ItestRefCnstDomEnumInpObject<TType>? As_RefCnstDomEnumInp { get; set; }
}

public class testRefCnstDomEnumInpObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstDomEnumInpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstDomEnumInpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstDomEnumInp
{
  cnstDomEnumInp,
  other,
}

public class testJustCnstDomEnumInp
  : GqlpDomainEnum
  , ItestJustCnstDomEnumInp
{
}
