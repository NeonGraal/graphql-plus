//HintName: test_constraint-enum-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public class testCnstEnumPrntOutp
  : GqlpEncoderBase
  , ItestCnstEnumPrntOutp
{
  public ItestRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp>? AsEnumCnstEnumPrntOutpcnstEnumPrntOutp { get; set; }
  public ItestCnstEnumPrntOutpObject? As_CnstEnumPrntOutp { get; set; }
}

public class testCnstEnumPrntOutpObject
  : GqlpEncoderBase
  , ItestCnstEnumPrntOutpObject
{

  public testCnstEnumPrntOutpObject
    ()
  {
  }
}

public class testRefCnstEnumPrntOutp<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumPrntOutp<TType>
{
  public ItestRefCnstEnumPrntOutpObject<TType>? As_RefCnstEnumPrntOutp { get; set; }
}

public class testRefCnstEnumPrntOutpObject<TType>
  : GqlpEncoderBase
  , ItestRefCnstEnumPrntOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumPrntOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public enum testEnumCnstEnumPrntOutp
{
  parentCnstEnumPrntOutp = testParentCnstEnumPrntOutp.parentCnstEnumPrntOutp,
  cnstEnumPrntOutp,
}

public enum testParentCnstEnumPrntOutp
{
  parentCnstEnumPrntOutp,
}
