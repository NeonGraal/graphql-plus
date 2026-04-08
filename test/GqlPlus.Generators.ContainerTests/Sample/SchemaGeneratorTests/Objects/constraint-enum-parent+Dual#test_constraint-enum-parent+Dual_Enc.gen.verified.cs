//HintName: test_constraint-enum-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Dual;

public class testCnstEnumPrntDual
  : GqlpEncoderBase
  , ItestCnstEnumPrntDual
{
  public ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual>? AsEnumCnstEnumPrntDualcnstEnumPrntDual { get; set; }
  public ItestCnstEnumPrntDualObject? As_CnstEnumPrntDual { get; set; }
}

public class testCnstEnumPrntDualObject
  : GqlpEncoderBase
  , ItestCnstEnumPrntDualObject
{

  public testCnstEnumPrntDualObject
    ()
  {
  }
}

public class testRefCnstEnumPrntDual<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumPrntDual<TType>
{
  public ItestRefCnstEnumPrntDualObject<TType>? As_RefCnstEnumPrntDual { get; set; }
}

public class testRefCnstEnumPrntDualObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumPrntDualObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumPrntDualObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstEnumPrntDual
{
  parentCnstEnumPrntDual = testParentCnstEnumPrntDual.parentCnstEnumPrntDual,
  cnstEnumPrntDual,
}

public enum testParentCnstEnumPrntDual
{
  parentCnstEnumPrntDual,
}
