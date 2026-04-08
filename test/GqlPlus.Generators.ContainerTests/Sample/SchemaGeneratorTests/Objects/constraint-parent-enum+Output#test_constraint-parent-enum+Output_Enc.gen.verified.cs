//HintName: test_constraint-parent-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public class testCnstPrntEnumOutp
  : GqlpEncoderBase
  , ItestCnstPrntEnumOutp
{
  public ItestRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp>? AsParentCnstPrntEnumOutpparentCnstPrntEnumOutp { get; set; }
  public ItestCnstPrntEnumOutpObject? As_CnstPrntEnumOutp { get; set; }
}

public class testCnstPrntEnumOutpObject
  : GqlpEncoderBase
  , ItestCnstPrntEnumOutpObject
{

  public testCnstPrntEnumOutpObject
    ()
  {
  }
}

public class testRefCnstPrntEnumOutp<TType>
  : GqlpEncoderBase
  , ItestRefCnstPrntEnumOutp<TType>
{
  public ItestRefCnstPrntEnumOutpObject<TType>? As_RefCnstPrntEnumOutp { get; set; }
}

public class testRefCnstPrntEnumOutpObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstPrntEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstPrntEnumOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstPrntEnumOutp
{
  parentCnstPrntEnumOutp = testParentCnstPrntEnumOutp.parentCnstPrntEnumOutp,
  cnstPrntEnumOutp,
}

public enum testParentCnstPrntEnumOutp
{
  parentCnstPrntEnumOutp,
}
