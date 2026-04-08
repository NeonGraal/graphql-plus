//HintName: test_constraint-enum-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public class testCnstEnumPrntInp
  : GqlpEncoderBase
  , ItestCnstEnumPrntInp
{
  public ItestRefCnstEnumPrntInp<testEnumCnstEnumPrntInp>? AsEnumCnstEnumPrntInpcnstEnumPrntInp { get; set; }
  public ItestCnstEnumPrntInpObject? As_CnstEnumPrntInp { get; set; }
}

public class testCnstEnumPrntInpObject
  : GqlpEncoderBase
  , ItestCnstEnumPrntInpObject
{

  public testCnstEnumPrntInpObject
    ()
  {
  }
}

public class testRefCnstEnumPrntInp<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumPrntInp<TType>
{
  public ItestRefCnstEnumPrntInpObject<TType>? As_RefCnstEnumPrntInp { get; set; }
}

public class testRefCnstEnumPrntInpObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumPrntInpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumPrntInpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstEnumPrntInp
{
  parentCnstEnumPrntInp = testParentCnstEnumPrntInp.parentCnstEnumPrntInp,
  cnstEnumPrntInp,
}

public enum testParentCnstEnumPrntInp
{
  parentCnstEnumPrntInp,
}
