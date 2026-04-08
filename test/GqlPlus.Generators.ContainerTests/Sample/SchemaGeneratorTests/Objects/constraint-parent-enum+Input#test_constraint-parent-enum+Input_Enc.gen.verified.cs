//HintName: test_constraint-parent-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Input;

public class testCnstPrntEnumInp
  : GqlpEncoderBase
  , ItestCnstPrntEnumInp
{
  public ItestRefCnstPrntEnumInp<testParentCnstPrntEnumInp>? AsParentCnstPrntEnumInpparentCnstPrntEnumInp { get; set; }
  public ItestCnstPrntEnumInpObject? As_CnstPrntEnumInp { get; set; }
}

public class testCnstPrntEnumInpObject
  : GqlpEncoderBase
  , ItestCnstPrntEnumInpObject
{

  public testCnstPrntEnumInpObject
    ()
  {
  }
}

public class testRefCnstPrntEnumInp<TType>
  : GqlpEncoderBase
  , ItestRefCnstPrntEnumInp<TType>
{
  public ItestRefCnstPrntEnumInpObject<TType>? As_RefCnstPrntEnumInp { get; set; }
}

public class testRefCnstPrntEnumInpObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstPrntEnumInpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstPrntEnumInpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstPrntEnumInp
{
  parentCnstPrntEnumInp = testParentCnstPrntEnumInp.parentCnstPrntEnumInp,
  cnstPrntEnumInp,
}

public enum testParentCnstPrntEnumInp
{
  parentCnstPrntEnumInp,
}
