//HintName: test_constraint-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public class testCnstEnumInp
  : GqlpEncoderBase
  , ItestCnstEnumInp
{
  public ItestRefCnstEnumInp<testEnumCnstEnumInp>? AsEnumCnstEnumInpcnstEnumInp { get; set; }
  public ItestCnstEnumInpObject? As_CnstEnumInp { get; set; }
}

public class testCnstEnumInpObject
  : GqlpEncoderBase
  , ItestCnstEnumInpObject
{

  public testCnstEnumInpObject
    ()
  {
  }
}

public class testRefCnstEnumInp<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumInp<TType>
{
  public ItestRefCnstEnumInpObject<TType>? As_RefCnstEnumInp { get; set; }
}

public class testRefCnstEnumInpObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumInpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumInpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstEnumInp
{
  cnstEnumInp,
}
