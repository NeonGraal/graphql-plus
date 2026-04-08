//HintName: test_constraint-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Dual;

public class testCnstEnumDual
  : GqlpEncoderBase
  , ItestCnstEnumDual
{
  public ItestRefCnstEnumDual<testEnumCnstEnumDual>? AsEnumCnstEnumDualcnstEnumDual { get; set; }
  public ItestCnstEnumDualObject? As_CnstEnumDual { get; set; }
}

public class testCnstEnumDualObject
  : GqlpEncoderBase
  , ItestCnstEnumDualObject
{

  public testCnstEnumDualObject
    ()
  {
  }
}

public class testRefCnstEnumDual<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumDual<TType>
{
  public ItestRefCnstEnumDualObject<TType>? As_RefCnstEnumDual { get; set; }
}

public class testRefCnstEnumDualObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumDualObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumDualObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstEnumDual
{
  cnstEnumDual,
}
