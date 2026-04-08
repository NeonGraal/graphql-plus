//HintName: test_generic-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public class testGnrcEnumDual
  : GqlpEncoderBase
  , ItestGnrcEnumDual
{
  public ItestRefGnrcEnumDual<testEnumGnrcEnumDual>? AsEnumGnrcEnumDualgnrcEnumDual { get; set; }
  public ItestGnrcEnumDualObject? As_GnrcEnumDual { get; set; }
}

public class testGnrcEnumDualObject
  : GqlpEncoderBase
  , ItestGnrcEnumDualObject
{

  public testGnrcEnumDualObject
    ()
  {
  }
}

public class testRefGnrcEnumDual<TType>
  : GqlpEncoderBase
  , ItestRefGnrcEnumDual<TType>
{
  public ItestRefGnrcEnumDualObject<TType>? As_RefGnrcEnumDual { get; set; }
}

public class testRefGnrcEnumDualObject<TType>
  : GqlpEncoderBase
  , ItestRefGnrcEnumDualObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcEnumDualObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumGnrcEnumDual
{
  gnrcEnumDual,
}
