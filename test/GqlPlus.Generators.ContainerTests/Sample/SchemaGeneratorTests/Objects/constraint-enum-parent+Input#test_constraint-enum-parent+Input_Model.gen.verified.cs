//HintName: test_constraint-enum-parent+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public class testCnstEnumPrntInp
  : GqlpModelBase
  , ItestCnstEnumPrntInp
{
  public ItestRefCnstEnumPrntInp<testEnumCnstEnumPrntInp>? AsEnumCnstEnumPrntInpcnstEnumPrntInp { get; set; }
  public ItestCnstEnumPrntInpObject? As_CnstEnumPrntInp { get; set; }
}

public class testCnstEnumPrntInpObject
  : GqlpModelBase
  , ItestCnstEnumPrntInpObject
{

  public testCnstEnumPrntInpObject
    ()
  {
  }
}

public class testRefCnstEnumPrntInp<TType>
  : GqlpModelBase
  , ItestRefCnstEnumPrntInp<TType>
{
  public ItestRefCnstEnumPrntInpObject<TType>? As_RefCnstEnumPrntInp { get; set; }
}

public class testRefCnstEnumPrntInpObject<TType>
  : GqlpModelBase
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
