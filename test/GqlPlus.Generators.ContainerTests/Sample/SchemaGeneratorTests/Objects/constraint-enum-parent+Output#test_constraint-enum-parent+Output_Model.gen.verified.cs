//HintName: test_constraint-enum-parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public class testCnstEnumPrntOutp
  : GqlpModelImplementationBase
  , ItestCnstEnumPrntOutp
{
  public ItestRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp>? AsEnumCnstEnumPrntOutpcnstEnumPrntOutp { get; set; }
  public ItestCnstEnumPrntOutpObject? As_CnstEnumPrntOutp { get; set; }
}

public class testCnstEnumPrntOutpObject
  : GqlpModelImplementationBase
  , ItestCnstEnumPrntOutpObject
{

  public testCnstEnumPrntOutpObject
    ()
  {
  }
}

public class testRefCnstEnumPrntOutp<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstEnumPrntOutp<TType>
{
  public ItestRefCnstEnumPrntOutpObject<TType>? As_RefCnstEnumPrntOutp { get; set; }
}

public class testRefCnstEnumPrntOutpObject<TType>
  : GqlpModelImplementationBase
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
