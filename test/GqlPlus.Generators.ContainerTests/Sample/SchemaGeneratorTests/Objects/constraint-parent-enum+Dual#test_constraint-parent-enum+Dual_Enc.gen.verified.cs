//HintName: test_constraint-parent-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Dual;

public class testCnstPrntEnumDual
  : GqlpEncoderBase
  , ItestCnstPrntEnumDual
{
  public ItestRefCnstPrntEnumDual<testParentCnstPrntEnumDual>? AsParentCnstPrntEnumDualparentCnstPrntEnumDual { get; set; }
  public ItestCnstPrntEnumDualObject? As_CnstPrntEnumDual { get; set; }
}

public class testCnstPrntEnumDualObject
  : GqlpEncoderBase
  , ItestCnstPrntEnumDualObject
{

  public testCnstPrntEnumDualObject
    ()
  {
  }
}

public class testRefCnstPrntEnumDual<TType>
  : GqlpEncoderBase
  , ItestRefCnstPrntEnumDual<TType>
{
  public ItestRefCnstPrntEnumDualObject<TType>? As_RefCnstPrntEnumDual { get; set; }
}

public class testRefCnstPrntEnumDualObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstPrntEnumDualObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstPrntEnumDualObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstPrntEnumDual
{
  parentCnstPrntEnumDual = testParentCnstPrntEnumDual.parentCnstPrntEnumDual,
  cnstPrntEnumDual,
}

public enum testParentCnstPrntEnumDual
{
  parentCnstPrntEnumDual,
}
