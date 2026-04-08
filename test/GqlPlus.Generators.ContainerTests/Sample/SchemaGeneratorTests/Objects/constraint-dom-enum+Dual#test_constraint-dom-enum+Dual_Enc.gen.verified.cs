//HintName: test_constraint-dom-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public class testCnstDomEnumDual
  : GqlpEncoderBase
  , ItestCnstDomEnumDual
{
  public ItestRefCnstDomEnumDual<testEnumCnstDomEnumDual>? AsEnumCnstDomEnumDualcnstDomEnumDual { get; set; }
  public ItestCnstDomEnumDualObject? As_CnstDomEnumDual { get; set; }
}

public class testCnstDomEnumDualObject
  : GqlpEncoderBase
  , ItestCnstDomEnumDualObject
{

  public testCnstDomEnumDualObject
    ()
  {
  }
}

public class testRefCnstDomEnumDual<TType>
  : GqlpEncoderBase
  , ItestRefCnstDomEnumDual<TType>
{
  public ItestRefCnstDomEnumDualObject<TType>? As_RefCnstDomEnumDual { get; set; }
}

public class testRefCnstDomEnumDualObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstDomEnumDualObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstDomEnumDualObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstDomEnumDual
{
  cnstDomEnumDual,
  other,
}

public class testJustCnstDomEnumDual
  : GqlpDomainEnum
  , ItestJustCnstDomEnumDual
{
}
